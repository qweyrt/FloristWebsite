<template>
  <card-component v-if="!isRegister" title="Login" icon="lock">
    <router-link slot="button" to="/home" class="button is-small">
      Dashboard
    </router-link>

    <form method="POST" @submit.prevent="submit">
      <b-field label="E-mail Address">
        <b-input v-model="form.userName" name="userName" type="text" required />
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
        <b-checkbox v-model="form.remember" type="is-black" class="is-thin">
          Remember me
        </b-checkbox>
      </b-field>

      <hr />

      <b-field grouped>
        <div class="control">
          <b-button native-type="submit" type="is-black" :loading="isLoading">
            Login
          </b-button>
        </div>
        <div class="control">
          <b-button
            v-on:click="isRegister = true"
            class="button is-outlined is-black"
          >
            Register
          </b-button>
        </div>
      </b-field>
    </form>
  </card-component>
  <card-component v-else title="Register" icon="lock">
    <router-link slot="button" to="/home" class="button is-small">
      Dashboard
    </router-link>

    <form method="POST" @submit.prevent="submit">
        <b-field label="Username">
        <b-input
          v-model="register.userName"
          name="userName"
          type="text"
          required
        />
      </b-field>

      
    

      <b-field label="Password">
        <b-input
          v-model="register.password"
          type="password"
          name="password"
          required
        />
      </b-field>
      <b-field label="Gender" message="Gender">
        <b-select
          v-model="register.gender"
          placeholder="e.g. John Doe"
          required
        >
          <option value="Male">Male</option>
          <option value="Female">Female</option>
        </b-select>
      </b-field>
      <b-field label="Name">
        <b-input v-model="register.name" name="name" type="text" required />
      </b-field>
      <b-field label="Address">
        <b-input
          v-model="register.address"
          name="address"
          type="text"
          required
        />
      </b-field>
      <b-field label="Phone Number">
        <b-input
          v-model="register.phoneNumber"
          name="Phone Number"
          type="text"
          required
        />
      </b-field>
      <hr />
      <b-field grouped>
        <div class="control">
          <b-button native-type="submit" type="is-black" :loading="isLoading">
            Register
          </b-button>
        </div>
      </b-field>
    </form>
  </card-component>
</template>

<script>
import CardComponent from "@/components/CardComponent.vue";
import axios from "axios";

export default {
  name: "Login",
  components: { CardComponent },
  data() {
    return {
      isLoading: false,
      isRegister: false,
      form: {
        userName: null,
        password: null,
        remember: false,
      },
      register: {
        userName: null,
        name: null,
        gender: null,
        address: null,
        password: null,
        phoneNumber: null,
      },
    };
  },
  methods: {
    submit() {
      this.isLoading = true;
      if (
        this.register.userName != null &&
        this.register.userName != "" &&
        this.register.password != null &&
        this.register.password != ""
      ) {
        const options = {
          headers: { "content-type": "application/json" },
        };
        var customer={
          userName:this.register.userName,
          name:this.register.name,
          PasswordHash:this.register.password,
          gender:this.register.gender,
          phoneNumber:this.register.phoneNumber,
          address:this.register.address
        }
        var parse = JSON.stringify(customer);
        axios
          .post(
            `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Customers/add`,parse,
            options
          )
          .then((response) => {
            this.isLoading = false;
            this.$buefy.snackbar.open({
              message: "Success !",
              queue: false,
            });
            this.$router.push("/login");
          })
          .catch((error) => {
          });

      }
      if (
        this.form.userName != null &&
        this.form.userName != "" &&
        this.form.password != null &&
        this.form.password != ""
      ) {
        const options = {
          headers: { "content-type": "application/json" },
        };
        console.log(this.$route);
        axios
          .post(
            `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/v1/auth/login?userName=${this.form.userName}&password=${this.form.password}`,
            options
          )
          .then((response) => {
            this.isLoading = false;
            localStorage.setItem("LoginData", response.data);
            this.$router.push("/home");
            const data = localStorage.getItem("LoginData");
          })
          .catch((error) => {
            this.isLoading = false;

            this.$buefy.snackbar.open({
              message: "Username or Password is incorrect",
              queue: false,
            });
          });

        // setTimeout(() => {
        //   this.isLoading = false

        //   this.$router.push('/home')
        // }, 750)
      }
    },
  },
};
</script>
