<template>
  <v-row id="header">
    <v-col cols="3">
      <v-btn class="ma-1 ml-6 mb-n6" color="indigo">
        <v-icon>mdi-email-send</v-icon> Contact me
      </v-btn>
    </v-col>
    <v-col class="px-8" cols="2" offset="7">
      <div class="d-flex d-flex-column justify-space-between">
        <a class="ma-1 text-center" href="https://github.com/svengeance">
          <v-icon color="indigo">mdi-github</v-icon>
          <p class="indigo--text text--lighten-2">GitHub</p>
        </a>
        <a class="ma-1 text-center" href="https://www.linkedin.com/in/stevevernyi/">
          <v-icon color="indigo">mdi-linkedin</v-icon>
          <p class="indigo--text text--lighten-2">LinkedIn</p>
        </a>
        <a class="ma-1 text-center" href="https://twitter.com/SvenVernyi">
          <v-icon color="indigo">mdi-twitter</v-icon>
          <p class="indigo--text text--lighten-2">Twitter</p>
        </a>
      </div>
    </v-col>
    <v-col cols="12" class="pa-0">
      <v-divider />
    </v-col>
  </v-row>
</template>

<style lang="scss">
  #header {
    a {
      text-decoration: none;
    }
  }
</style>
