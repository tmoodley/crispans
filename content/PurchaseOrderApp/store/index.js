import Vue from 'vue'
import Vuex from 'vuex'
import company from './modules/Company' 

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  modules: {
    company
  },
  strict: debug,
})
