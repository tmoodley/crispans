<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Register</h5>
          </div>
          <div class="card-body">
            <b-card>
              <b-tabs pills card v-model="tabIndex">
                <b-tab body title="Create Account" :disabled="isCreated">
                  <form v-on:submit="create">
                    <div class="row">
                      <div class="col-md-12">
                        <div class="row">
                          <div class="col-md-6">
                            <div class="form-group">
                              <label>First Name</label>
                              <b-form-input v-model="user.givenName" placeholder="First Name"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-6">
                            <div class="form-group">
                              <label>Last Name</label>
                              <b-form-input v-model="user.familyName" placeholder="Last Name"></b-form-input>
                            </div>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-md-6">
                            <div class="form-group">
                              <label>Email</label>
                              <b-form-input v-model="user.email" placeholder="Enter Email"></b-form-input>
                            </div>
                          </div>
                        </div>
                        <div class="row"> 
                          <div class="col-md-6">
                            <div class="form-group">
                              <label>Password</label>
                              <b-form-input v-model="user.password" type="password" placeholder="Enter Password"></b-form-input>
                            </div>
                          </div>
                          <div class="col-md-6">
                            <div class="form-group">
                              <label>Confirm Password</label>
                              <b-form-input v-model="user.confirmPassword" type="password" placeholder="Enter Password"></b-form-input>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <b-button variant="success" type="submit" class="pull-right">SAVE</b-button>
                  </form>
                </b-tab>
                <b-tab body title="Details">
                  <form v-on:submit="save">
                    <div class="row">
                      <div class="col-md-12">
                        <div class="row">
                          <div class="col-md-6">
                            <b-form-group label="Select your type">
                              <b-form-radio-group id="btn-radios-2"
                                                  v-model="selected"
                                                  :options="options"
                                                  buttons
                                                  button-variant="outline-primary"
                                                  name="radio-btn-outline"></b-form-radio-group>
                            </b-form-group>
                          </div>
                        </div>
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
                    </div>
                    <b-button variant="success" type="submit" class="pull-right">SAVE</b-button>
                  </form>
                </b-tab>
                <b-tab body title="Industries">
                  <div class="row">
                    <div class="col-md-12">
                      <industry></industry>
                      <b-button variant="success" @click="tabIndex++" class="pull-right">SAVE</b-button>
                    </div>
                  </div>
                </b-tab>
                <b-tab body title="Technologies">
                  <div class="row">
                    <div class="col-md-12">
                      <machine></machine>
                      <b-button variant="success" @click="tabIndex++" class="pull-right">SAVE</b-button>
                    </div>
                  </div>
                </b-tab>
                <b-tab body title="Materials">
                  <div class="row">
                    <div class="col-md-12">
                      <material></material>
                      <b-button variant="success" @click="tabIndex++" class="pull-right">SAVE</b-button>
                    </div>
                  </div>
                </b-tab>
                <b-tab body title="Certifications">
                  <div class="row">
                    <div class="col-md-12">
                      <certification></certification>
                      <a href="/portal/dashboard" variant="success" class="pull-right">Login</a>
                    </div>
                  </div>
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
      isCreated: false,
      tabIndex: 1,
      user: {
        email: '',
        givenName: '',
        familyName: '',
        password: '',
        confirmPassword: ''
      },
      selected: 'buyer',
      options: [
        { text: 'I am a Buyer', value: 'buyer' },
        { text: 'I am a Manufacturer', value: 'manufacturer' },  
      ],
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
        .then(response => {
          self.store.company = response.data; 
          self.tabIndex++;
        })
      },
      create() {
        event.preventDefault();
        var self = this;
        return axios
          .post('/portal/api/register/', self.user)
          .then(response => {
            self.store.company = response.data;
            self.tabIndex++;
            self.isCreated = true;
          })
      }
    }, 
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
