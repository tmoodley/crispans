<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">{{action | capitalize}} Product</h5>
          </div>
          <div class="card-body">
            <b-card>
              <form v-on:submit="save">
                <b-button variant="primary" type="submit" class="pull-right">SAVE</b-button>
                <b-tabs pills card>
                  <b-tab body title="Details">
                    <div class="row">
                      <div class="col-lg-6 form-group">
                        <b-form-group label="Product Type">
                          <b-form-radio-group v-model="product.type"
                                              :options="typeOptions"
                                              name="radios-stacked"
                                              stacked></b-form-radio-group>
                        </b-form-group>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label for="Name" class="col-lg-12">Name</label>
                        <div class="col-lg-12">
                          <input v-model="product.name" placeholder="" class="form-control">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label for="Upc" class="col-lg-12">Upc Code</label>
                        <div class="col-lg-12">
                          <input v-model="product.upc" placeholder="" class="form-control">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label for="Stock" class="col-lg-12">Stock</label>
                        <div class="col-lg-12">
                          <input v-model="product.stock" placeholder="" class="form-control">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label class="col-lg-12" for="ManufacturerPart">Manufacturer Part</label>
                        <div class="col-lg-12">
                          <input type="text" v-model="product.mpn" id="manufacturerPart" name="ManufacturerPart" placeholder="" class="form-control manufacturer-part">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label for="Price" class="col-lg-12">Price</label>
                        <div class="col-lg-12">
                          <currency-input v-model="product.price" v-currency="options" class="form-control price" />
                        </div>
                      </div>
                    </div>
                  </b-tab>
                  <b-tab no-body title="Description" :disabled="action == 'add'"> 
                    <div class="row">
                      <div class="col-md-12">
                        <wysiwyg v-model="product.description" />
                      </div>
                    </div>
                  </b-tab>
                  <b-tab no-body title="Dimensions" :disabled="action == 'add'">
                    <div class="row">
                      <div class="col-lg-6 form-group">
                        <label for="Height" class="col-lg-12">Height</label>
                        <div class="col-lg-12">
                          <input v-model="product.height" type="number" id="Height" name="Height" placeholder="" class="form-control price">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label for="Length" class="col-lg-12">Length</label>
                        <div class="col-lg-12">
                          <input v-model="product.length" type="number" id="price" name="Price" placeholder="" class="form-control price">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label for="Width" class="col-lg-12">Width</label>
                        <div class="col-lg-12">
                          <input v-model="product.width" type="number" id="Width" name="Width" placeholder="" class="form-control price">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label class="col-lg-12" for="Weight">Weight</label>
                        <div class="col-lg-12">
                          <input type="text" v-model="product.weight" id="number" name="Weight" placeholder="" class="form-control weight">
                        </div>
                      </div>
                    </div>
                  </b-tab>
                  <b-tab no-body title="Categories" :disabled="action == 'add'" lazy>
                    <category></category>
                  </b-tab>
                  <b-tab no-body title="Pictures" :disabled="action == 'add'" lazy>
                    <div class="row">
                      <div class="col-md-6">
                        Image 1
                      </div>
                      <div class="col-md-6">
                        <b-button class="float-right" v-if="product.picture1Id" @click="download(product.picture1Id)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                      </div>
                      <div class="col-md-6">
                        <upload @setid="setImage1"></upload>
                      </div>
                      <div class="col-md-6">
                        <img :src="image1">
                      </div>
                      <div class="col-md-6">
                        Image 2
                      </div>
                      <div class="col-md-6">
                        <b-button class="float-right" v-if="product.picture2Id" @click="download(product.picture2Id)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                      </div>
                      <div class="col-md-6">
                        <upload @setid="setImage2"></upload>
                      </div>
                      <div class="col-md-6">
                        <img :src="image2">
                      </div>
                      <div class="col-md-6">
                        Image 3
                      </div>
                      <div class="col-md-6">
                        <b-button class="float-right" v-if="product.picture3Id" @click="download(product.picture3Id)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                      </div>
                      <div class="col-md-6">
                        <upload @setid="setImage3"></upload>
                      </div>
                      <div class="col-md-6">
                        <img :src="image3">
                      </div>
                      <div class="col-md-6">
                        Image 4
                      </div>
                      <div class="col-md-6">
                        <b-button class="float-right" v-if="product.picture4Id" @click="download(product.picture4Id)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                      </div>
                      <div class="col-md-6">
                        <upload @setid="setImage4"></upload>
                      </div>
                      <div class="col-md-6">
                        <img :src="image4">
                      </div>
                    </div>
                  </b-tab>
                </b-tabs>
              </form>
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
  import category from './category'
  import certification from '../categories/certification'
  import capability from '../categories/capability'
  import companytype from '../categories/companytype'
  import filetype from '../categories/filetype'
  import industry from '../categories/industry'
  import machine from '../categories/machine'
  import material from '../categories/material'
  import naics from '../categories/naics'
  import upload from './document'
  export default {  
    components: {
      category,
      certification,
      capability,
      companytype,
      filetype,
      industry,
      machine,
      material,
      naics,
      upload
    },
    data() {
      return {
        action: 'add',
        email: _user,
        product: {},
        typeOptions: [
          { text: 'Assembled', value: 'assembled' },
          { text: 'Finished', value: 'finished' },
          { text: 'Raw Material', value: 'raw' }
        ],
        locale: 'en',
        currency: 'USD'
      }
    },
    methods: {
      ...mapActions('company', [
        'getCompany'
      ]),
      ...mapActions('product', [
        'getproduct'
      ]),
      download(id) {
        axios({

          url: '/portal/api/documents/' + id,

          method: 'GET', 

        }).then(function (doc) {
          axios({

            url: '/portal/api/document/' + id,

            method: 'GET',

            responseType: 'blob',

          }).then((response) => {

            var fileURL = window.URL.createObjectURL(new Blob([response.data]));

            var fileLink = document.createElement('a');
             
            fileLink.href = fileURL;

            fileLink.setAttribute('download', doc.data.name);

            document.body.appendChild(fileLink);
             
            fileLink.click();

          })
        });
    },
      save() {
        event.preventDefault();
        var self = this;
        this.product.customerId = this.store.company.id;
        if (this.action == "add") {
          return axios
            .post('/portal/api/product/', self.product)
            .then(function (response) {
              self.product = response.data;
              self.$swal.fire(
                'Saved',
                'Product Saved',
                'success'
              ).then(function () {
                self.$emit("hide");
              })
            });
        }
        else {
          return axios
            .put('/portal/api/product/' + self.product.id, self.product)
            .then(function (response) {
              self.product = response.data;
              self.$swal.fire(
                'Saved',
                'Product Saved',
                'success'
              ).then(function () {
                self.$router.push({ path: '/portal/Products/Manage' })
              })
            }); 
        }
      },
      setImage1(id) { 
          this.product.picture1Id = id;
      },
      setImage2(id) { 
          this.product.picture2Id = id;
      },
      setImage3(id) { 
          this.product.picture3Id = id;
      },
      setImage4(id) { 
          this.product.picture4Id = id;
      }
    },
    mounted: function () {
      var self = this;
       if (this.$route.params.id != undefined) {
          this.getproduct(this.$route.params.id).then(function () { 
            self.action = 'edit'; 
            self.product = self._product.product;
          })
      }
      this.getCompany(this.email)
    },
     computed: { 
        ...mapState({
          store: state => state.company
        }),
        ...mapState({
          _product: state => state.product
        }),
        options() {
          return {
            locale: this.locale,
            currency: this.currency
          }
       },
       image1() {
         return "/api/image/" + this.product.picture1Id;
       },
       image2() {
         return "/api/image/" + this.product.picture2Id;
       },
       image3() {
         return "/api/image/" + this.product.picture3Id;
       },
       image4() {
         return "/api/image/" + this.product.picture4Id;
       },

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
