import Vue from 'vue'
import Vuex from 'vuex'
import company from './modules/Company'
import job from './modules/Job'
import purchaseOrder from './modules/PurchaseOrder'
import product from './modules/Product'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  modules: {
    company,
    purchaseOrder,
    job,
    product
  },
  strict: debug,
})
