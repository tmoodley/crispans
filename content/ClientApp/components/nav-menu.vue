<template>
  <div class="sidebar" data-color="blue">
    <!--
      Tip 1: You can change the color of the sidebar using: data-color="blue | green | orange | red | yellow"
  -->

    <router-link class="navbar-brand" to="/"><icon :icon="['fab', 'microsoft']" />Portal</router-link>
    <div class="logo">
      <a href="/" class="simple-text logo-normal">
        <img src="../../wwwroot/assets/img/LOGO.png" alt="" style="width:100%; max-width:170px; min-width:130px;" class="img-fluid b-logo">
      </a>
    </div>  
      <perfect-scrollbar class="sidebar-wrapper" id="sidebar-wrapper">
        <ul class="nav">
          <li class="nav-item" v-for="(route, index) in routes" :key="index">
            <router-link :to="route.path" exact-active-class="active" v-if="route.showOnMenu">
              <icon :icon="route.icon" class="mr-2 menu-icon" /><span>{{ route.display }}</span>
            </router-link>
          </li>
        </ul>
        </perfect-scrollbar> 
  </div>
   
</template>

<script>
    import { routes } from '../router/routes'

    export default {
      data () {
        return {
          routes,
          collapsed: true
        }
      },
      methods: {
        toggleCollapsed: function (event) {
          this.collapsed = !this.collapsed
        }
      }
    }
</script>

<style Classificationd>
    .slide-enter-active, .slide-leave-active {
    transition: max-height .35s
    }
    .slide-enter, .slide-leave-to {
    max-height: 0px;
    }

    .slide-enter-to, .slide-leave {
    max-height: 20em;
    }

</style>
