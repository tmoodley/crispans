<template>
  <div class="content"> 
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Create New Job</h5>
          </div>
          <div class="card-body">
            <form-wizard @on-complete="onComplete" title="" subtitle="">
              <tab-content title="Job details"
                           icon="fa fa-user">
                <div class="row">
                  <div class="col-md-6">
                    <div class="card">
                      <div class="card-header">
                        <h5 class="title">Create Job</h5>
                      </div>
                      <div class="card-body">
                        <div class="form-group">
                          <b-form-group label="Job Classification">
                            <b-form-radio-group v-model="job.Scope"
                                                :options="options"
                                                name="radios-stacked"
                                                stacked></b-form-radio-group>
                          </b-form-group>
                        </div>
                        <div class="form-group">
                          <label for="Status" class="control-label">Type</label>
                          <b-form-select v-model="job.Type" :options="typeOptions" class="form-control"></b-form-select>
                        </div>
                        <div class="form-group">
                          <label for="Name" class="control-label">Name</label>
                          <input v-model="job.Name" class="form-control" placeholder="Create x amount of widgets" />
                        </div>
                        <div class="form-group">
                          <label for="Number" class="control-label">Job Number</label>
                          <input v-model="job.Number" class="form-control" placeholder="JobXYZ" />
                        </div>
                        <div class="form-group">
                          <label for="Status" class="control-label">Job Status</label>
                          <b-form-select v-model="job.Status" :options="statusOptions" class="form-control"></b-form-select>
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
                          <b-form-checkbox v-model="job.IsCloseQuestionsAfterDeadline"
                                           value="accepted"
                                           unchecked-value="not_accepted">
                            Close Questions After Deadline
                          </b-form-checkbox>
                        </div>
                        <div class="form-group form-check">
                          <b-form-checkbox v-model="job.IncludeOtherDocument"
                                           value="accepted"
                                           unchecked-value="not_accepted">
                            Include Other Document
                          </b-form-checkbox>
                        </div>
                        <div class="form-group form-check">
                          <b-form-checkbox v-model="job.AllowBidDocumentPreview"
                                           value="accepted"
                                           unchecked-value="not_accepted">
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
                          <b-form-datepicker id="DateAvailable" v-model="job.DateAvailable" class="mb-2"></b-form-datepicker>
                        </div>
                        <div class="form-group">
                          <label for="DateClosing" class="control-label">Date Closing</label>
                          <b-form-datepicker id="DateClosing" v-model="job.DateClosing" class="mb-2"></b-form-datepicker>
                        </div>
                        <div class="form-group">
                          <label for="question-deadline" class="control-label">Question Deadline</label>
                          <b-form-datepicker id="question-deadline" v-model="job.QuestionDeadline" class="mb-2"></b-form-datepicker>
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
                            <input v-model="job.EstimatedAnnualValue" class="form-control" />
                          </div>
                          <div class="form-group">
                            <label for="ActualContractValue" class="control-label">Actual Contract Value</label>
                            <input v-model="job.ActualContractValue" class="form-control" />
                          </div>
                          <div class="form-group">
                            <label for="ActualAnnualValue" class="control-label">Actual Annual Value</label>
                            <input v-model="job.ActualAnnualValue" class="form-control" />
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
                            <b-form-datepicker id="DateAvailable" v-model="job.DateAvailable" class="mb-2"></b-form-datepicker>
                          </div>
                          <div class="form-group">
                            <label for="DateClosing" class="control-label">Date Closing</label>
                            <b-form-datepicker id="DateClosing" v-model="job.DateClosing" class="mb-2"></b-form-datepicker>
                          </div>
                          <div class="form-group">
                            <label for="question-deadline" class="control-label">Question Deadline</label>
                            <b-form-datepicker id="question-deadline" v-model="job.QuestionDeadline" class="mb-2"></b-form-datepicker>
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
  import category from './categories/category'
  import certification from './categories/certification'
  import capability from './categories/capability'
  import companytype from './categories/companytype'
  import filetype from './categories/filetype'
  import industry from './categories/industry'
  import machine from './categories/machine'
  import material from './categories/material'
  import naics from './categories/naics'
  export default {
  computed: mapState({
    store: state => state.company
  }), 
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
      email: _user,
      job: {
        Name: '',
        Number: '',
        Status: 'design',
        Scope: 'goods',
        Type: 'rfp'
      },
      options: [
        { text: 'Goods', value: 'goods' },
        { text: 'Service', value: 'service' },
        { text: 'Construction', value: 'construction' }
      ],
      typeOptions: [
        { text: 'Request For Proposal', value: 'rfp' },
        { text: 'Request For Quotation', value: 'rfq' },
        { text: 'Tender', value: 'tender' }
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
    save() {
      event.preventDefault();
      var self = this; 
      return axios
        .post('/portal/api/jobs/', this.job)
        .then(response => { console.log(response.data) })
      },
      onComplete: function () {
        this.save().then(function () {
          alert('Yay. Done!');
        });
      }
    },
  mounted: function ()  {
    this.getCompany(this.email)
  }
}
</script>

<style>
  button.b-form-datepicker {
    margin: 0;
    border-radius: 2.1875rem;
}
 
</style>
