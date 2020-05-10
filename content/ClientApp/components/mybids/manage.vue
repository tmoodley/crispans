<template>
    <div class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="title">{{action | capitalize}} My Bids</h5>
                </div>
                <div class="card-body">
                    <b-card>

            <div v-if="!myBids" class="text-center">
              <p><em>Loading...</em></p>
              <h1><icon icon="spinner" pulse /></h1>
            </div>

                    <template v-if="myBids">
                        <b-table :fields="fields" :items="myBids">
                        <template v-slot:cell(actions)="row">
                            <b-button size="sm" @click="viewBid(row.item.id,row.item.bidderId,row.item.source)" class="mr-1">
                            View Bid
                            </b-button>
                        </template>
                        </b-table>
                    </template>

                   

                    </b-card>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>
import axios from 'axios'
import router from '../../router/index'

    export default {
        name: '',

        data() {
            return {
                source:'',
                action:'List',
                myBids:null,
                fields:[
                    {
                        key: 'number',
                        label: 'Number'
                    },{
                        key: 'name',
                        label: 'Name'
                    },
                    {
                        key: 'bidStatus',
                        label: 'Bid Status'
                    },
                    {
                        key: 'jobStatus',
                        label: 'Job Status'
                    },
                    {
                        key: 'source',
                        label: 'Source'
                    },
                   'actions'
                ]
                
            }
        },
        methods: {
            loadData(){
                
                var self = this;
                
                axios({

          url: '/api/mypobids/',

          method: 'GET', 

        }).then(function (bids) {
          
                self.myBids = bids.data;

                
            })
            
            },
            viewBid(id,bidderid,src){

                 debugger;
                
                var source = (src=='Purchase Order')?'PurchaseOrder':'Tender'

                var link = '/portal/Bids/Manage/'+id+'/'+bidderid+'/'+source;
                                router.push(link);
            }
        },
        mounted(){
            this.loadData();
        }
    }
</script>

<style scoped>
    
</style>