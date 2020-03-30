<template>
  <div class="content"> 
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Create New Tender</h5>
          </div>
          <div class="card-body">
            <form-wizard @on-complete="onComplete" title="" subtitle="">
              <tab-content title="Job details"
                           icon="fa fa-user">
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
                  <div class="col-md-6">
                    <div class="card card-user">
                      <div class="card-body">
                        <category></category>
                        <certification></certification>
                      </div>
                    </div>
                  </div>
                </div>
              </tab-content>
              <tab-content title="Description"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-12">
                    <b-form-input v-model="job.title" placeholder="Title"></b-form-input>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-12">
                    <wysiwyg v-model="job.description" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6">
                    <b-form-input v-model="job.quantity" placeholder="Quantity"></b-form-input>
                  </div>
                  <div class="col-md-6">
                    <b-form-input v-model="job.price" placeholder="Price"></b-form-input>
                  </div>
                </div>
                <div class="row"> 
                  <div class="col-md-12"><h2>Workpiece Data</h2></div>
                  <div class="col-md-12"><h3>Dimensions</h3></div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.length" placeholder="Length* mm"></b-form-input>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.width" placeholder="Width mm"></b-form-input>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.height" placeholder="Height  mm"></b-form-input>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.diameter" placeholder="Diameter mm"></b-form-input>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.minTolerance" placeholder="Min Tolerance mm"></b-form-input>
                  </div>
                </div>
              </tab-content>
              <tab-content title="Question Info"
                           icon="fa fa-question">
                <div class="row">
                  <div class="col-md-6">
                    <div class="card">
                      <div class="card-header">
                        <h5 class="title">Job Question Info</h5>
                      </div>
                      <div class="card-body">
                        <div class="form-group form-check">
                          <b-form-checkbox v-model="job.isCloseQuestionsAfterDeadline"
                                           value="true"
                                           unchecked-value="false">
                            Close Questions After Deadline
                          </b-form-checkbox>
                        </div>
                        <div class="form-group form-check">
                          <b-form-checkbox v-model="job.includeOtherDocument"
                                           value="true"
                                           unchecked-value="false">
                            Include Other Document
                          </b-form-checkbox>
                        </div>
                        <div class="form-group form-check">
                          <b-form-checkbox v-model="job.allowBidDocumentPreview"
                                           value="true"
                                           unchecked-value="false">
                            Allow Job Document Preview
                          </b-form-checkbox>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="card">
                      <div class="card-header">
                        <h5 class="title">Job Dates</h5>
                      </div>
                      <div class="card-body">
                        <div class="form-group">
                          <label for="DateAvailable" class="control-label">Date Available</label>
                          <b-form-datepicker id="DateAvailable" v-model="job.dateAvailable" class="mb-2"></b-form-datepicker>
                        </div>
                        <div class="form-group">
                          <label for="DateClosing" class="control-label">Date Closing</label>
                          <b-form-datepicker id="DateClosing" v-model="job.dateClosing" class="mb-2"></b-form-datepicker>
                        </div>
                        <div class="form-group">
                          <label for="question-deadline" class="control-label">Question Deadline</label>
                          <b-form-datepicker id="question-deadline" v-model="job.questionDeadline" class="mb-2"></b-form-datepicker>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </tab-content>
              <tab-content title="Job Categories"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-4">
                    <div class="card">
                      <div class="card-body">
                        <companytype></companytype>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="card">
                      <div class="card-body">
                        <filetype></filetype>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="card">
                      <div class="card-body">
                        <industry></industry>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-4">
                    <div class="card">
                      <div class="card-body">
                        <machine></machine>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="card">
                      <div class="card-body">
                        <material></material>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="card">
                      <div class="card-body">
                        <naics></naics>
                      </div>
                    </div>
                  </div>
                </div>
              </tab-content>
              <tab-content title="Documents step"
                           icon="fa fa-file">
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
                    <b-button class="float-right" v-if="job.ndaDocumentId" @click="download(job.ndaDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                  </div>
                  <div class="col-md-12">
                    <upload @setid="setNda"></upload>
                  </div>
                  <div class="col-md-6">
                    Contract File
                  </div>
                  <div class="col-md-6">
                    <b-button class="float-right" v-if="job.termsDocumentId" @click="download(job.termsDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                  </div>
                  <div class="col-md-12">
                    <upload @setid="setContract"></upload>
                  </div>
                  <div class="col-md-6">
                    Terms and Conditions File
                  </div>
                  <div class="col-md-6">
                    <b-button class="float-right" v-if="job.contractDocumentId" @click="download(job.contractDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                  </div>
                  <div class="col-md-12">
                    <upload @setid="setTerms"></upload>
                  </div>
                  <div class="col-md-6">
                    3D Visualizations File
                  </div>
                  <div class="col-md-6">
                    <b-button class="float-right" v-if="job.cadFileDocumentId " @click="download(job.cadFileDocumentId)"><i class="fa fa-download" aria-hidden="true"></i> Download</b-button>
                  </div>
                  <div class="col-md-12">
                    <upload @setid="setCadFile"></upload>
                  </div>
                </div>
              </tab-content>
              <tab-content title="Last step"
                           icon="fa fa-check">
                <div class="row">
                  <div class="col-md-6">
                    <div class="card">
                      <div class="card-header">
                        <h5 class="title">Job Value</h5>
                      </div>
                      <div class="card-body">
                        <div class="form-group">
                          <label for="EstimatedAnnualValue" class="control-label">Estimated Annual Value</label>
                          <input v-model="job.estimatedAnnualValue" class="form-control" />
                        </div>
                        <div class="form-group">
                          <label for="ActualContractValue" class="control-label">Actual Contract Value</label>
                          <input v-model="job.actualContractValue" class="form-control" />
                        </div>
                        <div class="form-group">
                          <label for="ActualAnnualValue" class="control-label">Actual Annual Value</label>
                          <input v-model="job.actualAnnualValue" class="form-control" />
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="card">
                      <div class="card-header">
                        <h5 class="title">Job Dates</h5>
                      </div>
                      <div class="card-body">
                        <div class="form-group">
                          <label for="DateAvailable" class="control-label">Date Available</label>
                          <b-form-datepicker id="DateAvailable" v-model="job.dateAvailable" class="mb-2"></b-form-datepicker>
                        </div>
                        <div class="form-group">
                          <label for="DateClosing" class="control-label">Date Closing</label>
                          <b-form-datepicker id="DateClosing" v-model="job.dateClosing" class="mb-2"></b-form-datepicker>
                        </div>
                        <div class="form-group">
                          <label for="question-deadline" class="control-label">Question Deadline</label>
                          <b-form-datepicker id="question-deadline" v-model="job.questionDeadline" class="mb-2"></b-form-datepicker>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </tab-content>
            </form-wizard>
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
  import upload from '../jobs/document'
  export default {
    props: ['selectedjob'],
  computed: mapState({
    store: state => state.company
  }), 
    components: {
    upload,
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
      email: _user,
      job: {
        name: '',
        number: '',
        status: 'design',
        Classification: 'goods',
        type: 'rfp'
      },
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
            if (self.action == 'edit') {
              self.$emit("hide");
            }
            else {
              self.$router.push({ path: '/portal/rfq/' })
            }
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
      if (typeof (this.selectedjob) !== "undefined" && this.selectedjob !== null) {
        this.job = this.selectedjob;
        this.action = 'edit';
      }
      else {
        this.action = 'add';
      }
      this.getCompany(this.email)
  }
}
</script>

<style>
  button.b-form-datepicker {
    margin: 0;
    border-radius: 2.1875rem;
}
 button.btn.btn-sm.btn-outline-secondary.border-0.flex-fill.p-1.mx-1 {
    COLOR: blue;
}
</style>
