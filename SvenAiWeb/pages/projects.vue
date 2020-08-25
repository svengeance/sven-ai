<template>
  <v-row class="card-container">
    <v-col :cols="cardColumns" v-for="project in projects" :key="project.name">
      <v-card class="mx-4">
        <v-list-item three-line>
          <v-list-item-avatar tile>
            <v-img :src="project.icon" contain />
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title class="headline">
              {{ project.name }}
            </v-list-item-title>
            <v-list-item-subtitle>{{ project.subtitle }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-img :src="project.mainImage" contain height="300" />

        <v-card-text>
          <span class="font-weight-bold">Goal: </span>{{ project.goal }}
        </v-card-text>

        <v-card-actions>
          <v-btn text color="blue text--darken-1">
            Read More
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<style lang="scss" scoped>
  .card-container {
    padding: 0px 5vw;
  }
</style>

<script>
export default {
  data () {
    return {
      projects: [
        {
          icon: 'favicon/android-chrome-192x192.png',
          name: 'Sven.ai',
          subtitle: 'Modern, Progressive Web App Serving as my Personal Website',
          mainImage: '/images/projects/sven-ai/techstack.png',
          goal: 'Learn a new frontend framework, as well as to learn some of the the modern web application features such as Service Side Rendering, Progressive Web Apps, as well as learning how to perform Search Engine Optimization'
        },
        {
          icon: 'images/projects/ef-core/icon.png',
          name: 'Entity Framework Core',
          subtitle: 'The Motherload of all .NET ORMs that I Enjoy Contributing to',
          mainImage: '/images/projects/ef-core/repo-summary.png',
          goal: 'Work with highly skilled professionals, to learn better how to use one of the most complex and customizable tools for database operations in C#, and to do what I can to make Entity Framework the best it can be'
        },
        {
          name: 'Select Sires - Bull Search',
          icon: 'images/projects/bull-search/icon.png',
          subtitle: `Industry's Leading Search Tool, Built With Pure Performance in Mind`,
          mainImage: 'images/projects/bull-search/bsw-grid.png',
          goal: 'Produce a Search Tool that beats out all of our competitors by using the latest technologies .NET and Angular has to offer and build a high-performance, highly optimized tool that is capable of serving requests of any complexity that scales for any number of users'
        },
        {
          name: 'Various Other Open-Source Projects',
          icon: 'images/projects/open-source/icon.png',
          subtitle: 'Projects I Have Used and Found Value, and in Return, Contributed to',
          mainImage: 'images/projects/open-source/pull-requests.png',
          goal: 'Identify areas in projects where I may be of assistance in order to give back to the open source community, from which we all graciously borrow. Sometimes to fulfill a missing gap in a product that I have as an immediate need'
        }
      ]
    }
  },
  computed: {
    cardColumns() {
      return this.$vuetify.breakpoint.smAndDown
        ? 12
        : this.$vuetify.breakpoint.lgAndDown
          ? 6
          : 4
    }
  },
  head() {
    return {
      title: 'Past Projects'
    }
  }
}
</script>
