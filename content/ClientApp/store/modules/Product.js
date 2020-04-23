
import axios from 'axios'
// initial state
const state = {
  product: {}
}

// getters
const getters = {
  product: (state) => {
    return state.product
  }
}

// actions
const actions = {
  getproduct({ commit }, payload) {
    return axios
      .get('/portal/api/products/' + payload)
      .then(function (response) {
        commit('setproduct', response.data);
        return response.data;
      })
  },
  addCategory({ commit }, payload) {
    return axios
      .post('/portal/api/productcategories/', payload)
      .then(function (response) {
        return response.data;
      })
  },
  removeCategory({ commit }, payload) {
    return axios
      .delete('/portal/api/productcategories/?categoryId=' + payload.CategoryId + '&productId=' + payload.ProductId)
      .then(function (response) {
        return response.data;
      });
  },
  addCertification({ commit }, payload) {
    var productCategory = {
      CertificationId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customercertifications/', productCategory)
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
    var productCategory = {
      CapabilityId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customercapabilities/', productCategory)
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
    var productCategory = {
      CompanyTypeId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerCompanyTypes/', productCategory)
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
    var productCategory = {
      FileTypeId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerfileTypes/', productCategory)
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
    var productCategory = {
      IndustryId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerIndustries/', productCategory)
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
    var productCategory = {
      MachineId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerMachines/', productCategory)
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
    var productCategory = {
      MaterialId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerMaterials/', productCategory)
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
    var productCategory = {
      NaicsId: payload[0].id,
      CustomerId: state.company.id
    }

    return axios
      .post('/portal/api/customerNaics/', productCategory)
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
  setproduct(state, product) { 
    state.product = product
  },
  addCategory(state, category) {
    if (state.company.productcategories == null) {
      state.company.productcategories = []
    }
    var productCategory = {
      CategoryId: category[0].id,
      CustomerId: state.company.id
    } 
    state.company.productcategories.push(productCategory);
  },
  removeCategory(state, category) {
    var index = state.company.productcategories.indexOf(x => x.name === category);
    state.company.productcategories.splice(index, 1);
  },
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
