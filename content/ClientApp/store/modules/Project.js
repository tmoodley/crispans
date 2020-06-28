import axios from 'axios'
// initial state
const state = {
  project: '',
  projects: []
}

// getters
const getters = {
  project: (state) => {
    return state.project
  },
  projects: (state) => {
    return state.projects
  }
}

// actions
const actions = {
  getProject({ commit }, payload) {
    return axios
      .get('/portal/api/projects/' + payload.id)
      .then(function (response) {
        commit('setProject', response.data);
        return response.data;
      })
  },
  getProjects({ commit }, payload) { 
    return axios
      .get('/portal/api/Projects/GetProjects/?id=' + payload.company.id)
      .then(function (response) {
        commit('setProjects', response.data);
        return response.data;
      })
  }
}


// mutations
const mutations = {
  setProject(state, project) {
    state.project = project
  },
  setProjects(state, projects) {
    state.projects = projects
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
