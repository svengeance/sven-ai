<template>
  <div>
    <v-row id="header" class="site-header-component">
      <v-col cols="12" class="d-flex justify-space-between align-center">
        <a href=""><img id="contact-me" class="shine" src="~/assets/contact-me-button.svg"></a>
        <div class="d-flex flex-column text-center">
          <span class="text-h4 grey--text">Nox</span>
          <span class="text-subtitle-1 grey--text">Member of C# Discord Who Can't Come Up With a Good Tagline</span>
        </div>
        <div class="header-links">
          <a class="ma-1 text-center" href="https://github.com/svengeance" target="_blank">
            <v-icon color="blue darken-1">mdi-github</v-icon>
            <p class="">GitHub</p>
          </a>
          <a class="ma-1 text-center" href="https://www.linkedin.com/in/stevevernyi/" target="_blank">
            <v-icon color="blue darken-1">mdi-linkedin</v-icon>
            <p class="">LinkedIn</p>
          </a>
          <a class="ma-1 text-center" href="https://twitter.com/SvenVernyi" target="_blank">
            <v-icon color="blue darken-1">mdi-twitter</v-icon>
            <p class="">Twitter</p>
          </a>
        </div>
      </v-col>
    </v-row>
    <v-divider />
  </div>
</template>

<style lang="scss">
  .shine {
    animation: Glow 2s ease-in-out 0s infinite alternate;
  }
  @keyframes Glow {
    from {
        filter: brightness(1);
    }
    to {
      filter: brightness(1.3);
    }
  }

  #contact-me:hover {
      cursor: pointer;
      filter: brightness(1.25);
      animation: none;
  }
  #header {
    .header-links a {
      display: inline-block;
      padding: 0px 10px;
      text-decoration: none;
    }
  }
</style>
