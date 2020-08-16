<template>
  <v-app dark>
    <MobileNavigation v-if="$vuetify.breakpoint.mdAndDown" :links="tabs" />
    <v-container fluid class="pa-0">
      <v-row class="mx-0">
        <v-col order="1" class="pa-0">
          <no-ssr>
            <Header />
          </no-ssr>
          <v-tabs v-if="$vuetify.breakpoint.lgAndUp" background-color="transparent" class="pl-1">
            <v-tab v-for="tab in tabs" :key="tab.title" :to="tab.link" nuxt>
              {{ tab.title }}
            </v-tab>
          </v-tabs>
          <v-main class="pt-4">
            <perfect-scrollbar v-if="showScrollBar">
              <nuxt />
            </perfect-scrollbar>
            <nuxt v-else />
          </v-main>
        </v-col>
        <v-col v-if="$vuetify.breakpoint.lgAndUp" cols="3" xl="2" order="2" class="pa-0">
          <GithubFeed class=".d-inline-block" />
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      tabs: [
        { title: 'About', link: '/about' },
        { title: 'Projects', link: '/projects' },
        { title: 'Career', link: '/career' },
        { title: 'Languages & Tools', link: '/languages-and-tooling' },
        { title: 'Recent Blog Posts', link: '/recent-posts' }
      ]
    }
  },
  computed: {
    showScrollBar() {
      return !['git-activity'].includes(this.$route.name)
    }
  }
}
</script>
