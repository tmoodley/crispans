
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

    var customerCategory = {
      CategoryId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customercategories/', customerCategory)
      .then(function (response) {
        return response.data;
      })
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
    if (state.company.customerCategories == null) {
      state.company.customerCategories = []
    }
    var customerCategory = {
      CategoryId: category[0].id,
      CustomerId: state.company.id
    } 
    state.company.customerCategories.push(customerCategory);
  },
  removeCategory(state, category) {
    var index = state.company.categories.indexOf(x => x.name === category);
    state.company.customerCategories.splice(index, 1);
  },
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
