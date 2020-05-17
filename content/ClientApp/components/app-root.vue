<template>
  <div>
    <div class="sidebar" data-color="orange" id="app">
      <!--
        Tip 1: You can change the color of the sidebar using: data-color="blue | green | orange | red | yellow"
    -->
      <div class="logo"> 
        <a href="https://capacitym.com" class="simple-text logo-normal">
          Capacitym.com
        </a>
      </div> 
        <perfect-scrollbar class="sidebar-wrapper" id="sidebar-wrapper">
          <nav-menu params="route: route"></nav-menu>
        </perfect-scrollbar> 
    </div>
    <div class="main-panel" id="main-panel">
      <!-- Navbar -->
      <nav class="navbar navbar-expand-lg navbar-transparent  bg-primary  navbar-absolute">
        <div class="container-fluid">
          <div class="navbar-wrapper">
            <div class="navbar-toggle">
              <button type="button" class="navbar-toggler">
                <span class="navbar-toggler-bar bar1"></span>
                <span class="navbar-toggler-bar bar2"></span>
                <span class="navbar-toggler-bar bar3"></span>
              </button>
            </div>
            <a class="navbar-brand" href="#pablo">User Profile</a>
          </div>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navigation" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-bar navbar-kebab"></span>
            <span class="navbar-toggler-bar navbar-kebab"></span>
            <span class="navbar-toggler-bar navbar-kebab"></span>
          </button>
          <div class="collapse navbar-collapse justify-content-end" id="navigation">
            <Search></Search>
            <ul class="navbar-nav"> 
              <li class="nav-item">
                <router-link :to="'/Login'">
                  <i class="now-ui-icons users_single-02"></i>
                  <p>
                    <span class="d-lg-none d-md-block">Logout</span>
                  </p>
                </router-link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <!-- End Navbar -->
      <div class="panel-header panel-header-sm">
      </div>
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
