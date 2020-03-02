<template>
  <div class="content">
    <div class="row">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="title">Create New Job</h5>
          </div>
          <div class="card-body"> 
            <b-container fluid>
              <b-row class="my-1">
                <b-col sm="4">
                  <label for="date1">Date To Process</label>
                </b-col>
                <b-col sm="4">
                  <b-form-input id="date1" type="date" v-model="date1"></b-form-input>
                </b-col>
                <b-col sm="4"> 
                  <b-button size="sm" @click="selectAllRows">Select all</b-button>
                  <b-button size="sm" @click="clearSelected">Clear selected</b-button>
                </b-col>
              </b-row>
              <b-progress :value="value" :max="max" show-progress animated v-if="isCompleted"></b-progress>
            </b-container>
            <div v-if="!jobs" class="text-center">
              <p><em>Loading...</em></p>
              <h1><icon icon="spinner" pulse /></h1>
            </div>
            <template v-if="jobs">
              <b-table hover :items="jobs" :fields="fields" selectable
                       ref="selectableTable"
                       :select-mode="selectMode"
                       @row-selected="onRowSelected">
                <!-- Example scoped slot for select state illustrative purposes -->
                <template v-slot:cell(selected)="{ rowSelected }">
                  <template v-if="rowSelected">
                    <span aria-hidden="true">&check;</span>
                    <span class="sr-only">Selected</span>
                  </template>
                  <template v-else>
                    <span aria-hidden="true">&nbsp;</span>
                    <span class="sr-only">Not selected</span>
                  </template>
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
export default { 
  data () {
    return {
      jobs: null,
      total: 0,
      pageSize: 5,
      currentPage: 1,
      date1: '',
      selectMode: 'multi',
      fields: ['selected', 'name', 'number', 'scope','status','totalContractAmount', 'dateClosing', 'awarded'],
      value: 45,
      max: 100, 
      selected: []
    }
  }, 
  methods: {
    onRowSelected(items) {
        this.selected = items
    },
    selectAllRows() {
      this.$refs.selectableTable.selectAllRows()
    },
    clearSelected() {
      this.$refs.selectableTable.clearSelected()
    },
    async loadPage () { 
      try { 
        let response = await this.$http.get(`/portal/api/Jobs`) 
        this.jobs = response.data
        this.total = response.data.length
      } catch (err) {
        window.alert(err)
        console.log(err)
      } 
    }, 
  },
  computed: {
    // a computed getter
    isCompleted: function () {
      // `this` points to the vm instance
      return this.max == this.value
    }
  },
  async created () {
    this.loadPage()
  }
}
</script>

<style>
</style>
