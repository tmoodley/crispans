import Vue from 'vue'
import Vuex from 'vuex'
import company from './modules/Company'
import purchaseOrder from './modules/PurchaseOrder'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  modules: {
    company,
    purchaseOrder
  },
  strict: debug,
})
