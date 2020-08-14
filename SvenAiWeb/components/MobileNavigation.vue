<template>
  <div id="mobile-nav-overlay">
    <v-navigation-drawer id="mobile-nav-drawer" v-model="drawer" absolute temporary>
      <v-list-item class="px-0">
        <v-list-item-content>
          <ContactMe />
        </v-list-item-content>
      </v-list-item>

      <v-divider />

      <v-list dense>
        <v-list-item v-for="link in links" :key="link.title">
          <v-list-item-content>{{ link.title }}</v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-btn id="btn-mobile-nav-menu" v-if="$vuetify.breakpoint.smAndDown" @click.stop="drawer = !drawer" height="36px" x-small outlined color="rgb(25, 118, 210)">
      <v-icon color="blue" large>
        mdi-menu
      </v-icon>
    </v-btn>

    <v-fab-transition>
      <v-btn id="btn-mobile-gitfeed-toggle" :to="fabRoute" :key="fabRoute" color="rgb(25, 118, 210)" dark fixed right bottom fab>
        <v-icon>{{ btnIcon }}</v-icon>
      </v-btn>
    </v-fab-transition>
  </div>
</template>

<style lang="scss" scoped>
    #btn-mobile-nav-menu {
        left:2%;
        position: fixed;
        top: 24px;
        z-index: 999;
    }

    #btn-mobile-gitfeed-toggle {
        bottom: 24px;
        z-index: 999;;
    }

    #mobile-nav-drawer {
        z-index: 99999999;
    }
</style>

<script>
export default {
  props: ['links'],
  data() {
    return {
      drawer: null
    }
  },
  computed: {
    btnIcon() { return this.$route.name === 'git-activity' ? 'mdi-account-tie' : 'mdi-code-json' },
    fabRoute() { return this.$route.name === 'git-activity' ? '/about' : '/git-activity' }
  }
}
</script>
