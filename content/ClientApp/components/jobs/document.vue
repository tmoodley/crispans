<template>
  <div> 
    <vue-dropzone 
                  :options="dropzoneOptions"
                  v-on:vdropzone-sending="sendingEvent"
                  v-on:vdropzone-success="onSuccess"> 
    </vue-dropzone>
  </div>
</template>

<script>
import vue2Dropzone from 'vue2-dropzone'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import { mapState, mapActions } from 'vuex' 
export default {
  name: 'app',
  components: {
    vueDropzone: vue2Dropzone
  },
  data: function () {
    return {
      dropzoneOptions: {
          url: '/portal/api/document/',
          thumbnailWidth: 150,
          maxFilesize: 5,
          headers: { "Document": "header value" },
          addRemoveLinks: true,
          dictDefaultMessage: "<i class='fa fa-cloud-upload'></i>UPLOAD ME"
      }
    }
    },
   methods: {
     sendingEvent(file, xhr, formData) { 
        var id = this.store.company.id;
        formData.append('CustomerId', id);
       },
     onSuccess(file, response) { 
         this.$emit("setid", response.id) 
       }
    },
    computed: {
      ...mapState({
        store: state => state.company
      }),
    }
}

</script>

<style>
</style>
