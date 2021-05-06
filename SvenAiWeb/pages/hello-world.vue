<template>
  <v-layout class="content pt-2 pb-8" d-flex flex-column>
    <v-row class="mx-0 mt-16">
      <v-col offset="2" cols="8">
        <img class="mt-16" id="cat" src="~/assets/husky.png" />
        <p class="text-center mt-6 mb-0 text-h4 grey--text text--lighten-3">Hey! I'm Sven</p>
        <p class="text-center pt-0 text-subtitle-1 grey--text text--lighten-2">I like building fast, reliable software that empowers people to express their dreams</p>
      </v-col>
    </v-row>
    <v-row class="mx-0 mt-16 pt-16">
      <v-col offset="2" cols="8" lg="2">
        <p class="text-center text-h6">
          Presently...
        </p>
        <p class="text-center text-body-2">
          I am a solution architect who works directly with stakeholders to best understand their aspirations so that I can reliably deliver software that meets their desires while exceeding expectations.
        </p>
        <p class="text-center text-body-2">
          The best results are delivered by those who truly try to understand not only what is being asked, but the underlying reasons and the value propositions: mutual understanding, respect, and belief creates an inordinately strong desire for success.
        </p>
      </v-col>
      <v-col offset="2" cols="8" lg="2">
        <p class="text-center text-h6">
          In the future...
        </p>
        <p class="text-center text-body-2">
          I aim to enable those around me to succeed in their own goals through example-based leadership that is open, honest, and fair.
        </p>
        <p class="text-center text-body-2">
          To be surrounded by likeminded individuals who have a passion for success, and whose rigorous knowledge <i>forces</i> me to continually better myself as a developer, architect, and leader is my goal.
        </p>
      </v-col>
      <v-col offset="2" cols="8" lg="2">
        <p class="text-center text-h6">
          I Enjoy...
        </p>
        <p class="text-center text-body-2">
          Competitive video games (League of Legends, Starcraft II, Apex Legends), cute animals, working out, and fresh ocean breezes.
        </p>
        <p class="text-center text-body-2">
          Developing for me is not only my career, it's a hobby that I can't seem to put down. I spend a good bit of freetime engaging with strong developers and learning about their own unique problems, while experimenting on my own with the latest and greatest advancements in the .NET world.
        </p>
      </v-col>
    </v-row>
  </v-layout>
</template>

<style lang="scss" scoped>
  #cat {
    border-bottom: 1px solid #ffffffaa;
    display: block;
    margin: auto;
    width: 150px;
  }
</style>

<script>
export default {
  head() {
    return {
      title: 'Hello World'
    }
  }
}
</script>
