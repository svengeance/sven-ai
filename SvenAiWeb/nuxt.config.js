import colors from 'vuetify/es5/util/colors'

const isDev = () => process.env.DEPLOY_ENV == 'local';
const apiProxyConfig = () => isDev() ? 'http://localhost:9001/api' : 'https://sven.ai/api';
const blogProxyConfig = () => isDev() ? 'http://localhost:4000/blog' : 'https://sven.ai/blog';

export default {
  components: true,

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
      { hid: 'description', name: 'description', content: 'Professional/portfolio website for Stephen Vernyi (Sven)' },
      { hid: 'author', name: 'author', content: 'Sven' },
      { hid: 'publisher', name: 'publisher', content: 'Sven' },
      { hid: 'apple-mobile-web-app-title', name: 'apple-mobile-web-app-title', content: 'Sven | About' },
      { hid: 'theme-color', name: 'theme-color', content: 'dark' },
      { hid: 'og:title', name: 'og:title', content: 'Sven Vernyi' },
      { hid: 'og:description', name: 'og:description', content: 'Professional/portfolio website for Stephen Vernyi (Sven)' },
      { hid: 'og:type', name: 'og:type', content: 'Website' },
      { hid: 'og:url', name: 'og:url', content: 'https://sven.ai' },
      { hid: 'og:image', name: 'og:image', content: '/mally_avatar.png' },
      { hid: 'og:locale', name: 'og:locale', content: 'en-EN' },
      { hid: 'og:site_name', name: 'og:site_name', content: 'Sven | About' },
      { hid: 'twitter:card', name: 'twitter:card', content: 'summary' },
      { hid: 'twitter:site', name: 'twitter:site', content: 'SvenVernyi' },
      { hid: 'twitter:creator', name: 'twitter:creator', content: 'SvenVernyi' },
      { hid: 'twitter:title', name: 'twitter:title', content: 'Sven | About' },
      { hid: 'twitter:description', name: 'twitter:description', content: 'Professional/portfolio website for Stephen Vernyi (Sven)' },
      { hid: 'twitter:image', name: 'twitter:image', content: '/mally_avatar.png' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon/favicon.ico' },
      { rel: "apple-touch-icon", sizes: "180x180", href: "/favicon/apple-touch-icon.png" },
      { rel: "icon", type: "image/png", sizes: "32x32", href: "/favicon/favicon-32x32.png" },
      { rel: "icon", type: "image/png", sizes: "16x16", href: "/favicon/favicon-16x16.png" },
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
    // '@nuxtjs/eslint-module',
    '@nuxtjs/vuetify',
    '@nuxt/typescript-build',
    '@nuxtjs/style-resources',
    '@nuxtjs/google-analytics',
    '@aceforth/nuxt-optimized-images'
  ],
  /*
  ** Nuxt.js modules
  */
  modules: [
    // Doc: https://axios.nuxtjs.org/usage
    '@nuxtjs/pwa',
    '@nuxt/http',
    '@nuxtjs/proxy',
    '@nuxtjs/sitemap'
  ],

  /*
  * Image Optimizer Module Configuration
  * https://marquez.co/docs/nuxt-optimized-images/configuration
  */
  optimizedImages: {
    optimizeImages: true,
    optimizeImagesInDev: true,
    responsive: {
      format: 'png'
    }
  },

  /*
  ** Google Analytics module configuration
  ** See https://github.com/nuxt-community/analytics-module
  */
  googleAnalytics: {
    id: 'UA-178644638-2'
  },

  /*
  ** Sitemap  module configuration
  ** See https://github.com/nuxt-community/sitemap-module
  */
  sitemap: {
    // options
  },

  /*
  ** Http module configuration
  ** See https://http.nuxtjs.org/guide/
  */
  http: {
    proxy: true
  },
  proxy: [
    apiProxyConfig(),
    blogProxyConfig()
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
    },
    defaultAssets: {
      icons: false
    },
    icons: {
      iconfont: 'mdiSvg'
    },
    treeShake: true
  },
  /*
  ** Build configuration
  */
  build: {
    /*
    ** You can extend webpack config here
    */
    // extend (config, ctx) {
    //   if (ctx.isDev && ctx.isClient) {
    //     config.module.rules.push({
    //       enforce: 'pre',
    //       test: /\.(js|vue)$/,
    //       loader: 'eslint-loader',
    //       exclude: /(node_modules)/,
    //       options: {
    //         fix: true
    //       }
    //     })
    //   }
    // },
    // analyze: true
  }
}
