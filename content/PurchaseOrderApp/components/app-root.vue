<template>
  <div>
    <div class="sidebar" data-color="orange" id="app">
      <!--
        Tip 1: You can change the color of the sidebar using: data-color="blue | green | orange | red | yellow"
    --> 
      <div class="sidebar-wrapper" id="sidebar-wrapper">
        <nav-menu params="route: route"></nav-menu>
      </div>
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
            <ul class="navbar-nav"> 
              <li class="nav-item">
                <router-link :to="{ name: 'Dashboard' }">
                  <i class="now-ui-icons users_single-02"></i>
                  <p>
                    <span class="d-lg-none d-md-block">Account</span>
                  </p> 
                </router-link> 
              </li>
            </ul>
          </div>
        </div>
      </nav> 
      <div class="content">
        <router-view></router-view>
      </div> 
    </div>
  </div>
</template>

<script>
    import NavMenu from './nav-menu' 

    export default {
      components: {
        'nav-menu': NavMenu, 
      },

      data () {
        return {}
      }
    }
</script>

<style>
</style>
