<template>
  <div class="content"> 
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">My Purchase Orders</h5>
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
                <!-- Example Classificationd slot for select state illustrative purposes -->
                <template v-slot:cell(actions)="row">
                  <b-button size="sm" @click="info(row.item, row.index, $event.target)" class="mr-1">
                    Edit
                  </b-button> 
                </template> 
              </b-table>
            </template> 
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'  
export default { 
  data () {
    return {
      jobs: null,
      selectedJob: null,
      total: 0,
      pageSize: 5,
      currentPage: 1,
      date1: '',
      selectMode: 'multi',
      fields: ['notes', 'purchaseOrderNumber','status','total', 'purchaseDate', 'deliveryDate','actions'],
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
       this.$router.push({ path: '/portal/purchaseorders/manage/' + item.id }) 
    },
    async loadPage () { 
      try { 
        let response = await this.$http.get(`/api/mypurchaseorders/?id=` + this.store.company.id) 
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
