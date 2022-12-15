import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
// import { FontAwesomeIcon } from '../FontAwesome/fontawesome-free-6.2.1-web'
// import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

// import {TempusDominus} from "@eonasdan/tempus-dominus";
// import {FontawesomeCore} from "@fortawesome/fontawesome-svg-core";
// import {FontawesomeBrands} from "@fortawesome/free-brands-svg-icons";
// import {FontawesomeRegular} from "@fortawesome/free-regular-svg-icons";
// import {FontawesomeSolid} from "@fortawesome/free-solid-svg-icons";
// import { Popper } from "@popperjs/core";
// The main submodule:
// import addDays from 'date-fns/addDays'

// Import Bootstrap and BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'bootstrap-vue/dist/bootstrap-vue-icons.min.js'
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
// Vue.use(addDays)
// Vue.use(FontAwesomeIcon)
// Vue.use('moment')
// Vue.use('moment-timezone')
// //use tempus dominus
// Vue.use('tempus-dominus')
// Vue.use('vue-datetime-picker')
Vue.use('popper.js')



// Vue.use(FontAwesomeIcon)


Vue.config.productionTip = false

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
