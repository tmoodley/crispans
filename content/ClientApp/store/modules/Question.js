import axios from 'axios'
// initial state
const state = {
  question: []
}

// getters
const getters = {
  question: (state) => {
    return state.question
  }
}

// actions
const actions = {
  getQuestion({ commit }, payload) {
    debugger;

    return axios
      .get('/portal/api/questions/' + payload)
      .then(function (response) {
        debugger;
        commit('setQuestion', response.data);
        return response.data;
      })
  }
}


// mutations
const mutations = {
  setQuestion(state, question) {
    state.question = question
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
