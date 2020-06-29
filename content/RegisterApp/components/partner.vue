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
                <b-tab body :disabled="isCreated">
                  <template v-slot:title>
                    <strong>Create Account</strong>
                    <img v-show="isSaving" src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                    <i class="fa fa-check" v-if="isCreated"></i>
                  </template>
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
                              <span v-if="user.password != null && user.password != user.confirmPassword">Please make sure passwords are the same</span>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <b-button variant="success" type="submit" class="pull-right" :disabled="user.password != user.confirmPassword || isSaving">SAVE</b-button>
                  </form>
                </b-tab>
                <b-tab body :disabled="isDetailsSaved || !isCreated">
                  <template v-slot:title>
                    <strong>Details</strong>
                    <i class="fa fa-check" v-if="isDetailsSaved"></i>
                  </template>
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
                <b-tab body title="Industries" :disabled="!isCreated">
                  <div class="row">
                    <div class="col-md-12">
                      <industry></industry>
                      <b-button variant="success" @click="tabIndex++" class="pull-right">SAVE</b-button>
                    </div>
                  </div>
                </b-tab>
                <b-tab body title="Technologies" :disabled="!isCreated">
                  <div class="row">
                    <div class="col-md-12">
                      <machine></machine>
                      <b-button variant="success" @click="tabIndex++" class="pull-right">SAVE</b-button>
                    </div>
                  </div>
                </b-tab>
                <b-tab body title="Materials" :disabled="!isCreated">
                  <div class="row">
                    <div class="col-md-12">
                      <material></material>
                      <b-button variant="success" @click="tabIndex++" class="pull-right">SAVE</b-button>
                    </div>
                  </div>
                </b-tab>
                <b-tab body title="Certifications" :disabled="!isCreated">
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
      isSaving: false,
      isDetailsSaved: false,
      tabIndex: 0,
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
      }
    },
    methods: {
    ...mapActions('company', [
        'getCompany'
    ]), 
    save() {
      event.preventDefault();
      this.store.company.companyType = this.selected;
      var self = this;
      return axios
        .put('/portal/api/customers/' + this.store.company.id, this.store.company)
        .then(response => {
          self.store.company = response.data; 
          self.tabIndex++;
          self.isDetailsSaved = true;
        })
      },
      create() {
        event.preventDefault();
        this.isSaving = true;
        var self = this;
        return axios
          .post('/portal/api/register/', self.user)
          .then(response => {
            self.store.company = response.data;
            self.tabIndex++;
            self.isCreated = true;
            self.isSaving = false;
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
