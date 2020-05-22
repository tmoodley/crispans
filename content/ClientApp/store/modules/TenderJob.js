
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
    var jobCategory = {
      CategoryId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/jobcategories/', jobCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeCategory({ commit }, payload) {
    return axios
      .delete('/portal/api/jobcategories/?categoryId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addCertification({ commit }, payload) {
    var customerCategory = {
      CertificationId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customercertifications/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeCertification({ commit }, payload) {
    return axios
      .delete('/portal/api/customercertifications/?certificationId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addCapability({ commit }, payload) {
    var customerCategory = {
      CapabilityId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customercapabilities/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeCapability({ commit }, payload) {
    return axios
      .delete('/portal/api/customercapabilities/?capabilityId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addCompanyType({ commit }, payload) {
    debugger
    var jobCategory = {
      CompanyTypeId: payload.category[0].id,
      CompanyType: payload.category[0],
      JobId: payload.id
    }

    return axios
      .post('/portal/api/JobCompanyTypes/', jobCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeCompanyType({ commit }, payload) {
    return axios
      .delete('/portal/api/jobCompanyTypes/?CompanyTypeId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addFileType({ commit }, payload) {
    var customerCategory = {
      FileTypeId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerfileTypes/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeFileType({ commit }, payload) {
    return axios
      .delete('/portal/api/customerFileTypes/?FileTypeId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addIndustry({ commit }, payload) {
    var jobCategory = {
      IndustryId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/jobIndustries/', jobCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeIndustry({ commit }, payload) {
    return axios
      .delete('/portal/api/jobIndustries/?IndustryId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addMachine({ commit }, payload) {
    var jobCategory = {
      MachineId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/jobMachines/', jobCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeMachine({ commit }, payload) {
    return axios
      .delete('/portal/api/jobMachines/?machineId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addMaterial({ commit }, payload) {
    var jobCategory = {
      MaterialId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/jobMaterials/', jobCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeMaterial({ commit }, payload) {
    return axios
      .delete('/portal/api/jobMaterials/?MaterialId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addNaics({ commit }, payload) {
    var jobCategory = {
      NaicsId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/jobNaics/', jobCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeNaics({ commit }, payload) {
    return axios
      .delete('/portal/api/jobNaics/?NaicsId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
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
    var index = state.company.customerCategories.indexOf(x => x.name === category);
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
