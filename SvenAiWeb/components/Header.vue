<template>
  <div>
    <v-row id="header" class="site-header-component pt-md-2 mx-0">
      <v-col v-if="$vuetify.breakpoint.mdAndUp" cols="3" lg="3" class="pt-md-6 pt-lg-4" align-self="start">
        <ContactMe />
      </v-col>
      <v-col offset="2" offset-sm="0" cols="8" lg="6" sm="12" md="6" align-self="center">
        <div class="d-flex flex-column text-center">
          <span :class="{ 'text-h4': $vuetify.breakpoint.smAndUp, 'text-h5': $vuetify.breakpoint.xsOnly }" class="grey--text">Stephen (Sven) Vernyi</span>
          <span :class="{ 'text-subtitle-1': $vuetify.breakpoint.smAndUp, 'text-caption': $vuetify.breakpoint.xsOnly }" class="grey--text">C# Developer and Sometimes-Frontend Meddler</span>
        </div>
      </v-col>
      <v-col id="links" v-if="$vuetify.breakpoint.mdAndUp" align-self="end" class="pl-0 float-right pt-md-6 pt-lg-4 pr-md-4 header-links text-right justify-space-around">
        <a class="ma-1 px-xl-2 px-lg-1 text-center" href="https://github.com/svengeance" target="_blank">
          <v-icon color="blue darken-1">mdi-github</v-icon>
          <p>GitHub</p>
        </a>
        <a class="ma-1 px-xl-2 px-lg-1 text-center" href="https://www.linkedin.com/in/stevevernyi/" target="_blank">
          <v-icon color="blue darken-1">mdi-linkedin</v-icon>
          <p>LinkedIn</p>
        </a>
        <a class="ma-1 px-xl-2 px-lg-1 text-center" href="https://twitter.com/SvenVernyi" target="_blank">
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
    position: relative;
  }
  .header-links {
    height: 100%;
    a {
      display: inline-block;
      text-decoration: none;
    }
  }
</style>
