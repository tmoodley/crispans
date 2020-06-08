<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Manage Projects</h5>
            <b-button size="sm" v-b-modal.modal-project pill variant="primary">Add Project</b-button>
          </div>
          <div class="card-body"> 
            <b-container fluid>

            </b-container>
            <div v-if="!storeProjects" class="text-center">
              <p><em>Loading...</em></p>
              <h1><icon icon="spinner" pulse /></h1>
            </div> 
            <template v-if="storeProjects">
              <b-table hover :items="storeProjects" :fields="fields">
                <!-- Example Classificationd slot for select state illustrative purposes -->
                <template v-slot:cell(actions)="row">
                  <b-button size="sm" @click="create(row.item, row.index, $event.target)" pill>Add Component</b-button>
                  <b-button size="sm" @click="info(row.item, row.index, $event.target)" class="mr-1" pill>
                    Edit
                  </b-button>
                </template>
              </b-table>
            </template>
          </div>
        </div>
      </div>
    </div>
    <!-- Create Project modal -->
    <b-modal id="modal-project" title="Add Project" hide-footer>
      <project></project>
    </b-modal>
    <!-- Create Component modal -->
    <b-modal id="modal-component" title="Add Component" hide-footer>
      <component :selectedproject="selectedJob"></component>
    </b-modal>
  </div>
</template>

<script>
  import { mapState, mapActions } from 'vuex'
  import component from '../component/create'
  import project from './project' 
export default {
    components: {
    component,
    project
  },
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
      fields: ['name', 'dateClosing', 'actions'],
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
    }, 
    async created() {
      var self = this;
      this.getCompany(this.email).then(function () { 
        self.getProjects(self.store) 
      });
  }
}
</script>

<style>
</style>
