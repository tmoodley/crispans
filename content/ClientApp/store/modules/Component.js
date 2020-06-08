import axios from 'axios'
// initial state
const state = {
  component: []
}

// getters
const getters = {
  component: (state) => {
    return state.component
  }
}

// actions
const actions = {
  getComponent({ commit }, payload) {
    debugger;

    return axios
      .get('/portal/api/components/' + payload)
      .then(function (response) { 
        commit('setComponent', response.data);
        return response.data;
      })
  }
}


// mutations
const mutations = {
  setComponent(state, component) {
    state.component = component
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
