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
                <b-button variant="primary" type="submit" class="pull-right" :disabled="$v.$invalid">SAVE</b-button>
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
                      <div class="col-lg-6 form-group" :class="{invalid: $v.product.upc.$error}">
                        <label for="Upc" class="col-lg-12">Upc Code</label>
                        <div class="col-lg-12">
                          <input v-model="product.upc" placeholder="" class="form-control" @blur="$v.product.upc.$touch()">
                          <p v-if="!$v.product.upc.numeric || !$v.product.upc.minLen || !$v.product.upc.maxLen"> Please provide a valid 12-digit upc code.</p>
                          <p v-if="!$v.product.upc.required && $v.product.upc.$error"> This field must not be empty</p>
                        </div>
                      </div>
                      <div class="col-lg-6 form-group"  :class="{invalid: $v.product.stock.$error}">
                        <label for="Stock" class="col-lg-12">Stock</label>
                        <div class="col-lg-12">
                          <input v-model="product.stock" placeholder="" class="form-control" @blur="$v.product.stock.$touch()">
                          <p v-if="!$v.product.stock.required && $v.product.stock.$error"> This field must not be empty</p>
                          <p v-if="!$v.product.stock.numeric"> Please provide a valid stock</p>
                        </div>
                      </div>
                      <div class="col-lg-6 form-group">
                        <label class="col-lg-12" for="ManufacturerPart">Manufacturer Part</label>
                        <div class="col-lg-12">
                          <input type="text" v-model="product.mpn" id="manufacturerPart" name="ManufacturerPart" placeholder="" class="form-control manufacturer-part">
                        </div>
                      </div>
                      <div class="col-lg-6 form-group" :class="{invalid: $v.product.price.$error}">
                        <label for="Price" class="col-lg-12">Price</label>
                        <div class="col-lg-12">
                          <currency-input v-model="product.price" v-currency="options" class="form-control price" @blur="$v.product.price.$touch()" />
                          <p v-if="!$v.product.price.required && $v.product.price.$error"> This field must not be empty</p>
                          <p v-if="!$v.product.price.decimal"> Please provide a valid price</p>
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
                      <div class="col-lg-6 form-group" :class="{invalid: $v.product.height.$error}">
                        <label for="Height" class="col-lg-12">Height (cm)</label>
                        <div class="col-lg-12">
                          <input v-model="product.height" type="number" id="Height" name="Height" placeholder="" class="form-control price" @blur="$v.product.height.$touch()">
                          <p v-if="!$v.product.height.required && $v.product.height.$error"> This field must not be empty</p>
                          <p v-if="!$v.product.height.decimal"> Please provide a valid height</p>
                        </div>
                      </div>
                      <div class="col-lg-6 form-group" :class="{invalid: $v.product.length.$error}">
                        <label for="Length" class="col-lg-12">Length (cm)</label>
                        <div class="col-lg-12">
                          <input v-model="product.length" type="number" id="price" name="Price" placeholder="" class="form-control price" @blur="$v.product.length.$touch()">
                          <p v-if="!$v.product.length.required && $v.product.length.$error"> This field must not be empty</p>
                          <p v-if="!$v.product.length.decimal"> Please provide a valid length</p>
                        </div>
                      </div>
                      <div class="col-lg-6 form-group" :class="{invalid: $v.product.width.$error}">
                        <label for="Width" class="col-lg-12">Width (cm)</label>
                        <div class="col-lg-12">
                          <input v-model="product.width" type="number" id="Width" name="Width" placeholder="" class="form-control price" @blur="$v.product.width.$touch()">
                          <p v-if="!$v.product.width.required && $v.product.width.$error"> This field must not be empty</p>
                          <p v-if="!$v.product.width.decimal"> Please provide a valid width</p>
                        </div>
                      </div>
                      <div class="col-lg-6 form-group" :class="{invalid: $v.product.weight.$error}">
                        <label class="col-lg-12" for="Weight">Weight (lb)</label>
                        <div class="col-lg-12">
                          <input type="text" v-model="product.weight" id="number" name="Weight" placeholder="" class="form-control weight" @blur="$v.product.weight.$touch()">
                          <p v-if="!$v.product.weight.required && $v.product.weight.$error"> This field must not be empty</p>
                          <p v-if="!$v.product.weight.decimal"> Please provide a valid weight</p>
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
  import { required, numeric, minLength, maxLength, decimal } from 'vuelidate/lib/validators'
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
    validations: {
      product: {
        upc: {
          required,
          numeric,
          minLen: minLength(12),
          maxLen: maxLength(12)
        },
        price: {
          required,
          decimal
        },
        stock: {
          required,
          numeric
        },
        height: {
          required,
          decimal
        },
        width: {
          required,
          decimal
        },
        length: {
          required,
          decimal
        },
        weight: {
          required,
          decimal
        }
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

<style scoped>
  li.nav-item a {
    color: #9A9A9A;
  }

  li.nav-item a:hover {
      color: black;
  }

  .col-lg-6.form-group.invalid label {
    color: red;
  }

  .col-lg-6.form-group.invalid input {
    border: 1px solid red;
    background-color: #ffc9aa;
  }
</style>
