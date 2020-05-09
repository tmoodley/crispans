<template>
<div class="content">
    <div class="row">
        <div class="col-md-12">
<div class="card">
    <div class="card-header">
        <h5 class="title">{{action | capitalize}} Question Details</h5>
    </div>
    <div class="card-body">
        <b-card>
            
                
                  <div class="row">
                    <div class="col-md-12">
                      <div class="form-group">
                        <label for="Title">Title</label>
                        <input type="text" v-model="question.title" class="form-control" readonly />
                      </div>
                    </div>  
                    
                    
                    <!-- place the table with question details here-->


                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="form-group">
                        <label for="Body">Body</label>
                        <input type="text" v-model="question.body" class="form-control" readonly />
                      </div>
                    </div>  
                  </div>


               
                <div class="row">
                  <div class="col-md-10 mt-2">
                    <input v-model="response" type="text" class="form-control" placeholder="response" />
                  </div>
                  <div class="col-md-1">
                    <b-button variant="success" @click="sendReply"> Reply</b-button>
                  </div>
                </div>
                

                  <div class="row bg-dark text-white p-2 m-1">

                      <div class="col-md-6">
                          <h5>  Answers</h5>
                      </div>
                      

                  </div>

                  <div class="row">
                   <b-table hover :items="question.answers" :fields="fields">

                   </b-table>


                    <!-- place the table with question details here-->


                  </div>

                
                
           
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
              fields:['body'],
              response:''
            }
        },
        methods:{
            ...mapActions('question', [
                    'getQuestion'
                ]),
            sendReply(){
alert('This is the reply');
            }

        },
        computed: {

            ...mapState({
          store: state => state.question
            }),
          ...mapState({
          question: state => state.question.question
        })
        },
        mounted(){

            var self = this;
           
         
           var id = this.$route.params.id;
           
                this.getQuestion(id).then(function(){
                    self.action = 'edit'
                    //self.question = self._bid.question
                });
            

        }
    }
</script>

<style  scoped>
    
</style>
