<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="info">  
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle> 
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-brand href="/">
          <img src="../../wwwroot/images/logo-new.gif" alt="" style="width:100%; max-width:170px; min-width:130px;" class="img-fluid b-logo">
        </b-navbar-brand>
        <b-navbar-nav>
          <b-nav-item :to="'/portal/dashboard'">Dashboard</b-nav-item>
          <b-nav-item :to="'/portal/tender/search'">Find RFQ's</b-nav-item>
          <b-nav-item href="#">Propose Innovation</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">   
          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template v-slot:button-content>
              <em>User</em>
            </template>
            <b-dropdown-item :to="'/portal/profile'">Profile</b-dropdown-item>
            <b-dropdown-item :to="'/Login'">Sign Out</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar> 
    <div class="main-panel" id="main-panel">
      <b-navbar toggleable="sm" type="light" variant="secondary">
        <b-navbar-toggle target="nav-text-collapse"></b-navbar-toggle> 
        <b-collapse id="nav-text-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item :to="'/portal/projects'">Projects</b-nav-item>
            <b-nav-item :to="'/portal/proposals'">Proposals</b-nav-item>
            <b-nav-item :to="'/portal/messages'">Messages</b-nav-item>
          </b-navbar-nav>
          <!-- Right aligned nav items --> 
          <b-navbar-nav class="ml-auto" right> 
            <b-button pill variant="outline-secondary" :to="'/portal/tender/create'">Post an RFQ</b-button> 
          </b-navbar-nav> 
        </b-collapse>
      </b-navbar>
      <div class="content">
        <div v-if="alert.message" :class="`alert ${alert.type}`">{{alert.message}}</div>
        <router-view></router-view>
      </div>
      <!-- End Content -->
      <footer class="footer">
        <div class=" container-fluid ">
          <nav>
            <ul>
              <li>
                <a href="https://capacitym.com">
                  Capacitym.com
                </a>
              </li>
              <li>
                <a href="https://capacitym.com/aboutus">
                  About Us
                </a>
              </li>
              <li>
                <a href="http://blog.capacitym.com">
                  Blog
                </a>
              </li>
            </ul>
          </nav>
        </div>
      </footer>
    </div>
  </div>
</template>

<script>
    import NavMenu from './nav-menu'
    import Search from './jobs/search'

    export default {
      components: {
        'nav-menu': NavMenu,
        Search
      },

      data () {
        return {}
    },
    computed: {
        alert () {
            return this.$store.state.alert
        }
    },
    watch:{
        $route (to, from){
            // clear alert on location change
            this.$store.dispatch('alert/clear');
        }
    } 
    }
</script>

<style>
</style>
