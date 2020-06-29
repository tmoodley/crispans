<template>
  <div>
    <form>
      <div class="input-group no-border">
        <input type="text" value="" class="form-control" placeholder="Search...">
        <div class="input-group-append">
          <div class="input-group-text">
            <i class="now-ui-icons ui-1_zoom-bold"></i>
          </div>
        </div>
      </div>
    </form>
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
        'addNaics',
        'removeNaics'
      ]), 
      onOptionClick({ option, addTag }) {
        addTag(option); 
        var category = this.categories.filter(x => x.name == option);
        this.addNaics(category);
        this.search = '';
      },
      onRemoveClick(tag) { 
        var category = this.categories.filter(function (x) { 
          var name = x.name.trim();
          if (name === tag.trim()) {
            return x;
          }
        }); 
        this.removeNaics(category);
      },
      getNaics() {
        var self = this; 
        var cats = [];
        if (self.store.company.customerNaics != null) {
          cats = self.store.company.customerNaics.map(x => x.naicsId);
        }
        
        return axios
          .get('/portal/api/Naics/')
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
        self.getNaics();
      }, 2000);   
    }
  }
</script>

<style>

</style>
