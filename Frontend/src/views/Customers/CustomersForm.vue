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
              label="Name"
              message="Customer's name"
              horizontal
            >
              <b-input
                v-model="form.name"
                placeholder="e.g. John Doe"
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
          <hr />
          <b-field label="Name">
            <b-input
              :value="form.name"
              custom-class="is-static"
              readonly
            />
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
import store from "@/store/index.js";

export default {
  name: "CustomersForm",
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
        name: null,
        gender: null,
        address: null,
        phoneNumber: null,
        dateOfBirth: null,
      },
      createdReadable: null,
    };
  },
  computed: {
    titleStack() {
      return [
        "Admin",
        "Customers",
        this.isProfileExists ? this.form.name : "New Customer",
      ];
    },
    heroTitle() {
      return this.isProfileExists ? this.form.name : "Create Customer";
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
        this.form.name = null;
        this.form.gender = null;
        this.form.address = null;
        this.form.phoneNumber = null;
        this.form.dateOfBirth = new Date().toISOString();
        this.createdReadable = new Date().toISOString();
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
          this.form.name = item.name;
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
      var customer = {
        name: this.form.name,
        dateOfBirth: this.form.dateOfBirth,
        gender: this.form.gender,
        address: this.form.address,
        phoneNumber: parseInt(this.form.phoneNumber),
      };
      var parse = JSON.stringify(customer);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .post("http://localhost:30102/api/Customers/add", parse, options)
        .then((response) => {
          store.dispatch("fetchCustomers", "customers");
        });
    },
    updateCustomer() {
      var customer = {
        id: this.form.id,
        name: this.form.name,
        dateOfBirth: new Date(this.form.dateOfBirth).toISOString(),
        gender: this.form.gender,
        address: this.form.address,
        phoneNumber: parseInt(this.form.phoneNumber),
      };
      var parse = JSON.stringify(customer);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .put("http://localhost:30102/api/Customers/update", parse, options)
        .then((response) => {
          store.dispatch("fetchCustomers", "customers");
        });
    },

    dateInput(v) {
      this.createdReadable = new Date(v).toISOString();
    },
    submit() {
      this.isLoading = true;
      if (!this.isProfileExists) {
        this.createCustomer();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/customers");
          this.$buefy.snackbar.open({
            message: "Success!",
            queue: false,
          });
        }, 750);
      } else if (this.isProfileExists) {
        this.updateCustomer();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/customers");
          this.$buefy.snackbar.open({
            message: "Success!",
            queue: false,
          });
        }, 750);
      }
    },
  },
};
</script>
