<template>
  <div class="content"> 
    <b-table hover :items="selectedcomponent" :fields="fields">
      <template v-slot:cell(expand)="row">
        <b-button size="sm" @click="row.toggleDetails" pill>{{ row.detailsShowing ? '-' : '+'}}</b-button>
      </template>
      <template v-slot:cell(jobs)="row">
        <b-row class="mb-2">
          <b-col><b>{{ row.item.jobs.length }} Jobs</b></b-col>
        </b-row>
      </template>
      <template v-slot:cell(actions)="row">
        <b-button size="sm" pill variant="primary" :to="{ name: 'createtender', params: { id: row.item.id }}">Add Job</b-button>
        <b-button size="sm" @click="info(row.item, row.index, $event.target)" class="mr-1" pill>
          Edit
        </b-button>
      </template>
      <template v-slot:row-details="row">
        <b-card>
          <jobList :selectedjobs="row.item.jobs"></jobList> 
        </b-card>
      </template>
    </b-table> 
  </div>
</template>

<script>
  import { mapState, mapActions } from 'vuex'
  import component from '../component/create'
  import jobList from '../jobs/list'
export default {
  components: {
    component,
    jobList
  },
  props: ['selectedcomponent'],
  data () {
    return {
      email: JSON.parse(localStorage.getItem('user')).username,
      jobs: null,
      selectedProject: null,
      total: 0,
      pageSize: 5,
      currentPage: 1,
      date1: '',
      selectMode: 'multi',
      fields: ['expand', 'name', 'jobs', 'actions'],
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
      ...mapActions('company', [
        'getCompany'
      ]),
      ...mapActions('project', [
        'getProjects'
      ]),
    resetInfoModal() {
      this.$bvModal.hide(this.infoModal.id)
    },
    create(item, index, button) {
      this.selectedProject = item.id;
      this.$bvModal.show("modal-component")
    },
    info(item, index, button) { 
      this.$router.push({ path: '/portal/tender/manage/' + item.id }) 
    }, 
  },
  computed: { 
    ...mapState({
      store: state => state.company
    }),
    ...mapState({
      storeProjects: state => state.project.projects
    }),
    } 
}
</script>

<style>
</style>
