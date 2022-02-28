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
            <b-field label="Message" message="Bouquet message" horizontal>
              <b-input
                v-model="form.message"
                placeholder="e.g. Happy Birthday!"
                required
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
          title="Bouquet Message Profile"
          icon="account"
          class="tile is-child"
        >
          <!-- <user-avatar
            :avatar="form.avatar"
            class="image has-max-width is-aligned-center"
          /> -->
          <hr />
          <b-field label="Message">
            <b-input :value="form.message" custom-class="is-static" readonly />
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
  name: "BouquetMessagesForm",
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
        message: null,
      },
      createdReadable: null,
    };
  },
  computed: {
    titleStack() {
      return [
        "Admin",
        "Bouquet Messages",
        this.isProfileExists ? this.form.message : "New Bouquet Message",
      ];
    },
    heroTitle() {
      return this.isProfileExists
        ? this.form.message
        : "Create Bouquet Message";
    },
    heroRouterLinkTo() {
      return this.isProfileExists
        ? { name: "bouquetMessages.new" }
        : { name: "home" };
    },
    heroRouterLinkLabel() {
      return this.isProfileExists ? "New Bouquet Message" : "Dashboard";
    },
    formCardTitle() {
      return this.isProfileExists
        ? "Edit Bouquet Message"
        : "Create Bouquet Message";
    },
    ...mapState(["bouquetMessages"]),
  },
  watch: {
    id(newValue) {
      this.isProfileExists = false;

      if (!newValue) {
        this.form.id = null;
        this.form.message = null;
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
          this.bouquetMessages,
          (item) => item.id === parseInt(this.id)
        );

        if (item) {
          this.isProfileExists = true;

          this.form.id = item.id;
          this.form.message = item.message;
        } else {
          this.$router.push({ name: "bouquetMessages.new" });
        }
      }
    },
    createBouquetMessage() {
      var bouquetMessage = {
        message: this.form.message,
      };
      var parse = JSON.stringify(bouquetMessage);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .post(`http://localhost:${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/BouquetsMessages/add`, parse, options)
        .then((response) => {
            store.dispatch("fetchBouquetMessages", "bouquetMessages");
        });
    },
    updateBouquetMessage() {
      var bouquetMessage = {
        id: this.form.id,
        message: this.form.message,
      };
      var parse = JSON.stringify(bouquetMessage);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .put(
          `http://localhost:${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/BouquetsMessages/update`,
          parse,
          options
        )
        .then((response) => {
            store.dispatch("fetchBouquetMessages", "bouquetMessages");
        });
    },

    dateInput(v) {
      this.createdReadable = new Date(v).toLocaleDateString();
    },
    submit() {
      this.isLoading = true;
      if (!this.isProfileExists) {
        this.createBouquetMessage();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/bouquet-messages");
          this.$buefy.snackbar.open({
            message: "Success!",
            queue: false,
          });
        }, 750);
      } else if (this.isProfileExists) {
        this.updateBouquetMessage();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/bouquet-messages");
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
