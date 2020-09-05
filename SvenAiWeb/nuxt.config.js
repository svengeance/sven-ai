import colors from 'vuetify/es5/util/colors'

const proxyConfig = () => process.env.DEPLOY_ENV == 'local' ? 'http://localhost:9001/api' : 'https://sven.ai/api';

export default {
  components: true,
  mode: 'universal',
  
  router: {
    extendRoutes(routes, resolve) {
      routes.push({
        name: 'about-default',
        path: '',
        component: resolve(__dirname, 'pages/about.vue')
      })  
    }
  },
  /*
  ** Headers of the page
  */
  head: {
    titleTemplate: 'Sven | %s',
    title: 'Home',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: 'Professional/portfolio website for Stephen Vernyi (Sven)' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon/favicon.ico' },
      { rel: "apple-touch-icon", sizes: "180x180", href: "/favicon/apple-touch-icon.png" },
      { rel: "icon", type: "image/png", sizes: "32x32", href: "/favicon/favicon-32x32.png" },
      { rel: "icon", type: "image/png", sizes: "16x16", href: "/favicon/favicon-16x16.png" },
      { rel: "manifest", href: "/favicon/site.webmanifest" }
    ]
  },
  /*
  ** Customize the progress-bar color
  */
  loading: { color: '#fff' },
  /*
  ** Global CSS
  */
  css: [
    '@styles/globals.scss'
  ],

  /*
  **  https://github.com/nuxt-community/style-resources-module
  */
  styleResources: {
    scss: [ '~styles/globals.scss' ]
  },

  /*
  ** Plugins to load before mounting the App
  */
  plugins: [
    '@/plugins/perfect-scrollbar.js'
  ],
  /*
  ** Nuxt.js dev-modules
  */
  buildModules: [
    // Doc: https://github.com/nuxt-community/eslint-module
    '@nuxtjs/eslint-module',
    '@nuxtjs/vuetify',
    '@nuxt/typescript-build',
    '@nuxtjs/style-resources',
  ],
  /*
  ** Nuxt.js modules
  */
  modules: [
    // Doc: https://axios.nuxtjs.org/usage
    '@nuxtjs/pwa',
    '@nuxt/http',
    '@nuxtjs/proxy'
  ],
  /*
  ** Http module configuration
  ** See https://http.nuxtjs.org/guide/
  */
  http: {
    proxy: true
  },

  proxy: [
    proxyConfig()
  ],

  /*
  ** vuetify module configuration
  ** https://github.com/nuxt-community/vuetify-module
  */
  vuetify: {
    customVariables: ['~/styles/globals.scss'],
    theme: {
      dark: true,
      themes: {
        dark: {
          primary: colors.blue.darken2,
          accent: colors.grey.darken3,
          secondary: colors.amber.darken3,
          info: colors.teal.lighten1,
          warning: colors.amber.base,
          error: colors.deepOrange.accent4,
          success: colors.green.accent3
        }
      }
    }
  },
  /*
  ** Build configuration
  */
  build: {
    /*
    ** You can extend webpack config here
    */
    extend (config, ctx) {
      if (ctx.isDev && ctx.isClient) {
        config.module.rules.push({
          enforce: 'pre',
          test: /\.(js|vue)$/,
          loader: 'eslint-loader',
          exclude: /(node_modules)/,
          options: {
            fix: true
          }
        })
      }
    }
  }
}
