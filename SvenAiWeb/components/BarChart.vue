<template>
  <div class="container">
    <p class="text-md-h5 text-sm-h6 text-center pb-4 text-decoration-underline">
      {{ title }}
    </p>
    <v-sparkline
      :value="values"
      :labels="labels"
      :gradient="gradient"
      :label-size="labelSize"
      :line-width="labelSize - 2"
      smooth="10"
      show-labels
      type="bar"
    />
  </div>
</template>

<script>
export default {
  props: {
    title: {
      type: String
    },
    values: {
      type: Array
    },
    labels: {
      type: Array
    }
  },
  data() {
    return {
      gradient: ['deepskyblue', 'dodgerblue', 'royalblue', 'darkblue']
    }
  },
  computed: {
    labelSize() {
      return this.$vuetify.breakpoint.smAndDown
        ? 10
        : this.$vuetify.breakpoint.mdAndDown
          ? 8
          : 5
    }
  },
  mounted() {
    console.log(this.values)
  }
}
</script>
