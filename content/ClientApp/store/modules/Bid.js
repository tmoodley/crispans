import axios from 'axios'
// initial state
const state = {
  bid: []
}

// getters
const getters = {
  bid: (state) => {
    return state.bid
  }
}

// actions
const actions = {
  getBid({ commit }, payload) {
    
    return axios
      .get('/portal/api/pobids/' + payload)
      .then(function (response) {
        debugger;
        commit('setBid', response.data);
        return response.data;
      })
  }
}


// mutations
const mutations = {
    setBid(state, bid) {
      state.bid = bid
    }
  }

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
