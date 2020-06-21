<template>
<div class="content">
    <div class="row">
        <div class="col-md-12">
<div class="card">
    <div class="card-header">
        <h5 class="title">{{action | capitalize}} Bid Details</h5>
    </div>
    <div class="card-body">

      
        <b-card no-body class="mb-1">

          <b-card-header header-tag="header" class="p-1" role="tab">
            <b-button block href="#" v-b-toggle.accordion-6 variant="info">General Details</b-button>
          </b-card-header>
          <b-card-body>
            <b-card-text>General Details</b-card-text>
        <div class="row">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="Status">Status</label>
                        <input type="text" v-model="bid.status" class="form-control" />
                      </div>
                    </div>  
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="Status">Status</label>
                        <input type="text" v-model="bid.source" readonly class="form-control" />
                      </div>
                    </div> 
                    
                    <!-- place the table with bid details here-->


                  </div>

            <template v-if="bid.source=='PurchaseOrder'">
                <b-table :fields="polineitemFields" :items="bid.lineItems">

                </b-table>

            </template>

            
          </b-card-body>
        </b-card>
        <b-card>
          <b-card-header header-tag="header" class="p-1" role="tab">
            <b-button block href="#" v-b-toggle.accordion-6 variant="info">Questions / Answers</b-button>
          </b-card-header>
        <b-card-body>
          <b-card-text>Question and Answer</b-card-text>
          <!-- <b-table hover :items="bid.purchaseOrder.purchaseOrderQuestions" :fields="fields">

                   </b-table> -->


          <template v-if="bid.source=='PurchaseOrder'">
           <div>
             <div class="bg-light p-4 rounded">
             <div class="row">
               <div class="col-md-12">
                 <div class="form-group">
                   <label for="">Title</label>
                   <input v-model="title" type="text" class="form-control" />
                 </div>
               </div>
             </div>
               <div class="row">
               <div class="col-md-12">
                 <div class="form-group">
                   <label for="">Body</label>
                   <input v-model="body" type="text" class="form-control" />
                 </div>
               </div>
               
             </div>

             <div class="row">
               <div class="col-md-12">
                 <div class="form-group">
                  <b-button variant="primary" class="float-right">Ask</b-button>
                 </div>
               </div>
               
             </div>

</div>
              <ul>
                  <question v-for="(item,index) in bid.purchaseOrder.purchaseOrderQuestions" v-bind:title="item.question.title"
                  v-bind:body="item.question.body"
                   :key="index"></question>
              </ul>
           </div>
           </template>
           <template v-if="bid.source=='Tender'">
           <div>
              <ul>
                  <question v-for="(item,index) in bid.job.jobQuestions" v-bind:title="item.question.title"
                  v-bind:body="item.question.body"
                   :key="index"></question>
              </ul>
           </div>
           </template>

        </b-card-body>



        </b-card>

        <b-card>
          <b-card-header header-tag="header" class="p-1" role="tab">
            <b-button block href="#" v-b-toggle.accordion-6 variant="info">Documents</b-button>
          </b-card-header>
        <b-card-body>
          <b-card-text>Bid Documents</b-card-text>
          <!-- <b-table hover :items="bid.purchaseOrder.purchaseOrderQuestions" :fields="fields">

                   </b-table> -->


           <div>
             
           </div>

        </b-card-body>



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
    import question from '../question/question'


    


    export default {
      components:{
        question
      },
        name: '',
        data() {
            return {
              srctype:'', //Purchase Order or Tender
              title:'',
              body:'',
              action: '',
              fields:[
                { key:'question.title', label:'title'},
                { key:'question.body',label:'body'},
                'actions'],
              polineitemFields:[
                {key:'item', label:'Item'},
                                { key:'description',label:'Description'},
                                { key:'quantity', label:'Quantity'},
                                 { key:'amount', label:'Amount'}
              ]
            }
        },
        methods:{
            ...mapActions('bid', [
                    'getBid'
                ]),
            sendReply(){

            }

        },
        computed: {

            ...mapState({
          store: state => state.bid
            }),
          ...mapState({
          bid: state => state.bid.bid
        })
        },
        mounted(){

            var self = this;
         
          if ((this.$route.params.docid != undefined) && (this.$route.params.bidderid != undefined)) {
           debugger;
            var id =  this.$route.params.docid + '/' + this.$route.params.bidderid+'/'+this.$route.params.src;
                this.getBid(id).then(function(data){
                    self.action = 'edit'
                    //self.bid = self._bid.bid
                    console.log(JSON.stringify(data));
                })
            }

        }
    }
</script>

<style  scoped>
    
</style>
