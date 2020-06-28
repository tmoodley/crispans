<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Edit Profile</h5>
          </div>
          <div class="card-body">
            <b-card>
              <b-tabs pills card>
                <b-tab body title="Details">
                  <form v-on:submit="save">
                    <div class="row">
                      <div class="col-md-8">
                        <div class="row">
                          <div class="col-md-5 pr-1">
                            <div class="form-group">
                              <label>Company</label>
                              <b-form-input v-model="store.company.companyName" placeholder="Enter Company Name"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-3 px-1">
                            <div class="form-group">
                              <label>Username</label>
                              <b-form-input v-model="store.company.username" placeholder="Username"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-4 pl-1">
                            <div class="form-group">
                              <label for="exampleInputEmail1">Email address</label>
                              <b-form-input v-model="store.company.emailAddress" placeholder="Email"></b-form-input>
                            </div>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-6 pr-1">
                            <div class="form-group">
                              <label>First Name</label>
                              <b-form-input v-model="store.company.givenName" placeholder="First Name"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-6 pl-1">
                            <div class="form-group">
                              <label>Last Name</label>
                              <b-form-input v-model="store.company.familyName" placeholder="Last Name"></b-form-input>
                            </div>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-12">
                            <div class="form-group">
                              <label>Address</label>
                              <b-form-input v-model="store.company.address1" placeholder="Address"></b-form-input>
                            </div>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-4 pr-1">
                            <div class="form-group">
                              <label>City</label>
                              <b-form-input v-model="store.company.city" placeholder="City"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-4 px-1">
                            <div class="form-group">
                              <label>Province/State</label>
                              <b-form-input v-model="store.company.state" placeholder="Province/State"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-4 pl-1">
                            <div class="form-group">
                              <label>Postal Code/Zip</label>
                              <b-form-input v-model="store.company.postalCode" placeholder="Postal/Zip"></b-form-input>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-4">
                        <industry></industry>
                        <machine></machine>
                        <material></material>
                        <certification></certification>
                      </div>
                    </div>
                  
                    <b-button variant="success" type="submit">SAVE</b-button>
                  </form>
                </b-tab> 
              </b-tabs>
            </b-card> 
          </div>
        </div>
      </div> 
    </div> 
  </div>
</template>

<script>
  import axios from 'axios' 
  import { mapState, mapActions } from 'vuex'
  import category from './categories/category'
  import certification from './categories/certification'
  import capability from './categories/capability'
  import companytype from './categories/companytype'
  import filetype from './categories/filetype'
  import industry from './categories/industry'
  import machine from './categories/machine'
  import material from './categories/material'
  import naics from './categories/naics' 
  export default { 
    computed: {
        ...mapState({
          store: state => state.company
        }) 
    },
  components: {
    category,
    certification,
    capability,
    companytype,
    filetype,
    industry,
    machine,
    material,
    naics
  },
  data () {
    return {
      email: JSON.parse(localStorage.getItem('user')).username
      }
    },
    methods: {
    ...mapActions('company', [
        'getCompany'
    ]), 
    save() {
      event.preventDefault();
      var self = this;
      return axios
        .put('/portal/api/customers/' + this.store.company.id, this.store.company)
        .then(response => { self.store.company = response.data })
      }
    },
  mounted: function ()  {
    this.getCompany(this.email)
  }
}
</script>

<style>
  li.nav-item a {
    color: #9A9A9A;
}
    li.nav-item a:hover {
    color: black;
}
</style>
