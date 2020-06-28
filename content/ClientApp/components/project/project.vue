<template>
  <div class="content"> 
    <b-form @submit="beforeSave">
      <div class="row">
        <div class="col-md-12 form-group">
          <div class="form-group" :class="{invalid: $v.project.name.$error}">
            <label for="Name" class="control-label">Name</label>
            <input v-model="project.name" class="form-control" placeholder="Custom Program" @blur="$v.project.name.$touch()" />
            <p :class="{ invalided: saveValidate }" style="color: red;" v-if="!$v.project.name.required"> This field must not be empty</p>
          </div>
        </div>
      </div>
      <b-button class="mt-3 pull-right" @click="$bvModal.hide('modal-project')">Cancel</b-button>
      <b-button type="submit" variant="primary" class="mt-3 pull-right">Save</b-button>
    </b-form> 
  </div>
</template>

<script>
  import axios from 'axios'
  import { mapState, mapActions } from 'vuex' 
  import { required, decimal } from 'vuelidate/lib/validators'
  export default {
    props: ['selectedjob'],
    computed: { 
        ...mapState({
            projectStore: state => state.project
        }),
        ...mapState({
            store: state => state.company
        })
    },
    components: { 
    },
    data() {
      return {
        saveValidate: true,
        validate: true,
        action: '',
        email: JSON.parse(localStorage.getItem('user')).username,
        project: {
          name: '', 
        }, 
      }
    },
    methods: {
      ...mapActions('tenderjob', [
        'getJob',
        'saveJob'
      ]),
      ...mapActions('company', [
        'getCompany'
      ]),
      ...mapActions('project', [
        'getProjects'
      ]),
      beforeSave() {
        event.preventDefault();
        if (this.$v.project.name.$invalid) { 
          this.save();
        } else {
          this.save();
        }
      },
      save() {
        event.preventDefault();
        var self = this;
        if (self.action == "edit") {
          return axios
            .put('/portal/api/projects/' + self.project.id, self.project)
            .then(response => { console.log(response.data) })
        }
        else {
          this.project.CustomerId = this.store.company.id;
          var self = this;
          return axios
            .post('/portal/api/projects/PostProject', self.project)
            .then(response => { 
              self.project = response.data;
              self.getProjects(self.store);
              self.$bvModal.hide('modal-project');
              self.$router.push({ path: '/portal/projects/' }); 
            }) 
        }
      },
      onComplete: function () {
        event.preventDefault();
        var self = this;
        if (this.$v.$invalid == true) {
          this.validate = false;
          self.$swal.fire('Please make sure the required field is filled properly');
        } else {
          this.save().then(function () {
            self.$swal.fire(
              'Saved',
              'Job Saved',
              'success'
            ).then(function () { 
                self.$emit("hide"); 
            })
          });
        }
      }
    },
    validations: {
      project: { 
        name: { required }, 
      }
    },
    mounted: function () { 
      this.getCompany(this.email)
    }
  }
</script>

<style scoped>
  button.b-form-datepicker {
    margin: 0;
    border-radius: 2.1875rem;
  }

  button.btn.btn-sm.btn-outline-secondary.border-0.flex-fill.p-1.mx-1 {
    COLOR: blue;
  }

  .form-group.invalid label {
    color: red;
  }

  .form-group.invalid input {
    border: 1px solid red;
    background-color: #ffc9aa;
  }

  .form-group p.invalided, .col-md-2 p.invalided {
    display: none;
  }


</style>
