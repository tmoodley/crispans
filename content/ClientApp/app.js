import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import VueFormWizard from 'vue-form-wizard'
import 'vue-form-wizard/dist/vue-form-wizard.min.css'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import Vue2Dropzone from 'vue2-dropzone'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import VueSweetalert2 from 'vue-sweetalert2'

// If you don't need the styles, do not connect
import 'sweetalert2/dist/sweetalert2.min.css'

import 'vue2-perfect-scrollbar/dist/vue2-perfect-scrollbar.css'
import wysiwyg from 'vue-wysiwyg'
import PerfectScrollbar from 'vue2-perfect-scrollbar'
import Vue2Filters from 'vue2-filters'
import VueCurrencyInput from 'vue-currency-input'
import VueFilterDateFormat from 'vue-filter-date-format'
import Vuelidate from 'vuelidate'

Vue.use(VueFilterDateFormat)
Vue.use(VueCurrencyInput)
Vue.use(Vue2Filters)
Vue.use(VueSweetalert2)
Vue.use(PerfectScrollbar)
Vue.use(wysiwyg, {}) // config is optional. more below
Vue.use(Vue2Dropzone)
Vue.use(BootstrapVue)
Vue.use(VueFormWizard)
Vue.use(Vuelidate)
// Registration of global components
Vue.component('icon', FontAwesomeIcon)

// Add a request interceptor
axios.interceptors.request.use(function (config) {
  let user = JSON.parse(localStorage.getItem('user'));
  if (user != null) {
    config.headers.Authorization = 'Bearer ' + user.token;
  }

  return config;
})

axios.interceptors.response.use(undefined, function (err) {
  return new Promise(function (resolve, reject) {
    if (err.status === 401 && err.config && !err.config.__isRetryRequest) {
      // if you ever get an unauthorized, logout the user
      this.$store.dispatch(AUTH_LOGOUT)

      // you can also redirect to /login if needed !
    }
    throw err;
  });
});

Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
