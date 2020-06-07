<template>
  <v-app dark>
    <v-navigation-drawer v-model="drawer" :clipped="clipped"
                         :permanent="$vuetify.breakpoint.mdAndUp" fixed app
    >
      <v-list nav>
        <v-list-item v-for="(item, i) in items" :key="i" :to="item.to" router exact>
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-app-bar-nav-icon v-if="$vuetify.breakpoint.smAndDown" @click.stop="drawer = !drawer" />
      <v-container fluid>
        <v-row no-gutters class="font-weight-light">
          <v-col align-self="center" cols="6">
            Stephen (Sven) Vernyi
          </v-col>
          <v-col align-self="end" offset-md="4" offset="1" cols="1" class="text-right">
            <a>Github</a>
          </v-col>
          <v-col align-self="end" offset-md="0" offset="1" cols="1" class="text-right">
            <a href="mailto:sven.vernyi@gmail.com">Email</a>
          </v-col>
        </v-row>
      </v-container>
    </v-app-bar>
    <v-content>
      <v-container>
        <nuxt />
      </v-container>
    </v-content>
    <v-footer :fixed="fixed" app>
      <span>&copy; 2020</span>
    </v-footer>
  </v-app>
</template>

<style>
  .v-content__wrap  {
    background-image: url('https://i.imgur.com/EncL64d.jpg');
    background-position: center;
    background-size: cover;
  }
  .v-list-item__title {
    text-overflow: unset;
    white-space: normal;
  }
  .v-navigation-drawer {
    background: rgba(0, 0, 0, 0.1);
  }
</style>

<script>
export default {
  data() {
    return {
      clipped: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-human-greeting',
          title: 'Greetings',
          to: '/'
        },
        {
          icon: 'mdi-information-outline',
          title: 'About Me',
          to: '/about'
        },
        {
          icon: 'mdi-account-group',
          title: 'Work Experience',
          to: '/work-experience'
        },
        {
          icon: 'mdi-clipboard-list-outline',
          title: 'Skillset',
          to: '/languages-and-tooling'
        },
        {
          icon: 'mdi-star-circle-outline',
          title: 'Unique Projects & Achievements',
          to: '/unique-projects'
        },
        {
          icon: 'mdi-briefcase',
          title: 'Past Projects',
          to: '/past-projects'
        }
      ],
      drawer: false,
      title: 'Vuetify.js'
    }
  }
}
</script>
