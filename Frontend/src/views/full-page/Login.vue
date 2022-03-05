<template>
  <card-component
    title="Login"
    icon="lock"
  >
    <router-link
      slot="button"
      to="/home"
      class="button is-small"
    >
      Dashboard
    </router-link>

    <form
      method="POST"
      @submit.prevent="submit"
    >
      <b-field label="E-mail Address">
        <b-input
          v-model="form.userName"
          name="userName"
          type="text"
          required
        />
      </b-field>

      <b-field label="Password">
        <b-input
          v-model="form.password"
          type="password"
          name="password"
          required
        />
      </b-field>

      <b-field>
        <b-checkbox
          v-model="form.remember"
          type="is-black"
          class="is-thin"
        >
          Remember me
        </b-checkbox>
      </b-field>

      <hr>

      <b-field grouped>
        <div class="control">
          <b-button
            native-type="submit"
            type="is-black"
            :loading="isLoading"
          >
            Login
          </b-button>
        </div>
        <div class="control">
          <router-link
            to="/home"
            class="button is-outlined is-black"
          >
            Dashboard
          </router-link>
        </div>
      </b-field>
    </form>
  </card-component>
</template>

<script>
import CardComponent from '@/components/CardComponent.vue'
import axios from "axios";

export default {
  name: 'Login',
  components: { CardComponent },
  data () {
    return {
      isLoading: false,
      form: {
        userName: null,
        password: null,
        remember: false
      }
    }
  },
  methods: {
    submit () {
      this.isLoading = true
	  if(this.form.userName != null && this.form.userName != "" && this.form.password != null && this.form.password != ""){
	  const options = {
        headers: { "content-type": "application/json" },
      };
		axios
        .post(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/v1/auth/login?userName=${this.form.userName}&password=${this.form.password}`, options)
        .then((response) => {
			localStorage.setItem('LoginData', response.data);
        });
      setTimeout(() => {
        this.isLoading = false

        this.$router.push('/home')
      }, 750)
	  }
    }
  }
}
</script>
