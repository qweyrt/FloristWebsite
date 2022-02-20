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
            <b-field label="Name" message="Recipient name" horizontal>
              <b-input
                v-model="form.name"
                placeholder="e.g. John Doe"
                required
              />
            </b-field>
            <b-field label="Address" message="Recipient's address" horizontal>
              <b-input
                v-model="form.address"
                placeholder="e.g. New York"
                required
              />
            </b-field>
            <b-field
              label="Phone Number"
              message="Recipient's phone number"
              horizontal
            >
              <b-input
                v-model="form.phoneNumber"
                placeholder="e.g. +86 865 6653"
                required
              />
            </b-field>
            <b-field
              label="Recipient Date"
              message="Recipient's date"
              horizontal
            >
              <b-datepicker
                v-model="form.date"
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
          title="Recipient Profile"
          icon="account"
          class="tile is-child"
        >
          <!-- <user-avatar
            :avatar="form.avatar"
            class="image has-max-width is-aligned-center"
          /> -->
          <hr />
          <b-field label="Name">
            <b-input :value="form.name" custom-class="is-static" readonly />
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
          <b-field label="Recipient Date">
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

export default {
  name: "RecipientForm",
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
        address: null,
        phoneNumber: null,
        date: new Date(),
      },
      createdReadable: null,
    };
  },
  computed: {
    titleStack() {
      return [
        "Admin",
        "Recipients",
        this.isProfileExists ? this.form.name : "New Recipient",
      ];
    },
    heroTitle() {
      return this.isProfileExists ? this.form.name : "Create Recipient";
    },
    heroRouterLinkTo() {
      return this.isProfileExists ? { name: "recipients.new" } : { name: "home" };
    },
    heroRouterLinkLabel() {
      return this.isProfileExists ? "New Recipient" : "Dashboard";
    },
    formCardTitle() {
      return this.isProfileExists ? "Edit Recipient" : "Create Recipient";
    },
    ...mapState(["recipients"]),
  },
  watch: {
    id(newValue) {
      this.isProfileExists = false;

      if (!newValue) {
        this.form.id = null;
        this.form.name = null;
        this.form.address = null;
        this.form.phoneNumber = null;
        this.form.date = new Date();
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
          this.recipients,
          (item) => item.id === parseInt(this.id)
        );

        if (item) {
          this.isProfileExists = true;

          this.form.id = item.id;
          this.form.name = item.name;
          this.form.address = item.address;
          this.form.phoneNumber = item.phoneNumber;
          this.form.date = new Date(item.date)
          this.createdReadable = new Date(item.date).toLocaleDateString()
        } else {
          this.$router.push({ name: "recipients.new" });
        }
      }
    },
    dateInput(v) {
      this.createdReadable = new Date(v).toLocaleDateString();
    },
    submit() {
      this.isLoading = true;

      setTimeout(() => {
        this.isLoading = false;

        this.$buefy.snackbar.open({
          message: "Demo only",
          queue: false,
        });
      }, 750);
    },
  },
};
</script>
