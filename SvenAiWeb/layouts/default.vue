<template>
  <v-app dark>
    <v-container fluid class="py-0">
      <v-row>
        <v-col order="1" class="pa-0">
          <Header />
          <v-tabs background-color="transparent">
            <v-tab nuxt to="/about">
              About
            </v-tab>
            <v-tab nuxt to="/unique-projects">
              Cool Projects
            </v-tab>
            <v-tab nuxt to="/work-experience">
              Work Experience
            </v-tab>
            <v-tab nuxt to="/languages-and-tooling">
              Languages &amp; Tools
            </v-tab>
            <v-tab nuxt to="/recent-posts">
              Recent Blog Posts
            </v-tab>
          </v-tabs>
          <v-main>
            <v-container>
              <nuxt />
            </v-container>
          </v-main>
        </v-col>
        <v-col cols="2" order="2" class="pa-0">
          <GithubFeed class=".d-inline-block" />
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>
