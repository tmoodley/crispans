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

import VueSweetalert2 from 'vue-sweetalert2';

// If you don't need the styles, do not connect
import 'sweetalert2/dist/sweetalert2.min.css';

Vue.use(VueSweetalert2)
import wysiwyg from "vue-wysiwyg"
Vue.use(wysiwyg, {}); // config is optional. more below 
Vue.use(Vue2Dropzone)
Vue.use(BootstrapVue)
Vue.use(VueFormWizard)
// Registration of global components
Vue.component('icon', FontAwesomeIcon)
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
