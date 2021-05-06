<template>
  <header>
    <v-container fluid class="mx-0 px-0">
      <v-row id="header" class="site-header-component pt-md-4 mx-0">
        <v-col v-if="$vuetify.breakpoint.lgAndUp" cols="3" lg="3" class="pt-md-8 pt-lg-6" align-self="start">
          <ContactMe />
        </v-col>
        <v-col offset="2" offset-md="3" offset-lg="0" cols="9" lg="6" sm="8" md="6" align-self="center">
          <div class="d-flex flex-column text-center">
            <h1 :class="{ 'text-h4': $vuetify.breakpoint.smAndUp, 'text-h6': $vuetify.breakpoint.xsOnly }" class="grey--text text--lighten-2">
              Stephen (Sven) Vernyi
            </h1>
            <h2 :class="{ 'text-subtitle-1': $vuetify.breakpoint.smAndUp, 'text-caption': $vuetify.breakpoint.xsOnly }" class="grey--text text--lighten-1">
              Full Stack .NET Dev &amp; Azure Enthusiast
            </h2>
          </div>
        </v-col>
        <v-col v-if="$vuetify.breakpoint.lgAndUp" id="links" align-self="end" class="pl-0 float-right pt-md-8 pt-lg-6 pr-md-4 header-links text-right justify-space-around">
          <a class="ma-1 px-xl-2 px-lg-1 text-center" href="https://github.com/svengeance" target="_blank">
            <v-icon color="blue">{{ icons.github }}</v-icon>
            <p>GitHub</p>
          </a>
          <a class="ma-1 px-xl-2 px-lg-1 text-center" href="https://www.linkedin.com/in/stevevernyi/" target="_blank">
            <v-icon color="blue">{{ icons.linkedin }}</v-icon>
            <p>LinkedIn</p>
          </a>
          <a class="ma-1 px-xl-2 px-lg-1 text-center" href="https://twitter.com/SvenVernyi" target="_blank">
            <v-icon color="blue">{{ icons.twitter }}</v-icon>
            <p>Twitter</p>
          </a>
        </v-col>
      </v-row>
    </v-container>
    <v-divider />
  </header>
</template>

<style lang="scss" scoped>
  #header {
    background-color: #232323;
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

<script>
import { mdiGithub, mdiLinkedin, mdiTwitter } from '@mdi/js'
export default {
  data: () => {
    return {
      icons: {
        github: mdiGithub,
        linkedin: mdiLinkedin,
        twitter: mdiTwitter
      }
    }
  }
}
</script>
