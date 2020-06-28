<template>
  <div>
    <!--
      Tip 1: You can change the color of the sidebar using: data-color="blue | green | orange | red | yellow"
  -->
    <ul class="navbar-nav mr-auto">
      <li class="nav-item" v-for="(route, index) in routes" :key="index">
        <router-link :to="route.path" exact-active-class="active" v-if="route.showOnMenu">
          {{ route.display }} 
        </router-link>
      </li>
    </ul>
  </div>
   
</template>

<script>
    import { routes } from '../router/routes'

    export default {
    data() {
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

  a.active.router-link-active {
    color: #6777ef;
  }

</style>
