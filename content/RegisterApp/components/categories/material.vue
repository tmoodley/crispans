<template>
  <div>
    <b-form-group label="Please Select Your Materials">
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
          <div class="d-inline-block" style="font-size: 1.5rem;">
            <b-button pill
                      variant="primary"
                      v-for="option in availableOptions"
                      @click="onOptionClick(option);addTag(option);">
              {{ option }}
            </b-button>
          </div>
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
        'addMaterial',
        'removeMaterial'
      ]), 
      onOptionClick(option) {
        var category = this.categories.filter(x => x.name == option);
        this.addMaterial(category);
        this.search = '';
      },
      onRemoveClick(tag) { 
        var category = this.categories.filter(x => x.name == tag);
        this.removeMaterial(category);
      },
      getMaterials() {
        var self = this; 
        var cats = [];
        if (self.store.company.customerMaterials != null) {
          cats = self.store.company.customerMaterials.map(x => x.materialId);
        }
        
        return axios
          .get('/portal/api/Materials/')
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
        self.getMaterials();
      }, 2000);   
    }
  }
</script>

<style scoped>
  .rounded-pill {
    border-radius: 50rem !important;
    padding: 10px;
    margin: 10px;
  }

  .b-form-tag {
    border-radius: 50rem !important;
    padding: 10px;
    margin: 10px;
  }
</style>
