<template>
  <v-row class="justify-center mx-0">
    <v-col cols="12" md="9">
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
