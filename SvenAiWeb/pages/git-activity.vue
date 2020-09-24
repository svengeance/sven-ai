<template>
  <v-row class="justify-center">
    <v-col cols="10" md="9">
      <GithubFeed />
    </v-col>
  </v-row>
</template>

<script>
export default {
  head() {
    return {
      title: 'Git Activity'
    }
  }
}
</script>
