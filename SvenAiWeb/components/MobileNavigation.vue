<template>
  <div id="mobile-nav-overlay">
    <v-icon id="mobile-nav-menu-button" v-if="$vuetify.breakpoint.smAndDown">
      mdi-menu
    </v-icon>

    <v-btn
      color="pink"
      dark
      absolute
      right
      bottom
      fab
    >
      <v-icon>mdi-plus</v-icon>
    </v-btn>
  </div>
</template>

<style lang="scss" scoped>
    #mobile-nav-menu-button {
        left: 2%;
        position: fixed;
        top: 2%;
    }
</style>
