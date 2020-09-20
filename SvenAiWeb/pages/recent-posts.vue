<template>
  <v-container class="flex-column">
    <v-row>
      <v-col cols="6">
        <v-img :src="featuredBlogPost.featured_image" />
      </v-col>
      <v-col cols="6">
        <div>
          <p class="text-h4">
            {{ featuredBlogPost.title }}
          </p>
        </div>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="3">
        Test
      </v-col>
      <v-col cols="3">
        Test
      </v-col>
      <v-col cols="3">
        Test
      </v-col>
      <v-col cols="3">
        Test
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      featuredBlogPost: { },
      blogPosts: [ ]
    }
  },
  async fetch() {
    const blogContent = await this.$http.$get('/blog/content.json')
    const latestPost = blogContent.posts.splice(0, 1)
    this.featuredBlogPost = latestPost && latestPost[0]
    this.blogPosts = blogContent.posts
  },
  head() {
    return {
      title: 'Recent Posts'
    }
  }
}
</script>
