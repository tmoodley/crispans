<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Manage Projects</h5> 
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
                <template v-slot:cell(expand)="row">
                  <b-button size="sm" @click="row.toggleDetails" pill>{{ row.detailsShowing ? '-' : '+'}}</b-button>
                </template>
                <template v-slot:cell(components)="row">
                  <b-row class="mb-2"> 
                    <b-col><b>{{ row.item.components.length }} Components</b></b-col>
                  </b-row>
                </template>
                <template v-slot:cell(actions)="row">
                  <b-button size="sm" @click="create(row.item, row.index, $event.target)" pill>Add Component</b-button>
                  <b-button size="sm" @click="info(row.item, row.index, $event.target)" class="mr-1" pill>
                    Edit
                  </b-button>
                </template>
                <template v-slot:row-details="row">
                  <b-card> 
                      <componentList :selectedcomponent="row.item.components"></componentList>   
                  </b-card>
                </template>
              </b-table>
            </template>
          </div>
        </div>
      </div>
    </div> 
    <!-- Create Component modal -->
    <b-modal id="modal-component" title="Add Component" hide-footer>
      <component :selectedproject="selectedProject"></component>
    </b-modal>
  </div>
</template>

<script>
  import { mapState, mapActions } from 'vuex'
  import component from '../component/create'
  import componentList from '../component/list'
  import project from './project' 
export default {
  components: {
    componentList, 
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
      fields: ['expand', 'name', 'components', 'actions'],
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
