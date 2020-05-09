<template>
<div class="content">
    <div class="row">
        <div class="col-md-12">
<div class="card">
    <div class="card-header">
        <h5 class="title">{{action | capitalize}} Bid Details</h5>
    </div>
    <div class="card-body">
        <b-card>
            <b-tabs card>
                <b-tab body title="Details">
                  <div class="row">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="Status">Status</label>
                        <input type="text" v-model="bid.status" class="form-control" />
                      </div>
                    </div>  
                    
                    
                    <!-- place the table with bid details here-->


                  </div>

                </b-tab>
                <b-tab body title="Questions">
                  <!-- place communication here-->

                  <div class="row">
                   <b-table hover :items="bid.purchaseOrder.purchaseOrderQuestions.question" :fields="fields">

                   </b-table>


                    <!-- place the table with bid details here-->


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
    

    export default {
        name: '',
        data() {
            return {
                
              action: '',
              fields:['title','body']
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
         
          if ((this.$route.params.poid != undefined) && (this.$route.params.bidderid != undefined)) {
           
            var id =  this.$route.params.poid + '/' + this.$route.params.bidderid;
                this.getBid(id).then(function(){
                    self.action = 'edit'
                    //self.bid = self._bid.bid
                })
            }

        }
    }
</script>

<style  scoped>
    
</style>
