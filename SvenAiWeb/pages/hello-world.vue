<template>
  <v-layout class="content" d-flex flex-column>
    <v-row class="mx-0">
      <v-col offset="2" cols="8">
        <div @click="handlePup" ref="pup-container" id="pup-container" class="mx-auto"></div>
        <p class="text-center mb-0 text-h4 grey--text text--lighten-3">Hey! I'm Sven</p>
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
      <v-col offset="2" cols="8" offset-lg="1" lg="2">
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
      <v-col offset="2" cols="8" offset-lg="1" lg="2">
        <p class="text-center text-h6">
          I Enjoy...
        </p>
        <p class="text-center text-body-2">
          Competitive video games (League of Legends, Starcraft II, Apex Legends), cute animals, working out, fresh ocean breezes, and spending lots quality of time with my significant other.
        </p>
        <p class="text-center text-body-2">
          Developing for me is not only my career, it's a hobby that I can't seem to put down. I spend a good bit of freetime engaging with strong developers and learning about their own unique problems, while experimenting on my own with the latest and greatest advancements in the .NET world.
        </p>
      </v-col>
    </v-row>
  </v-layout>
</template>

<style lang="scss" scoped>
  #pup-container {
    cursor: pointer;
    width: 200px;
    height: 200px;
  }
</style>

<script>
import lottie from 'lottie-web/build/player/lottie';
export default {
  head() {
    return {
      title: 'Hello World'
    }
  },
  data: () => ({
    popupFrame: 59,
    hiddenFrame: 110
  }),
  methods: {
    handlePup: function() {
      if (!this.player)
        return;

      if (this.player.firstFrame == 0)
        this.hidePup()
      else if (this.player.firstFrame == this.popupFrame)
        this.showPup()
    },
    hidePup: function() {
      this.player.playSegments([this.popupFrame, this.hiddenFrame], true);
    },
    showPup: function() {
      this.player.playSegments([0, this.popupFrame], true)
    }
  },
  mounted: function() {
    this.$nextTick(() => {
        this.player = lottie.loadAnimation({
          container: this.$refs['pup-container'],
          renderer: 'svg',
          autoplay: false,
          loop: false,
          path: 'husky.json'
        });
        setTimeout(() => {
          this.showPup()
        }, 1000);
      })
  }
}
</script>
