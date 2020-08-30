<template>
  <v-row class="card-container mx-0">
    <v-col :cols="cardColumns" v-for="(project, index) in projects" :key="project.name">
      <v-card :class="{ 'card-back': isFlipped(index)}" height="550px" class="mx-4 card">
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

        <div v-if="isFlipped(index)" v-touch:started.disablePassive="test" v-touch:moving.disablePassive="test" v-touch:stop.disablePassive="test" class="pt-4 card-text-container">
          <perfect-scrollbar>
            <v-card-text v-html="project.description" class="card-text" />
          </perfect-scrollbar>
        </div>
        <div v-else>
          <v-img :src="project.mainImage" :height="cardImageHeight" contain />

          <v-card-text>
            <span class="font-weight-bold">Goal: </span>{{ project.goal }}
          </v-card-text>
        </div>

        <v-card-actions class="card-actions">
          <v-btn @click="flipCard(index)" text color="blue text--darken-1">
            Read More
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<style lang="scss" scoped>
  .card {
    transition: transform 0.5s;
    transform-style: preserve-3d;
    z-index: 9999;
  }
  .card-back {
    transform: rotateY(180deg) scaleX(-1);
  }
  .card-actions {
    bottom: 0;
    position: absolute;
  }
  .card-container {
    padding: 0px 5vw 48px;
  }
  .card-text-container {
    position: relative;
    height: 400px;

    .ps {
      height: 400px;
    }
  }
  .card-text {
    position: relative;
    height: 400px;
  }
</style>

<script>
export default {
  data () {
    return {
      flippedCards: [],
      projects: [
        {
          icon: 'favicon/android-chrome-192x192.png',
          name: 'Sven.ai',
          subtitle: 'Modern, Progressive Web App Serving as my Personal Website',
          mainImage: '/images/projects/sven-ai/techstack.png',
          goal: 'Learn a new frontend framework, as well as to learn some of the the modern web application features such as Service Side Rendering, Progressive Web Apps, as well as learning how to perform Search Engine Optimization',
          description: `
          <p>
            Sven.ai is fast, fully modern progressive webapp. In my career and personal projects I've previously used Angular for development,
            however this website is my first foray into development with VueJS. I chose it purely out of a closer approximation to Angular, and also because
            I have a personal distaste for Facebook as an organization.
          </p>
          <p>
            This project features many modern, well-built concepts such as dockerized deployments via CI/CD pipeline, as well as a frontend (Vue) and 
            backend (ASP.Net Core) that are on the latest available versions. Not only that, the server the application is deployed on is a blank-slate
            linux box that I rented and configured for deployment.
          </p>
          <p>
            The layout for SvenAi is inspired by the League of Legends client, and serves as a strong connection between me and my website that
            has me delighted to work on it.
          </p>
          `
        },
        {
          icon: 'images/projects/ef-core/icon.png',
          name: 'Entity Framework Core',
          subtitle: 'The Motherload of all .NET ORMs that I Enjoy Contributing to',
          mainImage: '/images/projects/ef-core/ef-repo.png',
          goal: 'Work with highly skilled professionals, to learn better how to use one of the most complex and customizable tools for database operations in C#, and to do what I can to make Entity Framework the best it can be',
          description: `
          <p>
            EF is a kind of a dream project for me. I view databases as the end-game for any company. <i>Every</i> organization will ultimately need a place to house data, and of course, need an accommodating tool to
            read that data. Given such a core necessity, EF is something that should strive to be sleek, functional, and easy to use; I believe it succeeds in every regard, and is why I highly value
            any contribution that I am able to make to such a product.
          </p>
          <p>
            Aside from the technical challenges encountered when working on something of this complexity, I also enjoy the opporunity to work with the skilled project team. They have been extremely patient with my
            questions and clarifications, and offer guidance to help me succeed.
          </p>
          `
        },
        {
          name: 'Select Sires - Bull Search',
          icon: 'images/projects/bull-search/icon.png',
          subtitle: `Industry's Leading Search Tool, Built With Pure Performance in Mind`,
          mainImage: 'images/projects/bull-search/bsw-grid.png',
          goal: 'Produce a Search Tool that beats out all of our competitors by using the latest technologies .NET and Angular has to offer and build a high-performance, highly optimized tool that is capable of serving requests of any complexity that scales for any number of users',
          description: `
          <p>
            In my time at Select Sires, I have been a part of 4 different Bull Search tools, each with their own individual successes and failures, but <i>none</i> were fully a success.
          </p>
          <p>
            This particular Bull Search was the first iteration that I led API development on, and participated <b>fully</b> in the product lifecycle. From product management, to UI/UX reviews, PMO requirements gathering.. I was able to
            have a hand in most aspects and help guide the project to be a well-engineered and modern search app.
          </p>
          <p>
            Built with a .NET Core backend, I teamed up with two very talented frontend developers to introduce a completely new approach of data retrieval from the API. Not only that, I was able to come up with a data structure
            to house an extremely large in-memory cache that reduced our memory footprint from 800Mb to 100Mb compared to our prior implementation, while massively improving performance of searching and filtering within the API.
          </p>
          `
        },
        {
          name: 'Various Other Open-Source Projects',
          icon: 'images/projects/open-source/icon.png',
          subtitle: 'Projects I Have Used and Found Value, and in Return, Contributed to',
          mainImage: 'images/projects/open-source/pull-requests.png',
          goal: 'Identify areas in projects where I may be of assistance in order to give back to the open source community, from which we all graciously borrow. Sometimes to fulfill a missing gap in a product that I have as an immediate need',
          description: `
          <p>
            Often times I come across projects that fulfilled a need while surpassing my expectations, which become staples of my workflow.
            Two example of projects that have done so are <a href="https://github.com/GitTools/GitVersion">GitVersion</a> and the <a href="https://github.com/rfennell/AzurePipelines/">AzurePipelines suite</a>.
          </p>
          <p>
            If the project is open source and looks to be well maintained and cared for, I will poke around and see how the codebase is architected, as well as look at the current issues to see what scale of work needs done.
            Being able to experience different styles of code, I feel, is extremely thought-provoking and breaks down preconceived notions of best practices when you can see other architectural styles at play.
          </p>
          <p>
            Other times, as was the case with GitVersion, I had a direct need over the course of my day job that the product was <i>just</i> shy of achieving, and I was able to successfully enhance their FOSS application
            while solving a direct business need at my job, while learning as a developer -- best of every world.
          </p>
          `
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
    },
    cardImageHeight() {
      return this.cardColumns === 12
        ? '150px'
        : '250px'
    }
  },
  methods: {
    test(args) {
      args.preventDefault()
      args.stopPropagation()
      args.stopImmediatePropagation()
    },
    flipCard(cardNumber) {
      const existingIndex = this.flippedCards.indexOf(cardNumber)
      if (existingIndex >= 0)
        this.$delete(this.flippedCards, existingIndex)
      else
        this.flippedCards.push(cardNumber)
    },
    isFlipped(cardNumber) {
      return this.flippedCards.includes(cardNumber)
    }
  },
  head() {
    return {
      title: 'Past Projects'
    }
  }
}
</script>
