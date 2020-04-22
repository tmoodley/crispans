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
              <b-tabs pills card>
                <b-tab body title="Details">
                  <form v-on:submit="save">
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
                          <input v-model="product.price" type="text" id="price" name="Price" placeholder="" class="form-control price">
                        </div>
                      </div> 
                      <div class="form-group col-lg-12">
                        <b-button variant="success" type="submit">SAVE</b-button>
                      </div>
                    </div>
                  </form>
                </b-tab>
                <b-tab no-body title="Dimensions" :disabled="action == 'add'">
                  <div class="row">
                    <div class="col-lg-6 form-group">
                      <label for="Height" class="col-lg-12">Height</label>
                      <div class="col-lg-12">
                        <input v-model="product.Height" type="text" id="Height" name="Height" placeholder="" class="form-control price">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label for="Length" class="col-lg-12">Length</label>
                      <div class="col-lg-12">
                        <input v-model="product.Length" type="text" id="price" name="Price" placeholder="" class="form-control price">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label for="Width" class="col-lg-12">Width</label>
                      <div class="col-lg-12">
                        <input v-model="product.Width" type="text" id="Width" name="Width" placeholder="" class="form-control price">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="SalePrice">Sale Price</label>
                      <div class="col-lg-12">
                        <input type="text" id="saleprice" name="SalePrice" placeholder="" class="form-control sale-price">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="Weight">Weight</label>
                      <div class="col-lg-12">
                        <input type="text" id="weight" name="Weight" placeholder="" class="form-control weight">
                      </div>
                    </div>
                    <div class="col-lg-12 form-group">
                      <label for="Diameter" class="col-lg-12">Dimentions(Width x Height X Depth)</label>
                    </div>
                    <div class="col-lg-4">
                      <input type="text" id="dimentionsWidth" name="DimentionsWidth" placeholder="Width" class="form-control dimentions-width">
                    </div>
                    <div class="col-lg-4">
                      <input type="text" id="dimentionsHeight" name="DimentionsHeight" placeholder="Height" class="form-control dimentions-height">
                    </div>
                    <div class="col-lg-4">
                      <input type="text" id="dimentionsDepth" name="DimentionsDepth" placeholder="Depth" class="form-control dimentions-depth">
                    </div>
                    <div class="form-group col-lg-6">
                      <label for="MinTolerance" class="control-label"></label>
                      <input v-model="product.MinTolerance" class="form-control" />
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="CurrentInventory">Current Inventory</label>
                      <div class="col-lg-12">
                        <input type="text" id="currentInventory" name="CurrentInventory" placeholder="" class="form-control current-inventory">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="Colors">Colors</label>
                      <div class="col-lg-12">
                        <input type="text" id="colors" name="Colors" placeholder="" class="form-control colors">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="ColorSKUModifier">Color SKU Modifiers</label>
                      <div class="col-lg-12">
                        <input type="text" id="colorModifier" name="ColorSKUModifier" placeholder="" class="form-control color-modifier">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="Sizes">Sizes</label>
                      <div class="col-lg-12">
                        <input type="text" id="sizes" name="Sizes" placeholder="" class="form-control sizes">
                      </div>
                    </div>
                    <div class="col-lg-6 form-group">
                      <label class="col-lg-12" for="SizeSKUModifier">Size SKU Modifiers</label>
                      <div class="col-lg-12">
                        <input type="text" id="sizeModifier" name="SizeSKUModifier" placeholder="" class="form-control size-modifier">
                      </div>
                    </div>
                  </div>
                </b-tab>
                <b-tab no-body title="Images" :disabled="action == 'add'">
                  <certification></certification>
                </b-tab>
                <b-tab no-body title="Manufacturer" :disabled="action == 'add'">
                  <certification></certification>
                </b-tab>
                <b-tab no-body title="Distributor" :disabled="action == 'add'">
                  <certification></certification>
                </b-tab>
                <b-tab no-body title="Bill Of Materials" :disabled="action == 'add'">
                  <capability></capability>
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
  import category from '../categories/category'
  import certification from '../categories/certification'
  import capability from '../categories/capability'
  import companytype from '../categories/companytype'
  import filetype from '../categories/filetype'
  import industry from '../categories/industry'
  import machine from '../categories/machine'
  import material from '../categories/material'
  import naics from '../categories/naics'
  export default { 
      computed: { 
        ...mapState({
          store: state => state.company
        }),
        ...mapState({
          _product: state => state.product
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
    data() {
      return {
        action: 'add',
        email: _user,
        product: {},
        typeOptions: [
          { text: 'Assembled', value: 'assembled' },
          { text: 'Finished', value: 'finished' },
          { text: 'Raw Material', value: 'raw' }
        ] 
      }
    },
    methods: {
      ...mapActions('company', [
        'getCompany'
      ]),
      ...mapActions('product', [
        'getproduct'
      ]),
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
