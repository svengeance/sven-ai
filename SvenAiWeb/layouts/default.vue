<template>
  <v-app dark>
    <client-only>
      <MobileNavigation v-if="$vuetify.breakpoint.mdAndDown" :links="siteLinks" />
    </client-only>
    <v-container fluid class="pa-0">
      <v-row class="mx-0">
        <v-col lg="9" xl="10" order="1" class="pa-0">
          <client-only>
            <div id="header-wrapper">
              <Header />
            </div>
          </client-only>
          <div id="body-wrapper">
            <v-tabs v-if="$vuetify.breakpoint.lgAndUp" background-color="transparent" class="pl-1">
              <v-tab v-for="link in tabLinks" :key="link.title" :to="link.link" nuxt>
                {{ link.title }}
              </v-tab>
            </v-tabs>
            <v-main class="pt-4">
              <perfect-scrollbar v-if="showScrollBar" ref="scroll">
                <nuxt />
              </perfect-scrollbar>
              <nuxt v-else />
            </v-main>
          </div>
        </v-col>
        <v-col v-if="$vuetify.breakpoint.lgAndUp" cols="3" xl="2" order="2" class="pa-0">
          <GithubFeed class=".d-inline-block" />
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<style scoped lang="scss">
#header-wrapper {
  position: fixed;
  width: 100%;
}
#body-wrapper {
  margin-top: $header-height;
}
</style>

<script>
export default {
  data() {
    return {
      siteLinks: [
        { title: 'Hello!', link: '/hello-world' },
        { title: 'About', link: '/about' },
        { title: 'Projects', link: '/projects' },
        { title: 'Career', link: '/career' },
        { title: 'Languages & Tools', link: '/languages-and-tooling' },
        { title: 'Recent Blog Posts', link: '/recent-posts' },
        { title: 'GitHub Activity', link: '/git-activity', onlyMenu: true }
      ]
    }
  },
  computed: {
    tabLinks() {
      return this.siteLinks.filter(f => !f.onlyMenu)
    },
    showScrollBar() {
      return !['git-activity'].includes(this.$route.name)
    }
  },
  watch: {
    $route() {
      if (this.$refs.scroll)
        this.$refs.scroll.$el.scrollTop = 0
    }
  }
}
</script>
