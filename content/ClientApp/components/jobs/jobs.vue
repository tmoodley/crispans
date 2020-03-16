<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">JOBS</h5>
          </div>
          <div class="card-body">
            <b-container fluid>

            </b-container>
            <div v-if="!jobs" class="text-center">
              <p><em>Loading...</em></p>
              <h1><icon icon="spinner" pulse /></h1>
            </div>
            <template v-if="jobs">
              <b-table hover :items="jobs" :fields="fields">
                <!-- Example scoped slot for select state illustrative purposes -->
                <template v-slot:cell(actions)="row">
                  <b-button size="sm" @click="info(row.item, row.index, $event.target)" class="mr-1">
                    Edit
                  </b-button>
                  <b-button size="sm" @click="row.toggleDetails">
                    {{ row.detailsShowing ? 'Hide' : 'Show' }} View Bids
                  </b-button>
                </template>
                <template v-slot:row-details="row">
                  <b-card>
                    <ul>
                      <li v-for="(value, key) in row.item" :key="key">{{ key }}: {{ value }}</li>
                    </ul>
                  </b-card>
                </template>
              </b-table>
            </template>
            <!-- Info modal -->
            <b-modal :id="infoModal.id" :title="infoModal.title" size="xl" hide-footer @hide="resetInfoModal">
              <job :selectedjob="infoModal.job" :action="edit" @hide="resetInfoModal"></job>
            </b-modal>
          </div>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
import { mapState } from 'vuex' 
import job from './job'
export default {
  components: {
    job
  },
  data () {
    return {
      jobs: null,
      selectedJob: null,
      total: 0,
      pageSize: 5,
      currentPage: 1,
      date1: '',
      selectMode: 'multi',
      fields: ['name', 'number', 'scope','status','totalContractAmount', 'dateClosing', 'awarded','actions'],
      value: 45,
      max: 100, 
      selected: [],
      infoModal: {
        id: 'info-modal',
        title: '',
        job: null
      }
    }
  }, 
  methods: {
    resetInfoModal() {
      this.$bvModal.hide(this.infoModal.id)
    },
    info(item, index, button) {
      this.infoModal.title = `View RFQ: Job`;
      this.infoModal.job = item;
      this.$root.$emit('bv::show::modal', this.infoModal.id, button);
    },
    async loadPage () { 
      try { 
        let response = await this.$http.get(`/portal/api/Jobs/GetJobs/?id=` + this.store.company.id) 
        this.jobs = response.data
        this.total = response.data.length
      } catch (err) {
        window.alert(err)
        console.log(err)
      } 
    }, 
  },
  computed: { 
    ...mapState({
      store: state => state.company
    }),
  },
  async created () {
    this.loadPage()
  }
}
</script>

<style>
</style>
