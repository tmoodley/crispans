<template>
  <div> 
    <nav-menu params="route: route"></nav-menu>
    <h1>Manage</h1>
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <div class="panel-group" id="accordion">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                    <span class="glyphicon glyphicon-file">
                    </span>Purchase Order
                  </a>
                </h4>
              </div>
              <div id="collapseOne" class="panel-collapse collapse in">
                <div class="panel-body">
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
                          <input type="number" class="form-control" placeholder="Quantity" v-model="item.quantity" />
                        </div>
                      </div>
                      <div class="col-md-2">
                        <div class="form-group">
                          <input type="text" class="form-control" placeholder="Amount" v-model="item.amount" @change="debouncedGetAnswer()" />
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
                          <input type="submit" value="Create" class="btn btn-primary" :disabled="purchaseOrder.PurchaseOrderItems.length == 0" />
                        </div>
                      </div>
                    </div>
                  </form>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Documents
                  </a>
                </h4>
              </div>
              <div id="collapseTwo" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="form-group">
                        <input type="text" class="form-control" placeholder="Title" required />
                      </div>
                      <div class="form-group">
                        <input type="text" class="form-control" placeholder="Description" required />
                      </div>
                      <div class="form-group">
                        <textarea class="form-control" placeholder="Keywords" required></textarea>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="well well-sm well-primary">
                        <form class="form form-inline " role="form">
                          <div class="form-group">
                            <a href="http://www.jquery2dotnet.com" class="btn btn-success btn-sm">
                              <span class="glyphicon glyphicon-floppy-disk">
                              </span>Save
                            </a>
                          </div>
                        </form>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Categories
                  </a>
                </h4>
              </div>
              <div id="collapseThree" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="form-group">
                        <input type="text" class="form-control" placeholder="Title" required />
                      </div>
                      <div class="form-group">
                        <input type="text" class="form-control" placeholder="Description" required />
                      </div>
                      <div class="form-group">
                        <textarea class="form-control" placeholder="Keywords" required></textarea>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="well well-sm well-primary">
                        <form class="form form-inline " role="form">
                          <div class="form-group">
                            <a href="http://www.jquery2dotnet.com" class="btn btn-success btn-sm">
                              <span class="glyphicon glyphicon-floppy-disk">
                              </span>Save
                            </a>
                          </div>
                        </form>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
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
                 ...mapActions('purchaseOrder', [
                    'getPurchaseOrder'
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
                              window.location.href = "/purchaseorders/details/" + self.purchaseOrder.id;
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
      this.getCompany(this.email) 
      this.getPurchaseOrder(this.$route.params.id).then(function () {
        this.purchaseOrder = this.store.purchaseOrder;
      })
    },
    computed: mapState({
      store: state => state.purchaseOrder
    }), 
}
</script>

<style>
  /******************* Accordion Demo - 2 *****************/
#accordion .panel-title a{
    display: block;
    padding: 12px 15px 12px 50px;
    background: linear-gradient(to bottom, #fefefe, #cdcdcd);
    border: 1px solid #c3c3c3;
    border-radius: 3px;
    font-size: 18px;
    font-weight: 400;
    color: #676767;
    text-shadow: 1px 1px 1px #fff;
    position: relative;
}
#accordion .panel-title a:before{
    content: "\f068";
    font-family: "Font Awesome 5 Free";
    width: 25px;
    height: 25px;
    line-height: 25px;
    border-radius: 50%;
    background: #929191;
    font-size: 12px;
    font-weight: 900;
    color: #fdfbfb;
    text-align: center;
    box-shadow: inset 0 0 10px rgba(0,0,0,0.5);
    text-shadow: none;
    position: absolute;
    top: 8px;
    left: 15px;
}
#accordion .panel-title a.collapsed:before{ content: "\f067"; }
#accordion .panel-body{
    padding: 0px 15px;
    font-size: 15px;
    color: #222;
    line-height: 27px;
    border: none;
}
#accordion .panel-body p{ margin-bottom: 0; }
</style>
