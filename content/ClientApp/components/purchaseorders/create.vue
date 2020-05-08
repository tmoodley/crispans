<template>
  <div>
    <div class="content">
      <div class="row">
        <div class="col-md-12">
          <div class="card">
            <div class="card-header">
              <h5 class="title">Create New Purchase Order</h5>
            </div>
            <div class="card-body">
              <form v-on:submit="onComplete">
                <div class="row">
                  <div class="col-md-9 pull-left">
                    <span>Enter the details for your order</span>
                  </div>
                  <div class="col-md-3 pull-right">
                    <span>STEP 1 OF 2</span>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6">
                    <div class="form-group">
                      <label for="PurchaseDate" class="control-label">Purchase Date</label>
                      <input v-model="purchaseOrder.PurchaseDate" type="date" class="form-control" />
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="form-group">
                      <label for="DeliveryDate" class="control-label">Delivery Date</label>
                      <input v-model="purchaseOrder.DeliveryDate" type="date" class="form-control" />
                    </div>
                  </div>
                  <div class="col-md-6" :class="{invalid: $v.purchaseOrder.PurchaseOrderNumber.$error}">
                    <div class="form-group">
                      <label for="PurchaseOrderNumber" class="control-label">Purchase Order Number</label>
                      <input v-model="purchaseOrder.PurchaseOrderNumber" class="form-control" @blur="$v.purchaseOrder.PurchaseOrderNumber.$touch()" />
                      <p v-if="!$v.purchaseOrder.PurchaseOrderNumber.required && $v.purchaseOrder.PurchaseOrderNumber.$error"> This field must not be empty</p>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-9 pull-left">
                    <span>Enter the items you wish to order</span>
                  </div>
                  <div class="col-md-3 pull-right">
                    <span>STEP 2 OF 2</span>
                  </div>
                </div>
                <div class="row" v-for="(item, index) in purchaseOrder.PurchaseOrderItems">
                  <div class="col-md-3">
                    <div class="form-group" :class="{invalid: $v.purchaseOrder.PurchaseOrderItems.$each[index].item.$error}">
                      <input type="text" class="form-control" placeholder="Item" v-model="item.item" @blur="$v.purchaseOrder.PurchaseOrderItems.$each[index].item.$touch()" />
                      <p v-if="!$v.purchaseOrder.PurchaseOrderItems.$each[index].item.required && $v.purchaseOrder.PurchaseOrderItems.$each[index].item.$error"> This field must not be empty</p>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="form-group">
                      <input type="text" class="form-control" placeholder="Description" v-model="item.description" />
                    </div>
                  </div>
                  <div class="col-md-2">
                    <div class="form-group" :class="{invalid: $v.purchaseOrder.PurchaseOrderItems.$each[index].quantity.$error}">
                      <input type="number" class="form-control input_height" placeholder="Quantity" v-model="item.quantity" @blur="$v.purchaseOrder.PurchaseOrderItems.$each[index].quantity.$touch()" />
                      <p v-if="!$v.purchaseOrder.PurchaseOrderItems.$each[index].quantity.numeric"> Please provide a valid Quantity</p>
                      <p v-if="!$v.purchaseOrder.PurchaseOrderItems.$each[index].quantity.required && $v.purchaseOrder.PurchaseOrderItems.$each[index].quantity.$error"> This field must not be empty</p>
                    </div>
                  </div>
                  <div class="col-md-2">
                    <div class="form-group" :class="{invalid: $v.purchaseOrder.PurchaseOrderItems.$each[index].amount.$error}">
                      <input type="text" class="form-control" placeholder="Price" v-model="item.amount" @change="debouncedGetAnswer()" @blur="$v.purchaseOrder.PurchaseOrderItems.$each[index].amount.$touch()" />
                      <p v-if="!$v.purchaseOrder.PurchaseOrderItems.$each[index].amount.required && $v.purchaseOrder.PurchaseOrderItems.$each[index].amount.$error"> This field must not be empty</p>
                      <p v-if="!$v.purchaseOrder.PurchaseOrderItems.$each[index].amount.decimal"> Please provide a valid Amount</p>
                    </div>
                  </div>
                  <div class="col-md-1">
                    <div class="form-group" v-if="item.amount > 0">
                      {{item.amount * item.quantity | currency}}
                    </div>
                    <i class="fa fa-minus-circle" @click="removeLine(index)"></i>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-12">
                    <i class="fa fa-plus-circle" @click="addLine()"> Add New Line</i>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-8 total-footer">
                    <div class="total-footer__notes grid-5 grid-item">
                      <label for="notes" class="control-label">Notes / Memo</label>
                      <textarea name="notes" id="notes" class="form-control" v-model="purchaseOrder.Notes"></textarea>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="summary-grid">
                      <div class="summary-total">
                        <h5 class="total-label">
                          Total
                        </h5>
                        <span id="Total" class="PurchaseOrderTotal">{{purchaseOrder.Total  | currency}}</span>
                      </div>
                    </div>
                    <div class="form-group">
                      <input type="submit" value="Create" class="btn btn-primary" :disabled="$v.$invalid" />
                    </div>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
      </div>
  </div>
