<template>
  <div>
    <b-form-group label="Choose Machines">
      <b-form-tags v-model="value" no-outer-focus class="mb-2">
        <template v-slot="{ tags, disabled, addTag, removeTag }">
          <ul v-if="tags.length > 0" class="list-inline d-inline-block mb-2">
            <li v-for="tag in tags" :key="tag" class="list-inline-item">
              <b-form-tag @remove="onRemoveClick(tag);removeTag(tag);"
                          :title="tag"
                          :disabled="disabled"
                          variant="info">{{ tag }}</b-form-tag>
            </li>
          </ul> 
          <b-dropdown size="sm" variant="primary" block menu-class="w-100">
            <template v-slot:button-content>
              <b-icon icon="tag-fill"></b-icon> Choose tags
            </template>
            <b-dropdown-form @submit.stop.prevent="() => {}">
              <b-form-group label-for="tag-search-input"
                            label="Search tags"
                            label-cols-md="auto"
                            class="mb-0"
                            label-size="sm"
                            :description="searchDesc"
                            :disabled="disabled">
                <b-form-input v-model="search"
                              id="tag-search-input"
                              type="search"
                              size="sm"
                              autocomplete="off"></b-form-input>
              </b-form-group>
            </b-dropdown-form>
            <b-dropdown-divider></b-dropdown-divider>
            <b-dropdown-item-button v-for="option in availableOptions"
                                    :key="option"
                                    @click="onOptionClick({ option, addTag })">
              {{ option }}
            </b-dropdown-item-button>
            <b-dropdown-text v-if="availableOptions.length === 0">
              There are no tags available to select
            </b-dropdown-text>
          </b-dropdown>
        </template>
      </b-form-tags>
    </b-form-group>
  </div>
</template>
<script>
  import axios from 'axios'
  import { mapState, mapActions } from 'vuex' 
  export default {
    computed: mapState({
      store: state => state.company
    }), 
    data() {
      return {
        options: [],
        value: [],
        categories: [],
        search: ''
      }
    },
    computed: {
      ...mapState({
        store: state => state.company
      }), 
      criteria() {
        // Compute the search criteria
        return this.search.trim().toLowerCase()
      },
      availableOptions() {
        const criteria = this.criteria
        // Filter out already selected options
        const options = this.options.filter(opt => this.value.indexOf(opt) === -1)
        if (criteria) {
          // Show only options that match criteria
          return options.filter(opt => opt.toLowerCase().indexOf(criteria) > -1);
        }
        // Show all options available
        return options
      },
      searchDesc() {
        if (this.criteria && this.availableOptions.length === 0) {
          return 'There are no tags matching your search criteria'
        }
        return ''
      }
    },
    methods: {
      ...mapActions('company', [
        'addMachine',
        'removeMachine'
      ]), 
      onOptionClick({ option, addTag }) {
        addTag(option); 
        var category = this.categories.filter(x => x.name == option);
        this.addMachine(category);
        this.search = '';
      },
      onRemoveClick(tag) { 
        var category = this.categories.filter(x => x.name == tag);
        this.removeMachine(category);
      },
      getMachines() {
        var self = this; 
        var cats = [];
        if (self.store.company.customerMachines != null) {
          cats = self.store.company.customerMachines.map(x => x.machineId);
        }
        
        return axios
          .get('/portal/api/Machines/')
          .then(function (response) {
            self.categories = response.data;
            self.options = response.data.map(function (x) { 
              if (cats.indexOf(x.id) > -1) {
                self.value.push(x.name)
              }
              return x.name
            })
          });
      }
    },
    mounted: function () {
      var self = this;
      setTimeout(function () {
        self.getMachines();
      }, 2000);   
    }
  }
</script>

<style>

</style>
