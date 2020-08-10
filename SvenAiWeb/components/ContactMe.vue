<template>
  <a href="mailto:sven.vernyi@gmail.com"><img id="contact-me" class="shine" src="~/assets/contact-me-button.svg"></a>
</template>

<style lang="scss" scoped>
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
</style>
