<template>
  <div>
    <ul class="nav nav-pills">
     <li class="nav-item" v-for="(route, index) in routes" :key="index">
        <router-link :to="route.path" exact-active-class="active" class="nav-link">
          {{ route.display }}
        </router-link>
      </li>
      <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Documents</a>
        <div class="dropdown-menu">
          <a class="dropdown-item" href="#">NDA</a>
          <a class="dropdown-item" href="#">Contact</a>
          <a class="dropdown-item" href="#">Terms And Conditions</a>
          <div class="dropdown-divider"></div>
          <a class="dropdown-item" href="#">3D Files</a>
        </div>
      </li>
    </ul> 
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
