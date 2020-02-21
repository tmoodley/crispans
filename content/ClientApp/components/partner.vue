<template>
  <div class="content"> 
    <div class="row">
      <div class="col-md-8">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Edit Profile</h5>
          </div>
          <div class="card-body">
            <form v-on:submit="save">
              <div class="row">
                <div class="col-md-5 pr-1">
                  <div class="form-group">
                    <label>Company</label>
                    <input type="text" class="form-control" placeholder="Company" v-model="user.companyName">
                  </div>
                </div>
                <div class="col-md-3 px-1">
                  <div class="form-group">
                    <label>Username</label>
                    <input type="text" class="form-control" placeholder="Username" v-model="user.username">
                  </div>
                </div>
                <div class="col-md-4 pl-1">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Email address</label>
                    <input type="email" class="form-control" placeholder="Email" disabled v-model="user.emailAddress">
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6 pr-1">
                  <div class="form-group">
                    <label>First Name</label>
                    <input type="text" class="form-control" placeholder="First Name"  v-model="user.givenName">
                  </div>
                </div>
                <div class="col-md-6 pl-1">
                  <div class="form-group">
                    <label>Last Name</label>
                    <input type="text" class="form-control" placeholder="Last Name"   v-model="user.familyName">
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <div class="form-group">
                    <label>Address</label>
                    <input type="text" class="form-control" placeholder="Address" v-model="user.address1">
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-4 pr-1">
                  <div class="form-group">
                    <label>City</label>
                    <input type="text" class="form-control" placeholder="City" v-model="user.city">
                  </div>
                </div>
                <div class="col-md-4 px-1">
                  <div class="form-group">
                    <label>Province/State</label>
                    <input type="text" class="form-control" placeholder="Province/State" v-model="user.state">
                  </div>
                </div>
                <div class="col-md-4 pl-1">
                  <div class="form-group">
                    <label>Postal Code/Zip</label>
                    <input type="text" class="form-control" placeholder="ZIP Code" v-model="user.postalCode">
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <div class="form-group">
                    <label>Categories</label>
                    <textarea rows="4" cols="80" class="form-control" placeholder="Here can be your description" v-model="user.CompanyName"></textarea>
                  </div>
                </div>
              </div>
              <button class="btn" type="submit">SAVE</button>
            </form>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="card card-user">
          <div class="image">
            <img src="/assets/img/bg5.jpg" alt="...">
          </div>
          <div class="card-body">
            <div class="author">
              <a href="#">
                <img class="avatar border-gray" src="/assets/img/default-avatar.png" alt="...">
                <h5 class="title">Mike Andrew</h5>
              </a>
              <p class="description">
                michael24
              </p>
            </div>
            <p class="description text-center">
              "Lamborghini Mercy <br>
              Your chick she so thirsty <br>
              I'm in that two seat Lambo"
            </p>
          </div>
          <hr>
          <div class="button-container">
            <button href="#" class="btn btn-neutral btn-icon btn-round btn-lg">
              <i class="fab fa-facebook-f"></i>
            </button>
            <button href="#" class="btn btn-neutral btn-icon btn-round btn-lg">
              <i class="fab fa-twitter"></i>
            </button>
            <button href="#" class="btn btn-neutral btn-icon btn-round btn-lg">
              <i class="fab fa-google-plus-g"></i>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data () {
    return {
      email: _user,
      user: ''
      }
    },
  methods: {
      getPartner() {
        return axios
          .get('/portal/api/customers/' + this.email)
          .then(response => (this.user = response.data))
    },
    save() {
      event.preventDefault();
      var self = this;
      return axios
        .put('/portal/api/customers/' + this.user.id, this.user)
        .then(response => { self.user = response.data })
      }
    },
  mounted: function ()  {
    this.getPartner()
  }
}
</script>

<style>

</style>
