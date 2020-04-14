<template>
  <div> 
    <nav-menu params="route: route"></nav-menu>
    <h1>Manage</h1>
    <hr />
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
              <div id="collapseOne" class="panel-collapse in collapse show">
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
                          <input v-model="purchaseOrder.purchaseDate" type="datetime-local" class="form-control" />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="form-group">
                          <label for="DeliveryDate" class="control-label">Delivery Date</label>
                          <input v-model="purchaseOrder.deliveryDate" type="datetime-local" class="form-control" />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="form-group">
                          <label for="PurchaseOrderNumber" class="control-label">Purchase Order Number</label>
                          <input v-model="purchaseOrder.purchaseOrderNumber" class="form-control" />
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
                    <div class="row" v-for="(item, index) in purchaseOrder.purchaseOrderItems">
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
                          <textarea name="notes" id="notes" class="form-control" v-model="purchaseOrder.notes"></textarea>
                        </div>
                      </div>
                      <div class="col-md-4">
                        <div class="summary-grid">
                          <div class="summary-total">
                            <h5 class="total-label">
                              Total
                            </h5>
                            <span id="Total" class="PurchaseOrderTotal">{{purchaseOrder.total  | currency}}</span>
                          </div>
                        </div>
                        <div class="form-group">
                          <input type="submit" value="Update" class="btn btn-primary" />
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
                      <b-form-checkbox switch size="lg" class="float-left">NDA (NON DISCLOSURE AGREEMENT)</b-form-checkbox>
                      <i id="tooltip-nda" class="fas fa-info-circle float-left"></i>
                      <b-tooltip target="tooltip-nda">NON DISCLOSURE AGREEMENT</b-tooltip>
                    </div>
                    <div class="col-md-12">If you upload and NDA, bidding companies need to first sign the uploaded NDA before viewing documents.</div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <h3>File Upload</h3>
                      <p>In this section, you can upload your JOB related documents such as NDA's, Contracts, General Terms and Conditions, etc</p>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      NDA File
                    </div>
                    <div class="col-md-6">
                      <b-button class="float-right" v-if="purchaseOrder.ndaDocumentId" @click="download(purchaseOrder.ndaDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                    </div>
                    <div class="col-md-12">
                      <upload @setid="setNda"></upload>
                    </div>
                    <div class="col-md-6">
                      Contract File
                    </div>
                    <div class="col-md-6">
                      <b-button class="float-right" v-if="purchaseOrder.termsDocumentId" @click="download(purchaseOrder.termsDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                    </div>
                    <div class="col-md-12">
                      <upload @setid="setContract"></upload>
                    </div>
                    <div class="col-md-6">
                      Terms and Conditions File
                    </div>
                    <div class="col-md-6">
                      <b-button class="float-right" v-if="purchaseOrder.contractDocumentId" @click="download(purchaseOrder.contractDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                    </div>
                    <div class="col-md-12">
                      <upload @setid="setTerms"></upload>
                    </div>
                    <div class="col-md-6">
                      3D Visualizations File
                    </div>
                    <div class="col-md-6">
                      <b-button class="float-right" v-if="purchaseOrder.cadFileDocumentId " @click="download(purchaseOrder.cadFileDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                    </div>
                    <div class="col-md-12">
                      <upload @setid="setCadFile"></upload>
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
                      <div class="card card-user">
                        <div class="card-body">
                          <category></category>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Messages
                  </a>
                </h4>
              </div>
              <div id="collapseFour" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card card-user">
                        <div class="card-body">
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Questions/Answer
                  </a>
                </h4>
              </div>
              <div id="collapseFive" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card card-user">
                        <div class="card-body">
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Notifications
                  </a>
                </h4>
              </div>
              <div id="collapseSix" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card card-user">
                        <div class="card-body">
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Notes
                  </a>
                </h4>
              </div>
              <div id="collapseSeven" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card card-user">
                        <div class="card-body">
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading">
                <h4 class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                    <span class="glyphicon glyphicon-th-list">
                    </span>Bids
                  </a>
                </h4>
              </div>
              <div id="collapseEight" class="panel-collapse collapse">
                <div class="panel-body">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="card card-user">
                        <div class="card-body">
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
  </div>
</template>

<script>
  import axios from 'axios' 
  import { mapState, mapActions } from 'vuex' 
  import category from '../categories/category' 
  import upload from '../purchaseorders/document'
  export default {
        components: {
          upload,
          category, 
        },
        data() {
           return {
                email: _user,
                loading: false,
                purchaseOrder: {}
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
                  return axios
                    .put('/api/purchaseorders/' + self.purchaseOrder.id , self.purchaseOrder)
                    .then(response => { 
                     console.log(response)
                    }).then(function (data) {
                       self.purchaseOrder = data
                    })
                  },
                  onComplete: function () {
                        var self = this;
                        this.save().then(function () { 
                          self.$swal.fire(
                            'Saved',
                            'Job Saved',
                            'success'
                          )
                        });
                  }, 
                  addLine() {
                      this.purchaseOrder.purchaseOrderItems.push({
                          item: '',
                          description: '',
                          quantity: 0,
                          amount: 0.00
                      });

                  },
                  addTotal() {
                      var _this = this;
                      this.purchaseOrder.purchaseOrderItems.map(item => {
                          _this.purchaseOrder.total += item.quantity * item.amount;
                      })
                  },
                  removeLine(index) {
                      var _this = this;
                      const _index = this.purchaseOrder.purchaseOrderItems.indexOf(index);
                      if (index > -1) {
                        this.purchaseOrder.purchaseOrderItems.splice(_index, 1);
                      }
                      this.purchaseOrder.total = 0;
                      this.purchaseOrder.purchaseOrderItems.map(item => {
                            _this.purchaseOrder.total += item.quantity * item.amount;
                      })
         },
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
              setNda(id) { 
                this.purchaseOrder.ndaDocumentId = id;
              },
              setTerms(id){
                  this.purchaseOrder.termsDocumentId = id;
              },
              setContract(id){
                  this.purchaseOrder.contractDocumentId = id;
              },
              setCadFile(id){
                  this.purchaseOrder.cadFileDocumentId = id;
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
      this.getCompany(this.email);
      var self = this;
      this.getPurchaseOrder(this.$route.params.id).then(function () { 
        self.purchaseOrder = self.store.purchaseOrder;
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
