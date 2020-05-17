<template>
  <div>
    <form v-on:submit="onComplete">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="panel-group" id="accordion">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                      <span class="glyphicon glyphicon-file">
                      </span>Create Purchase Order
                    </a>
                  </h4>
                </div>
                <div id="collapseOne" class="panel-collapse in collapse show">
                  <div class="panel-body">
                    <div class="row">
                      <div class="col-md-6">
                        <div class="card">
                          <div class="card-header">
                            <h5 class="title">Details</h5>
                          </div>
                          <div class="card-body">
                            <div class="form-group">
                              <b-form-group label="Job Classification">
                                <b-form-radio-group v-model="job.classification"
                                                    :options="options"
                                                    name="radios-stacked"
                                                    stacked></b-form-radio-group>
                              </b-form-group>
                            </div>
                            <div class="form-group">
                              <label for="Status" class="control-label">Type</label>
                              <b-form-select v-model="job.type" :options="typeOptions" class="form-control"></b-form-select>
                            </div>
                            <div class="form-group">
                              <label for="Name" class="control-label">Name</label>
                              <input v-model="job.name" class="form-control" placeholder="Create x amount of widgets" />
                            </div>
                            <div class="form-group">
                              <label for="Number" class="control-label">Job Number</label>
                              <input v-model="job.number" class="form-control" placeholder="JobXYZ" />
                            </div>
                            <div class="form-group">
                              <label for="Status" class="control-label">Job Status</label>
                              <b-form-select v-model="job.status" :options="statusOptions" class="form-control"></b-form-select>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-6" v-if="action == 'edit'">
                        <div class="card card-user">
                          <div class="card-body">
                            <category :job="selectedjob"></category>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-12">
            <div class="form-group">
              <input type="submit" value="Create" class="btn btn-primary pull-right" />
            </div>
          </div>
        </div>
      </div>
    </form>
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
  export default {
    props: ['selectedjob'],
 
    computed: { 
        ...mapState({
          store: state => state.company
        }),
        ...mapState({
          job: state => state.job.job
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
  data () {
    return {
      action: '',
      email: JSON.parse(localStorage.getItem('user')).username,
      //job: {
      //  name: '',
      //  number: '',
      //  status: 'design',
      //  Classification: 'goods',
      //  type: 'rfp'
      //},
      options: [
        { text: 'Goods', value: 'goods' },
        { text: 'Service', value: 'service' },
        { text: 'Construction', value: 'construction' }
      ],
      typeOptions: [
        { text: 'Request For Proposal', value: 'rfp' },
        { text: 'Request For Quotation', value: 'rfq' },
        { text: 'Tender', value: 'tender' },
        { text: 'Auction', value: 'auction' }
      ],
      statusOptions: [ 
        { value: 'design', text: 'Job Design' },
        { value: 'start', text: 'Job Started' },  
        { value: 'completed', text: 'Job Completed' },  
        { value: 'awarded', text: 'Job Awarded' },  
      ]
      }
    },
    methods: {
    ...mapActions('company', [
        'getCompany'
    ]),
    ...mapActions('job', [
        'getJob'
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
        if (self.action == "edit") { 
          return axios
            .put('/portal/api/jobs/PutJob/' + self.job.id, self.job)
            .then(response => { console.log(response.data) })
        }
        else {
          this.job.CustomerId = this.store.company.id;
          return axios
            .post('/portal/api/jobs/PostJob/', self.job)
            .then(response => { console.log(response.data) })
        } 
      },
      onComplete: function () {
        var self = this;
        this.save().then(function () { 
          self.$swal.fire(
            'Saved',
            'Job Saved',
            'success'
          ).then(function () { 
              self.$router.push({ path: '/tenders/manage/' }) 
          })
        });
      },
      setNda(id) { 
        this.job.ndaDocumentId = id;
      },
      setTerms(id){
          this.job.termsDocumentId = id;
      },
      setContract(id){
          this.job.contractDocumentId = id;
      },
      setCadFile(id){
          this.job.cadFileDocumentId = id;
      }
  },
    mounted: function () {
      var self = this; 
      this.action = 'add'; 
      if (this.$route.params.id != undefined) {
          this.getJob(this.$route.params.id).then(function () { 
             self.action = 'edit';
          })
      }
     
      this.getCompany(this.email)
  }
}
</script>

<style>
  /******************* Accordion Demo - 2 *****************/
  #accordion .panel-title a {
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

    #accordion .panel-title a:before {
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

    #accordion .panel-title a.collapsed:before {
      content: "\f067";
    }

  #accordion .panel-body {
    padding: 0px 15px;
    font-size: 15px;
    color: #222;
    line-height: 27px;
    border: none;
  }

    #accordion .panel-body p {
      margin-bottom: 0;
    }
</style>
