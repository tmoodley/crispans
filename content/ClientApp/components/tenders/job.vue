<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Create New Tender</h5>
          </div>
          <div class="card-body">
            <form-wizard @on-complete="onComplete" title="" subtitle="" color="green">
              <tab-content title="Job details"
                           icon="fa fa-user">
                <div class="row">
                  <div class="col-md-2"></div>
                  <div class="col-md-8">
                    <div class="card">
                      <div class="card-header">
                        <h5 class="title">Details</h5>
                      </div>
                      <div class="card-body">
                        <div class="row">
                          <div class="col-md-4 form-group">
                            <b-form-group label="Job Classification">
                              <b-form-radio-group v-model="job.classification"
                                                  :options="options"
                                                  name="job classification"
                                                  stacked @blur="$v.job.classification.$touch()"></b-form-radio-group>
                            </b-form-group>
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.classification.required"> This field must not be empty</p>
                          </div>
                          <div class="col-md-4 form-group">
                            <b-form-group label="Supply Sub Classification">
                              <b-form-radio-group v-model="job.supplyClassification"
                                                  :options="supplyOptions"
                                                  name="supply sub classification"
                                                  stacked @blur="$v.job.classification.$touch()"></b-form-radio-group>
                            </b-form-group>
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.classification.required"> This field must not be empty</p>
                          </div>
                          <div class="col-md-4 form-group">
                            <b-form-group label="Manufacturing Sub Classification">
                              <b-form-radio-group v-model="job.manfacturedClassification"
                                                  :options="manufactureOptions"
                                                  name="manufacturing sub classification"
                                                  stacked @blur="$v.job.classification.$touch()"></b-form-radio-group>
                            </b-form-group>
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.classification.required"> This field must not be empty</p>
                          </div>
                          </div>
                          <div class="form-group" :class="{invalid: $v.job.type.$error}">
                            <label for="Status" class="control-label">Type</label>
                            <b-form-select v-model="job.type" :options="typeOptions" class="form-control" @blur="$v.job.type.$touch()"></b-form-select>
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.type.required"> This field must not be empty</p>
                          </div>
                          <div class="form-group" :class="{invalid: $v.job.name.$error}">
                            <label for="Name" class="control-label">Name</label>
                            <input v-model="job.name" class="form-control" placeholder="Create x amount of widgets" @blur="$v.job.name.$touch()" />
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.name.required"> This field must not be empty</p>
                          </div>
                          <div class="form-group" :class="{invalid: $v.job.number.$error}">
                            <label for="Number" class="control-label">Job Number</label>
                            <input v-model="job.number" class="form-control" placeholder="JobXYZ" @blur="$v.job.number.$touch()" />
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.number.required"> This field must not be empty</p>
                          </div>
                          <div class="form-group" :class="{invalid: $v.job.status.$error}">
                            <label for="Status" class="control-label">Job Status</label>
                            <b-form-select v-model="job.status" :options="statusOptions" class="form-control" @blur="$v.job.status.$touch()"></b-form-select>
                            <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.status.required"> This field must not be empty</p>
                          </div>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-2">
                  </div>
                </div>
              </tab-content>
              <tab-content title="Company Type"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-2"></div>
                  <div class="col-md-8">
                    <h2>What type of company are you?</h2>
                    <div class="card">
                      <div class="card-body">
                        <companytype></companytype>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-2"></div>
                </div>
              </tab-content>
              <tab-content title="Industry Type"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-2"></div>
                  <div class="col-md-8">
                    <h2>What type of Industry are you?</h2>
                    <div class="card">
                      <div class="card-body">
                        <industry></industry>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-2"></div>
                </div>
              </tab-content>
              <tab-content title="NAICS"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-2"></div>
                  <div class="col-md-8">
                    <h2>Please select your NAICS code?</h2>
                    <div class="card">
                      <div class="card-body">
                        <naics></naics>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-2"></div>
                </div>
              </tab-content>
              <tab-content title="Materials"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-2"></div>
                  <div class="col-md-8">
                    <h2>What type of materials are needed?</h2>
                    <div class="card">
                      <div class="card-body">
                        <material></material>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-2"></div>
                </div>
              </tab-content>
              <tab-content title="Machines"
                           icon="fa fa-list-alt">
                <div class="row">
                  <div class="col-md-2"></div>
                  <div class="col-md-8">
                    <h2>What type of machinery is needed?</h2>
                    <div class="card">
                      <div class="card-body">
                        <machine></machine>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-2"></div>
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
                    <b-form-input v-model="job.length" placeholder="Length* mm" @blur="$v.job.length.$touch()"></b-form-input>
                    <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.length.required"> This field must not be empty</p>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.width" placeholder="Width mm" @blur="$v.job.width.$touch()"></b-form-input>
                    <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.width.required"> This field must not be empty</p>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.height" placeholder="Height  mm" @blur="$v.job.height.$touch()"></b-form-input>
                    <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.height.required"> This field must not be empty</p>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.diameter" placeholder="Diameter mm" @blur="$v.job.diameter.$touch()"></b-form-input>
                    <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.diameter.required"> This field must not be empty</p>
                  </div>
                  <div class="col-md-2">
                    <b-form-input v-model="job.minTolerance" placeholder="Min Tolerance mm" @blur="$v.job.minTolerance.$touch()"></b-form-input>
                    <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.minTolerance.required"> This field must not be empty</p>
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
                          <b-form-datepicker id="DateAvailable" v-model="job.dateAvailable" class="mb-2" @blur="$v.job.dateAvailable.$touch()"></b-form-datepicker>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.dateAvailable.required"> This field must not be empty</p>
                        </div>
                        <div class="form-group">
                          <label for="DateClosing" class="control-label">Date Closing</label>
                          <b-form-datepicker id="DateClosing" v-model="job.dateClosing" class="mb-2" @blur="$v.job.dateClosing.$touch()"></b-form-datepicker>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.diameter.required"> This field must not be empty</p>
                        </div>
                        <div class="form-group">
                          <label for="question-deadline" class="control-label">Question Deadline</label>
                          <b-form-datepicker id="question-deadline" v-model="job.questionDeadline" class="mb-2" @blur="$v.job.questionDeadline.$touch()"></b-form-datepicker>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.diameter.required"> This field must not be empty</p>
                        </div>
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
                        <div class="form-group" :class="{invalid: $v.job.estimatedAnnualValue.$error}">
                          <label for="EstimatedAnnualValue" class="control-label">Estimated Annual Value</label>
                          <input v-model="job.estimatedAnnualValue" class="form-control" @blur="$v.job.estimatedAnnualValue.$touch()" />
                          <p v-if="!$v.job.estimatedAnnualValue.decimal"> Please provide a valid estimatedAnnualValue</p>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.estimatedAnnualValue.required"> This field must not be empty</p>
                        </div>
                        <div class="form-group" :class="{invalid: $v.job.actualContractValue.$error}">
                          <label for="ActualContractValue" class="control-label">Actual Contract Value</label>
                          <input v-model="job.actualContractValue" class="form-control" @blur="$v.job.actualContractValue.$touch()" />
                          <p v-if="!$v.job.actualContractValue.decimal"> Please provide a valid actualContractValue</p>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.actualContractValue.required"> This field must not be empty</p>
                        </div>
                        <div class="form-group" :class="{invalid: $v.job.actualAnnualValue.$error}">
                          <label for="ActualAnnualValue" class="control-label">Actual Annual Value</label>
                          <input v-model="job.actualAnnualValue" class="form-control" @blur="$v.job.actualAnnualValue.$touch()" />
                          <p v-if="!$v.job.actualAnnualValue.decimal"> Please provide a valid actualAnnualValue</p>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.actualAnnualValue.required"> This field must not be empty</p>
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
                          <b-form-datepicker id="DateAvailable" v-model="job.dateAvailable" class="mb-2" @blur="$v.job.dateAvailable.$touch()"></b-form-datepicker>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.dateAvailable.required"> This field must not be empty</p>
                        </div>
                        <div class="form-group">
                          <label for="DateClosing" class="control-label">Date Closing</label>
                          <b-form-datepicker id="DateClosing" v-model="job.dateClosing" class="mb-2" @blur="$v.job.dateClosing.$touch()"></b-form-datepicker>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.dateAvailable.required"> This field must not be empty</p>
                        </div>
                        <div class="form-group">
                          <label for="question-deadline" class="control-label">Question Deadline</label>
                          <b-form-datepicker id="question-deadline" v-model="job.questionDeadline" class="mb-2" @blur="$v.job.questionDeadline.$touch()"></b-form-datepicker>
                          <p :class="{ invalided: validate }" style="color: red;" v-if="!$v.job.dateAvailable.required"> This field must not be empty</p>
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
  import companytype from './companytype.vue'
  import filetype from '../categories/filetype'
  import industry from './industry.vue'
  import machine from './machine.vue'
  import material from './material.vue'
  import naics from './naics.vue'
  import upload from '../jobs/document'
  import { required, decimal } from 'vuelidate/lib/validators'
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
    data() {
      return {
        validate: true,
        action: '',
        email: _user,
        job: {
          name: '',
          number: '',
          status: 'design',
          Classification: 'goods',
          supplyClassification: '',
          manfacturedClassification: '',
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
        ],
        supplyOptions: [
          { text: 'Raw Materials', value: 'raw materials' },
          { text: 'Unfinished Goods', value: 'unfinished goods' },
          { text: 'Finished Goods', value: 'finished goods' }
        ],
        manufactureOptions: [
          { text: 'Prototype', value: 'prototype' },
          { text: 'Onetime Production', value: 'onetime production' },
          { text: 'Ongoing Production', value: 'ongoing production' }
        ]
      }
    },
    methods: {
      ...mapActions('tenderjob', [
        'getCompany',
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
        if (this.$v.$invalid == true) {
          this.validate = false;
          self.$swal.fire('Please make sure the required field is filled properly');
        } else {
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
        }
      },
      setNda(id) {
        this.job.ndaDocumentId = id;
      },
      setTerms(id) {
        this.job.termsDocumentId = id;
      },
      setContract(id) {
        this.job.contractDocumentId = id;
      },
      setCadFile(id) {
        this.job.cadFileDocumentId = id;
      }
    },
    validations: {
      job: {
        number: { required },
        estimatedAnnualValue: { required, decimal },
        actualContractValue: { required, decimal },
        actualAnnualValue: { required, decimal },
        type: { required },
        classification: { required },
        name: { required },
        status: { required },
        length: { required },
        width: { required },
        height: { required },
        diameter: { required },
        minTolerance: { required },
        dateAvailable: { required },
        dateClosing: { required },
        questionDeadline: { required }
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

<style scoped>
  button.b-form-datepicker {
    margin: 0;
    border-radius: 2.1875rem;
  }

  button.btn.btn-sm.btn-outline-secondary.border-0.flex-fill.p-1.mx-1 {
    COLOR: blue;
  }

  .form-group.invalid label {
    color: red;
  }

  .form-group.invalid input {
    border: 1px solid red;
    background-color: #ffc9aa;
  }

  .form-group p.invalided, .col-md-2 p.invalided {
    display: none;
  }


</style>
