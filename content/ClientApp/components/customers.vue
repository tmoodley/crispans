<template>
  <div>
    <h1>Customers</h1>
    <button @click="processPayments()">Process Payments</button>
    <div v-if="!customers" class="text-center">
      <p><em>Loading...</em></p>
      <h1><icon icon="spinner" pulse /></h1>
    </div> 
    <template v-if="customers">
      <table class="table">
        <thead class="dark-bg text-white">
          <tr>
            <th>Gender</th>
            <th>Given Name</th>
            <th>Family Name</th>
            <th>Subscription Plan</th>
          </tr>
        </thead>
        <tbody>
          <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(customer, index) in customers" :key="index">
            <td>{{ customer.gender }}</td>
            <td>{{ customer.givenName }}</td>
            <td>{{ customer.familyName }}</td>
            <td>{{ customer.subscriptionPlan }}</td>
          </tr>
        </tbody>
      </table> 
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
      currentPage: 1
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
      this.customers.forEach(function (customer) {
        try { 
            let response = _this.$http.get(`/api/Payments/` + customer.id) 
            console.log(response.data)
          } catch (err) {
            window.alert(err)
            console.log(err)
          } 
      });
    }
  },

  async created () {
    this.loadPage()
  }
}
</script>

<style>
</style>
