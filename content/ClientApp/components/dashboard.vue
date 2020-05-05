<template>
    <div>
      <div class="row">

        <!-- Total Products Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
          <div class="card border-left-primary shadow h-100 py-2">
            <div class="card-body">
              <a href='Products/Manage' class="row no-gutters align-items-center">
                  <div class="col mr-2">
                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Products</div>
                    <div class="h5 mb-0 font-weight-bold text-gray-800">{{totalProducts}}</div>
                  </div>
                  <div class="col-auto">
                    <i class="fas fa-calendar fa-2x text-gray-300"></i>
                  </div>
              </a>
            </div>
          </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
          <div class="card border-left-success shadow h-100 py-2">
            <div class="card-body">
              <a href="PurchaseOrders/Manage" class="row no-gutters align-items-center">
                <div class="col mr-2">
                  <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Purchase Orders</div>
                  <div class="h5 mb-0 font-weight-bold text-gray-800">{{totalPurchaseorders}}</div>
                </div>
                <div class="col-auto">
                  <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                </div>
              </a>
            </div>
          </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
          <div class="card border-left-info shadow h-100 py-2">
            <div class="card-body">
              <a href="tender/search" class="row no-gutters align-items-center">
                <div class="col mr-2">
                  <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Tenders</div>
                  <div class="row no-gutters align-items-center">
                    <div class="col-auto">
                      <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">{{totalTenders}}</div>
                    </div>
                  </div>
                </div>
                <div class="col-auto">
                  <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                </div>
              </a>
            </div>
          </div>
        </div>

        <!-- Pending Requests Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
          <div class="card border-left-warning shadow h-100 py-2">
            <div class="card-body">
              <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                  <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Pending Requests</div>
                  <div class="h5 mb-0 font-weight-bold text-gray-800">0</div>
                </div>
                <div class="col-auto">
                  <i class="fas fa-comments fa-2x text-gray-300"></i>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
  
import { mapState, mapActions } from 'vuex'  
export default {
  data () {
    return { 
      email: _user, 
      totalProducts: 0,
      totalPurchaseorders: 0,
      totalTenders: 0
    }
  }, 
    methods: {
    ...mapActions('company', [
        'getCompany'
    ]),
    async loadProducts () { 
      try { 
        let response = await this.$http.get(`/portal/api/Product/` + this.store.company.id)  
        this.totalProducts = response.data.length
      } catch (err) {
        window.alert(err)
        console.log(err)
      } 
    },
    async loadPurchaseorders () { 
      try { 
        let response = await this.$http.get(`/api/mypurchaseorders/?id=` + this.store.company.id)  
        this.totalPurchaseorders = response.data.length
      } catch (err) {
        window.alert(err)
        console.log(err)
      } 
    },
    async loadTenders () { 
      try { 
        let response = await this.$http.get(`/portal/api/Jobs/GetJobs/?id=` + this.store.company.id)  
        this.totalTenders = response.data.length
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
    async created() {
      var self = this;
      this.getCompany(this.email).then(function () {
        self.loadProducts();
        self.loadPurchaseorders();
        self.loadTenders();
      })
  },
  mounted: function ()  {
  }
}
</script>

<style>

</style>
