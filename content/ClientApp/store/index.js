import Vue from 'vue'
import Vuex from 'vuex'
import company from './modules/Company'
import tenderjob from './modules/TenderJob'
import job from './modules/Job'
import purchaseOrder from './modules/PurchaseOrder'
import product from './modules/Product'
import bid from './modules/Bid'
import question from './modules/Question'
import { alert } from './modules/alert.module'
import { authentication } from './modules/authentication.module'
import { users } from './modules/users.module'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  modules: {
    company,
    tenderjob,
    purchaseOrder,
    job,
    product,
    bid,
    question,
    alert,
    authentication,
    users
  },
  strict: debug,
})
