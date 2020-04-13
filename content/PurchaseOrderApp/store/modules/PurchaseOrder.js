
import axios from 'axios'
// initial state
const state = {
  purchaseOrder: []
}

// getters
const getters = {
  purchaseOrder: (state) => {
    return state.purchaseOrder
  }
}

// actions
const actions = {
  getPurchaseOrder({ commit }, payload) {
    return axios
      .get('/api/PurchaseOrder/' + payload)
      .then(function (response) {
        commit('setPurchaseOrder', response.data);
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
    return axios
      .delete('/portal/api/customercategories/?categoryId=' + payload[0].id + '&customerId=' + state.company.id)
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
    var customerCategory = {
      CompanyTypeId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerCompanyTypes/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeCompanyType({ commit }, payload) {
    return axios
      .delete('/portal/api/customerCompanyTypes/?CompanyTypeId=' + payload[0].id + '&customerId=' + state.company.id)
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
    var customerCategory = {
      IndustryId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerIndustries/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeIndustry({ commit }, payload) {
    return axios
      .delete('/portal/api/customerIndustries/?IndustryId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addMachine({ commit }, payload) {
    var customerCategory = {
      MachineId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerMachines/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeMachine({ commit }, payload) {
    return axios
      .delete('/portal/api/customerMachines/?machineId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addMaterial({ commit }, payload) {
    var customerCategory = {
      MaterialId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerMaterials/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeMaterial({ commit }, payload) {
    return axios
      .delete('/portal/api/customerMaterials/?MaterialId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  },
  addNaics({ commit }, payload) {
    var customerCategory = {
      NaicsId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerNaics/', customerCategory)
      .then(function (response) {
        return response.data;
      })
  },
  removeNaics({ commit }, payload) {
    return axios
      .delete('/portal/api/customerNaics/?NaicsId=' + payload[0].id + '&customerId=' + state.company.id)
      .then(function (response) {
        return response.data;
      });
  }
}

// mutations
const mutations = {
  setPurchaseOrder(state, purchaseOrder) {
    state.purchaseOrder = purchaseOrder
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
