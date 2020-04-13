<template>
  <div>
    <div class="container">
      <div class="main-panel" id="main-panel">
        <div class="content">
          <router-view></router-view>
        </div>
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
