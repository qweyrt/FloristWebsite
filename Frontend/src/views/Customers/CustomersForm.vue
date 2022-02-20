<template>
  <div>
    <title-bar :title-stack="titleStack" />
    <hero-bar>
      {{ heroTitle }}
      <router-link slot="right" :to="heroRouterLinkTo" class="button">
        {{ heroRouterLinkLabel }}
      </router-link>
    </hero-bar>
    <section class="section is-main-section">
      <tiles>
        <card-component
          :title="formCardTitle"
          icon="account-edit"
          class="tile is-child"
        >
          <form @submit.prevent="submit">
            <b-field label="ID" horizontal>
              <b-input v-model="form.id" custom-class="is-static" readonly />
            </b-field>
            <hr />
            <b-field
              label="First Name"
              message="Customer's first name"
              horizontal
            >
              <b-input
                v-model="form.firstName"
                placeholder="e.g. John"
                required
              />
            </b-field>
            <b-field
              label="Last Name"
              message="Customer's last name"
              horizontal
            >
              <b-input
                v-model="form.lastName"
                placeholder="e.g. Doe"
                required
              />
            </b-field>
            <b-field label="Gender" message="Customer's gender" horizontal>
              <b-input v-model="form.gender" placeholder="e.g. Male" required />
            </b-field>

            <b-field label="Address" message="Customer's address" horizontal>
              <b-input
                v-model="form.address"
                placeholder="e.g. New York"
                required
              />
            </b-field>
            <b-field
              label="Phone Number"
              message="Customer's phone number"
              horizontal
            >
              <b-input
                v-model="form.phoneNumber"
                placeholder="e.g. +86 865 6653"
                required
              />
            </b-field>
            <b-field
              label="Date of Birth"
              message="Customer's date of birth"
              horizontal
            >
              <b-datepicker
                v-model="form.dateOfBirth"
                placeholder="Click to select..."
                icon="calendar-today"
                @input="dateInput"
              />
            </b-field>
            <hr />
            <b-field horizontal>
              <b-button
                type="is-info"
                :loading="isLoading"
                native-type="submit"
              >
                Submit
              </b-button>
            </b-field>
          </form>
        </card-component>
        <card-component
          v-if="isProfileExists"
          title="Customer Profile"
          icon="account"
          class="tile is-child"
        >
          <!-- <user-avatar
            :avatar="form.avatar"
            class="image has-max-width is-aligned-center"
          /> -->
          <hr />
          <b-field label="First Name">
            <b-input
              :value="form.firstName"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Last Name">
            <b-input :value="form.lastName" custom-class="is-static" readonly />
          </b-field>
          <b-field label="Gender">
            <b-input :value="form.gender" custom-class="is-static" readonly />
          </b-field>

          <b-field label="Address">
            <b-input :value="form.address" custom-class="is-static" readonly />
          </b-field>
          <b-field label="Phone Number">
            <b-input
              :value="form.phoneNumber"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Date of Birth">
            <b-input
              :value="createdReadable"
              custom-class="is-static"
              readonly
            />
          </b-field>
        </card-component>
      </tiles>
    </section>
  </div>
</template>

<script>
import { mapState } from "vuex";
import find from "lodash/find";
import TitleBar from "@/components/TitleBar.vue";
import HeroBar from "@/components/HeroBar.vue";
import Tiles from "@/components/Tiles.vue";
import CardComponent from "@/components/CardComponent.vue";
import FilePicker from "@/components/FilePicker.vue";
import UserAvatar from "@/components/UserAvatar.vue";
import Notification from "@/components/Notification.vue";
import axios from "axios";
import store from '@/store/index.js';


export default {
  name: "ClientForm",
  components: {
    UserAvatar,
    FilePicker,
    CardComponent,
    Tiles,
    HeroBar,
    TitleBar,
    Notification,
  },
  props: {
    id: {
      type: [String, Number],
      default: null,
    },
  },
  data() {
    return {
      isProfileExists: false,
      isLoading: false,
      form: {
        id: null,
        firstName: null,
        lastName: null,
        gender: null,
        address: null,
        phoneNumber: null,
        dateOfBirth: new Date(),
      },
      createdReadable: null,
    };
  },
  computed: {
    titleStack() {
      return [
        "Admin",
        "Customers",
        this.isProfileExists ? this.form.firstName : "New Customer",
      ];
    },
    heroTitle() {
      return this.isProfileExists ? this.form.firstName : "Create Customer";
    },
    heroRouterLinkTo() {
      return this.isProfileExists
        ? { name: "customers.new" }
        : { name: "home" };
    },
    heroRouterLinkLabel() {
      return this.isProfileExists ? "New Customer" : "Dashboard";
    },
    formCardTitle() {
      return this.isProfileExists ? "Edit Customer" : "Create Customer";
    },
    ...mapState(["customers"]),
  },
  watch: {
    id(newValue) {
      this.isProfileExists = false;

      if (!newValue) {
        this.form.id = null;
        this.form.firstName = null;
        this.form.lastName = null;
        this.form.gender = null;
        this.form.address = null;
        this.form.phoneNumber = null;
        this.form.dateOfBirth = new Date();
        this.createdReadable = new Date().toLocaleDateString();
      } else {
        this.getData();
      }
    },
  },
  created() {
    this.getData();
  },
  methods: {
    getData() {
      if (this.id) {
        const item = find(
          this.customers,
          (item) => item.id === parseInt(this.id)
        );

        if (item) {
          this.isProfileExists = true;

          this.form.id = item.id;
          this.form.firstName = item.firstName;
          this.form.lastName = item.lastName;
          this.form.gender = item.gender;
          this.form.address = item.address;
          this.form.phoneNumber = item.phoneNumber;
          this.form.dateOfBirth = new Date(item.dateOfBirth);
          this.createdReadable = new Date(
            item.dateOfBirth
          ).toLocaleDateString();
        } else {
          this.$router.push({ name: "customers.new" });
        }
      }
    },
    createCustomer() {
		const params = new FormData();
		params.append('firstName', this.form.firstName);
		params.append('lastName', this.form.lastName);
		params.append('dateOfBirth', this.form.dateOfBirth);
		params.append('gender', this.form.gender);
		params.append('address', this.form.address);
		params.append('phoneNumber', this.form.phoneNumber);

      var customer = {
        firstName: this.form.firstName,
        lastName: this.form.lastName,
		dateOfBirth: this.form.dateOfBirth,
        gender: this.form.gender,
        address: this.form.address,
        phoneNumber: this.form.phoneNumber,
      };
	  var parse = JSON.stringify(customer);
	  console.log(parse);
      axios
        .post("https://localhost:44344/api/Customers/add", {
          params,
        })
        .then((response) => {
          store.dispatch("fetchCustomers", "customers");

          alert(response.data);
        });
    },
    dateInput(v) {
      this.createdReadable = new Date(v).toLocaleDateString();
    },
    submit() {
      this.isLoading = true;
      // if(this.isProfileExists=false){
      console.log("a");
      this.createCustomer();
      setTimeout(() => {
        this.isLoading = false;

        this.$buefy.snackbar.open({
          message: "Success!",
          queue: false,
        });
      }, 750);
    },
  },
};
</script>
