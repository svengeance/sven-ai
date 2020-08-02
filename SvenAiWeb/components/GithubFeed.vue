<template>
  <v-sheet elevation="10" class="root" height="100vh">
    <div class="container">
      <div class="header">
        <div class="github-card" data-github="svengeance" data-width="400" data-height="" data-theme="default" />
      </div>
      <v-divider />
      <div class="body">
        <p>Body</p>
      </div>
      <v-divider />
      <div>
        <p>Footer</p>
      </div>
    </div>
  </v-sheet>
</template>

<style scoped>

</style>

<script>
export default {
  mounted() {
    const recaptchaScript = document.createElement('script')
    recaptchaScript.setAttribute('src', 'https://cdn.jsdelivr.net/github-cards/latest/widget.js')
    document.head.appendChild(recaptchaScript)
  }
}
</script>