</template>

<script>
  import axios from 'axios' 
  import { mapState, mapActions } from 'vuex'
  import { required, numeric, minLength, maxLength, decimal } from 'vuelidate/lib/validators'
  export default { 
      data() {
          return {
              email: _user,
              loading: false,
              purchaseOrder: {
                PurchaseDate: '',
                DeliveryDate: '',
                Notes: '',
                PurchaseOrderNumber: '',
                CustomerId: '',
                Email: _user,
                Status: '',
                SubTotal: 0,
                Tax: 0,
                Total: 0,
                PurchaseOrderItems: [{
                  Item: '',
                  Description: '',
                  Quantity: 0,
                  Amount: 0.00
                }],
              }
            }
          },
      methods: {
          ...mapActions('company', [
            'getCompany'
          ]),
          save() {
          event.preventDefault();
          var self = this;  
          this.purchaseOrder.CustomerId = this.store.company.id;
          return axios
            .post('/api/purchaseorders/', self.purchaseOrder)
            .then(response => { self.purchaseOrder = response.data }) 
          },
          onComplete: function () {
                var self = this;
                this.save().then(function () { 
                  self.$swal.fire(
                    'Saved',
                    'Job Saved',
                    'success'
                  ).then(function () { 
                    self.$router.push({ path: '/purchaseorders/manage/' + self.purchaseOrder.id })
                  })
                });
          }, 
          addLine() {
              this.purchaseOrder.PurchaseOrderItems.push({
                  Item: '',
                  Description: '',
                  Quantity: 0,
                  Amount: 0.00
              });

          },
          addTotal() {
              var _this = this;
              this.purchaseOrder.PurchaseOrderItems.map(item => {
                  _this.purchaseOrder.Total += item.quantity * item.amount;
              })
          },
          removeLine(index) {
              const _index = this.purchaseOrder.PurchaseOrderItems.indexOf(index);
              if (index > -1) {
                this.purchaseOrder.PurchaseOrderItems.splice(_index, 1);
              }
          }
      },
      validations: {
        purchaseOrder: {
          PurchaseOrderNumber: {
            required
          },
          PurchaseOrderItems: {
            required,
            $each: {
              quantity: {
                required,
                numeric
              },
              amount: {
                required,
                decimal
              },
              item: {
                required
              }
            }
          }
        }
      },
      created: function () { 
            // _.debounce is a function provided by lodash to limit how
            // often a particularly expensive operation can be run.
            // In this case, we want to limit how often we access
            // yesno.wtf/api, waiting until the user has completely
            // finished typing before making the ajax request. To learn
            // more about the _.debounce function (and its cousin
            // _.throttle), visit: https://lodash.com/docs#debounce
            this.debouncedGetAnswer = _.debounce(this.addTotal, 500)
      },
      mounted: function () {
        this.getCompany(this.email)
      },
      computed: mapState({
        store: state => state.company
      }), 
  }
</script>

<style scoped>
  .form-group.invalid label, .col-md-6.invalid label {
    color: red;
  }

  .form-group.invalid input, .col-md-6.invalid input {
    border: 1px solid red;
    background-color: #ffc9aa;
  }
</style>
