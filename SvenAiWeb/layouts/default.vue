<template>
  <v-app dark>
    <v-navigation-drawer v-model='$vuetify.breakpoint.mdAndUp || manualOpenDrawer' :clipped='clipped' @input='drawerChanged'
                         :permanent='$vuetify.breakpoint.mdAndUp' fixed app>
      <v-list>
        <v-list-item v-for='(item, i) in items' :key='i' :to='item.to' router exact>
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text='item.title' />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left='clipped' fixed app>
      <v-app-bar-nav-icon v-if='$vuetify.breakpoint.smAndDown' @click.stop='manualOpenDrawer = !manualOpenDrawer' />
    </v-app-bar>
    <v-content>
      <v-container>
        <nuxt />
      </v-container>
    </v-content>
    <v-footer :fixed='fixed' app>
      <span>&copy; 2020</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      clipped: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Welcome',
          to: '/'
        },
        {
          icon: 'mdi-chart-bubble',
          title: 'Inspire',
          to: '/inspire'
        }
      ],
      manualOpenDrawer: false,
      title: 'Vuetify.js'
    }
  },
  methods: {
    drawerChanged(open) {
      if (!open)
        this.manualOpenDrawer = false
    }
  }
}
</script>
