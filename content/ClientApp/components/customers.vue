<template>
  <div>
    <h1>Customers</h1> 
    <b-container fluid>
      <b-row class="my-1">
        <b-col sm="4">
          <label for="date1">Date To Process</label>
        </b-col>
        <b-col sm="4">
          <b-form-input id="date1" type="date" v-model="date1"></b-form-input>
        </b-col>
        <b-col sm="4">
          <b-button @click="processPayments" :disabled="date1 == ''">Process Payments</b-button>
        </b-col>
      </b-row>
      <b-progress :value="value" :max="max" show-progress animated v-if="isCompleted"></b-progress>
    </b-container>
    <div v-if="!customers" class="text-center">
      <p><em>Loading...</em></p>
      <h1><icon icon="spinner" pulse /></h1>
    </div>
    <template v-if="customers">
      <b-table hover :items="customers" :fields="fields"></b-table>
    </template>
  </div>
</template>

<script>
export default { 
  data () {
    return {
      customers: null,
      total: 0,
      pageSize: 5,
      currentPage: 1,
      date1: '',
      fields: ['givenName', 'familyName', 'primarySourceMemberId','emailAddress','subscriptionPlan', 'paidUntil', 'paid'],
      value: 45,
      max: 100
    }
  }, 
  methods: {
    async loadPage () { 
      try { 
        let response = await this.$http.get(`/api/Customers`) 
        this.customers = response.data
        this.total = response.data.length
      } catch (err) {
        window.alert(err)
        console.log(err)
      } 
    },
    async processPayments() {
      var _this = this;
      this.max = this.customers.length;
      this.value = 0;
      this.customers.forEach(function (customer, index, array) {
        if (date1.value > customer.paidUntil) {
          try { 
              let response = _this.$http.get(`/api/Payments/` + customer.id) 
              customer.paid = 'paid';
              
          } catch (err) {
            window.alert(err)
            console.log(err)
          }  
        }
        _this.value++;
        if (_this.value === array.length) {
           setTimeout(function(){  _this.value = 0; }, 3000); 
        }
      }); 
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
