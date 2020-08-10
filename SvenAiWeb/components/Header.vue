<template>
  <div>
    <v-row id="header" class="site-header-component">
      <v-col v-if="$vuetify.breakpoint.lgAndUp" cols="3" align-self="start">
        <ContactMe />
      </v-col>
      <v-col cols="12" lg="6" align-self="middle">
        <div class="d-flex flex-column text-center">
          <span class="text-h4 grey--text">Nox</span>
          <span class="text-subtitle-1 grey--text">Member of C# Discord Who Can't Come Up With a Good Tagline</span>
        </div>
      </v-col>
      <v-col id="links" v-if="$vuetify.breakpoint.lgAndUp" cols="3" align-self="end" class="header-links text-right">
        <a class="ma-1 text-center" href="https://github.com/svengeance" target="_blank">
          <v-icon color="blue darken-1">mdi-github</v-icon>
          <p>GitHub</p>
        </a>
        <a class="ma-1 text-center" href="https://www.linkedin.com/in/stevevernyi/" target="_blank">
          <v-icon color="blue darken-1">mdi-linkedin</v-icon>
          <p>LinkedIn</p>
        </a>
        <a class="ma-1 text-center" href="https://twitter.com/SvenVernyi" target="_blank">
          <v-icon color="blue darken-1">mdi-twitter</v-icon>
          <p>Twitter</p>
        </a>
      </v-col>
    </v-row>
    <v-divider />
  </div>
</template>

<style lang="scss" scoped>
  #header {
    background-color: rgba($color: white, $alpha: 0.05);
  }
  .header-links {
    height: 100%;
    a {
      display: inline-block;
      padding: 0px 10px;
      text-decoration: none;
    }
  }
</style>
