<template>
  <div>

    <h1>Create</h1>

    <h4>Purchase Order</h4>
    <hr /> 
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
          <input v-model="purchaseOrder.DeliveryDate" type="date" class="form-control"  />
        </div>
      </div> 
      <div class="col-md-6">
        <div class="form-group">
          <label for="PurchaseOrderNumber" class="control-label">Purchase Order Number</label>
          <input v-model="purchaseOrder.PurchaseOrderNumber" class="form-control" /> 
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
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Item" v-model="item.item" />
        </div>
      </div>
      <div class="col-md-4">
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Description" v-model="item.description" />
        </div>
      </div>
      <div class="col-md-2">
        <div class="form-group">
          <input type="number" class="form-control input_height" placeholder="Quantity" v-model="item.quantity" />
        </div>
      </div>
      <div class="col-md-2">
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Price" v-model="item.amount" @change="debouncedGetAnswer()" />
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
            <input type="submit" value="Create" class="btn btn-primary" :disabled="purchaseOrder.PurchaseOrderItems.length == 0"/>
          </div> 
        </div> 
    </div> 
  </form>
  </div>
</template>

<script>
  import axios from 'axios' 
  import { mapState, mapActions } from 'vuex'
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
      debugger;
      this.getCompany(this.email)
    },
    computed: mapState({
      store: state => state.company
    }), 
}
</script>

<style>
</style>
