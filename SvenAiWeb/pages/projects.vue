<template>
  <v-row class="card-container mx-0">
    <v-col v-for="(project, index) in projects" :key="project.name" :cols="cardColumns">
      <v-card :class="{ 'card-back': isFlipped(index)}" height="550px" class="mx-4 card">
        <v-list-item three-line>
          <v-list-item-avatar tile>
            <v-img :src="require('~/assets/' + project.icon + '?size=48')" :alt="project.name + ' Icon'" contain />
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title class="headline">
              {{ project.name }}
            </v-list-item-title>
            <v-list-item-subtitle v-html="project.subtitle"></v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <div v-if="isFlipped(index)" class="pt-4 card-text-container" @touchmove.stop>
          <perfect-scrollbar :options="cardScrollOptions">
            <v-card-text class="card-text" v-html="project.description" />
          </perfect-scrollbar>
        </div>
        <div v-else>
          <v-img class="mx-4" :src="require('~/assets/' + project.mainImage + '?size=600')" :height="cardImageHeight" :alt="project.name + ' Image'" contain />

          <v-card-text>
            <span class="font-weight-bold">Goal: </span>
            <span v-html="project.goal"></span>
          </v-card-text>
        </div>

        <v-card-actions class="card-actions">
          <v-btn text color="blue text--darken-1" @click="flipCard(index)">
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

    .ps {
      height: 340px;
    }
  }
</style>

<script>
export default {
  data () {
    return {
      cardScrollOptions: {
        wheelPropagation: false,
        handlers: [ 'wheel', 'touch', 'keyboard' ]
      },
      flippedCards: [],
      projects: [
                {
          icon: 'projects/husky/icon.png',
          name: 'Husky',
          subtitle: 'World\'s First Native Cross-Platform Any-App Installer, Based on .NET Core',
          mainImage: 'projects/husky/installer-logo.png',
          goal: 'Utilizing techniques not found in almost any other DotNet project (and certainly no other installer), produce the world\'s first installer that is open source, extensible, and <b>easy to use</b>, all with our very own C#/DotNet. <br /> This project uses an experimental, reflection-less CoreRT/NativeAoT runtime to deliver small binary files that run natively with zero software dependencies.',
          description: `
          <p>
            Like many developers before me, I had an idea born because I observed a lack of easy-to-use tooling in some area, and I thought that I could do it better.
          </p>
          <p>
            Husky is the world's first <i>Native</i> C# installer. Normally, C# requires an existing runtime on the user's sytem - in prior versions of Windows, this was even installed as part of the operating system.
            With .NET Core, no such existing runtime exists, and so a .NET Core-based installer would seem impossible, as the 50MB+ runtime (self-contained or not) would preclude that idea.
          </p>
          <p>
            The capability for Husky was inspired by Michal Strehovský, who showed that <a href="https://medium.com/@MStrehovsky/building-a-self-contained-game-in-c-under-8-kilobytes-74c3cf60ea04">it is indeed possible to build a C# Snake game in under 8kb</a>.
            Simple? No, but doable. While Husky has no intentions on replacing the core libraries, or foregoing a GC by avoiding heap allocations altogether, Husky sheds the capability of all reflection and dynamic code generation in order to reduce its binary size
            (both of which are critical for most existing high-performance libraries).
          </p>
          <p>
            Husky offers several capabilities not found in any other installer. A web-based (mini-electron) UI, a YAML-first installer workflow configuration, integrated & dockerized E2E testing - these are modern conceps that 
            other installers based on antiquated technologies can not offer as easily as one built on the latest .NET Core SDKs. <br />
            My dream with Husky is to be <i>the</i> open-source installer that developers first think about when contemplating how to deliver their products.
          </p>
          `
        },
        {
          icon: 'projects/sven-ai/icon.png',
          name: 'Sven.ai',
          subtitle: 'Modern, Progressive Web App Serving as my Personal Website',
          mainImage: 'projects/sven-ai/techstack.png',
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
          icon: 'projects/blog/icon.png',
          name: 'Sven.ai Blog',
          subtitle: 'First Foray Into Jamstack With Hugo and Github Pages',
          mainImage: 'projects/blog/blog-entry.png',
          goal: 'Spin up my own blog as a creative outlet to document some adventures I encounter while developing, and learn a new webstack in the process. <br /> <br /> See for yourself <a target="_blank" href="https://blog.sven.ai">here!</a>',
          description: `
          <p>
            What started off as series of thoughts akin to <i>"Man, I should really write that down"</i> culminated into this project. Going in, I didn't really understand what one "typically" did for a blog - 
            how were pages managed, how easy was it to write them, where was it deployed, <i>how in the heck did people make blogs so fast?</i>
          </p>
          <p>
            The answer to the above questions was found in the Jamstack technology soup - being able to efficiently write new pages using some CLI-assisted tool, and then publishing the result 
            as a series of statically-generated pages which can be hosted by any provider. My blog itself is hosted via Github Pages - I was surprised, and very pleased, with how fast everything is. 
            Turns out SPAs aren't necessarily the answer for everything these days.
          </p>
          <p>
            Blog aside, I did have a little bit of fun trickery while setting up the comment system via Remark42. I wanted an open-source system that had free self-hosting options (honestly - not expecting a whole bunch of comments!), 
            but of course the self-hosting bit means more <i>fun</i> in the setup. Remark42 offered everything I needed, and is hosted via a docker container. It lets users comment from a plethora of accounts - even anonymously 
            (which is cautiously monitored by getting an email per-comment..).
          </p>
          `
        },
        {
          icon: 'projects/ef-core/icon.png',
          name: 'Entity Framework Core',
          subtitle: 'An opportunity to work with the most complete open-source .NET ORM and understand its internals',
          mainImage: 'projects/ef-core/ef-repo.png',
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
          icon: 'projects/bull-search/icon.png',
          subtitle: `Industry's Leading Search Tool, Exposing Over 20 Million <b>Filterable</b> Datapoints in Milliseconds`,
          mainImage: 'projects/bull-search/bsw-grid.png',
          goal: 'Produce a Search Tool that beats out all of our competitors by using the latest technologies .NET and Angular has to offer and build a high-performance, highly optimized tool that is capable of serving requests of any complexity that scales for any number of users <br /> </br /> See for yourself at <a href="https://www.selectsires.com/bull-search">https://selectsires.com/bull-search</a>',
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
          icon: 'projects/open-source/icon.png',
          subtitle: 'Projects I Have Used and Found Value, and in Return, Contributed to',
          mainImage: 'projects/open-source/pull-requests.png',
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
  head() {
    return {
      title: 'Past Projects'
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
  }
}
</script>
