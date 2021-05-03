module.exports = {
  root: true,
  env: {
    browser: true,
    node: true
  },
  parserOptions: {
    parser: "babel-eslint",
    sourceType: "module",
    ecmaVersion: 7
  },
  extends: [
    // "@nuxtjs",
    // "plugin:nuxt/recommended"
  ],
  // add your custom rules here
  rules: {
    "space-before-function-paren": ["off", "ignore"],
    "curly": ["off", "ignore"],
    "vue/max-attributes-per-line": ["off", "ignore"]
  }
}