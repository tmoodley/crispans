
import axios from 'axios'
// initial state
const state = {
  company: []
}

// getters
const getters = {
  company: (state) => {
    return state.company
  }
}

// actions
const actions = {
  getCompany({ commit }, payload) {
    return axios
      .get('/portal/api/customers/' + payload)
      .then(function (response) {
        commit('setCompany', response.data);
        return response.data;
      })
  },
  addCategory({ commit }, payload) {
    commit('addCategory', payload);
  },
  removeCategory({ commit }, payload) {
    commit('removeCategory', payload);
  }
}

// mutations
const mutations = {
  setCompany(state, company) {
    state.company = company
  },
  addCategory(state, category) {
    if (state.company.categories == null) {
      state.company.categories = []
    }
    state.company.categories.push(category);
  },
  removeCategory(state, category) {
    var index = state.company.categories.indexOf(x => x.name === category);
    state.company.categories.splice(index, 1);
  },
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
