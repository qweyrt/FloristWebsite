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
            <b-field label="Name" message="Bouquet name" horizontal>
              <b-input
                v-model="form.name"
                placeholder="e.g. Flowers"
                required
              />
            </b-field>
            <b-field label="Price" message="Bouquet's price" horizontal>
              <b-input v-model="form.price" placeholder="e.g. $100" required />
            </b-field>
            <b-field label="Customer Name" message="Customer's name" horizontal>
              <!-- <b-input
                v-model="form.customerId"
                placeholder="e.g. John"
                required
              /> -->
              <b-select
                v-model="form.customerId"
                placeholder="e.g. John"
                :options="recipients.id"
              ></b-select>
            </b-field>
            <b-field
              label="Recipient Name"
              message="Recipient's name"
              horizontal
            >
              <!-- <b-input
                v-model="form.recipientId"
                placeholder="e.g. John Doe"
                required
              /> -->
              <b-select
                v-model="form.recipientId"
                placeholder="e.g. John Doe"
                :options="recipients.id"
              ></b-select>
            </b-field>
            <b-field
              label="Bouquet Message"
              message="Bouquet's message"
              horizontal
            >
              <!-- <b-input
                v-model="form.bouquetMessageMessage"
                placeholder="e.g. Happy Birthday!"
                required
              /> -->
              <b-select
                v-model="form.bouquetMessageId"
                placeholder="e.g. Happy Birthday!"
                :options="bouquetMessages.id"
              ></b-select>
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
          title="Bouquet Profile"
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
          <b-field label="Price">
            <b-input :value="form.price" custom-class="is-static" readonly />
          </b-field>
          <b-field label="Customer Name">
            <b-input
              :value="form.customerFirstName + ' ' + form.customerLastName"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Recipient Name">
            <b-input
              :value="form.recipientName"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Bouquet Message">
            <b-input
              :value="form.bouquetMessageMessage"
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
  name: "BouquetForm",
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
        price: null,
        customerId: null,
        recipientId: null,
        bouquetMessageId: null,
      },
      createdReadable: null,
    };
  },
  computed: {
    titleStack() {
      return [
        "Admin",
        "Bouquets",
        this.isProfileExists ? this.form.name : "New Bouquet",
      ];
    },
    heroTitle() {
      return this.isProfileExists ? this.form.name : "Create Bouquet";
    },
    heroRouterLinkTo() {
      return this.isProfileExists ? { name: "bouquets.new" } : { name: "home" };
    },
    heroRouterLinkLabel() {
      return this.isProfileExists ? "New Bouquet" : "Dashboard";
    },
    formCardTitle() {
      return this.isProfileExists ? "Edit Bouquet" : "Create Bouquet";
    },
    ...mapState(["bouquets", "bouquetMessages", "recipients"]),
  },
  watch: {
    id(newValue) {
      this.isProfileExists = false;

      if (!newValue) {
        this.form.id = null;
        this.form.name = null;
        this.form.price = null;
        this.form.customerFirstName = null;
        this.form.customerLastName = null;
        this.form.recipientName = null;
        this.form.bouquetMessageMessage = null;
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
          this.bouquets,
          (item) => item.id === parseInt(this.id)
        );

        if (item) {
          this.isProfileExists = true;

          this.form.id = item.id;
          this.form.name = item.name;
          this.form.price = item.price;
          this.form.customerFirstName = item.customerFirstName;
          this.form.customerLastName = item.customerLastName;
          this.form.recipientName = item.recipientName;
          this.form.bouquetMessageMessage = item.bouquetMessageMessage;
        } else {
          this.$router.push({ name: "bouquets.new" });
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
