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
            <b-field label="Customer" message="Customer's name" horizontal>
              <b-select
                v-model="form.customerId"
                placeholder="e.g. John Doe"
                required
              >
                <option
                  v-for="option in customers"
                  :value="option.id"
                  :key="option.id"
                >
                  {{ option.name }}
                </option>
              </b-select>
            </b-field>
            <b-field label="Recipient" message="Recipient's name" horizontal>
              <b-select
                v-model="form.recipientId"
                placeholder="e.g. John Doe"
                required
              >
                <option
                  v-for="option in recipients"
                  :value="option.id"
                  :key="option.id"
                >
                  {{ option.name }}
                </option>
              </b-select>
            </b-field>
            <b-field label="Bouquet" message="Bouquet's name" horizontal>
              <b-select
                v-model="form.bouquetId"
                placeholder="e.g. Flowers"
                required
              >
                <option
                  v-for="option in bouquets"
                  :value="option.id"
                  :key="option.id"
                >
                  {{ option.name }}
                </option>
              </b-select>
            </b-field>
            <b-field label="Quantity" message="Bouquet's quantity" horizontal>
              <b-input v-model="form.quantity" placeholder="e.g. 5" required />
            </b-field>
            <b-field
              label="Bouquet Message"
              message="Bouquet's message"
              horizontal
            >
              <b-select
                v-model="form.bouquetMessageId"
                placeholder="e.g. Flowers"
                required
              >
                <option
                  v-for="option in bouquetMessages"
                  :value="option.id"
                  :key="option.id"
                >
                  {{ option.message }}
                </option>
              </b-select>
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
          title="Order Profile"
          icon="account"
          class="tile is-child"
        >
          <hr />
          <b-field label="Customer">
            <b-input
              :value="form.customerName"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Recipient">
            <b-input
              :value="form.recipientName"
              custom-class="is-static"
              readonly
            />
          </b-field>

          <b-field label="Bouquet">
            <b-input
              :value="form.bouquetName"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Quantity">
            <b-input :value="form.quantity" custom-class="is-static" readonly />
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
import axios from "axios";
import store from "@/store/index.js";

export default {
  name: "CartsForm",
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
        quantity: null,
        bouquetId: null,
        bouquetName: null,
        customerId: null,
        customerName: null,
        recipientId: null,
        recipientName: null,
        bouquetMessageId: null,
        bouquetMessageMessage: null,
      },
      createdReadable: null,
    };
  },
  computed: {
    titleStack() {
      return [
        "Admin",
        "Carts",
        this.isProfileExists
          ? this.form.customerName + "'s Order"
          : "New Order",
      ];
    },
    heroTitle() {
      return this.isProfileExists
        ? this.form.customerName + "'s Order"
        : "Create Order";
    },
    heroRouterLinkTo() {
      return this.isProfileExists ? { name: "carts.new" } : { name: "home" };
    },
    heroRouterLinkLabel() {
      return this.isProfileExists ? "New Order" : "Dashboard";
    },
    formCardTitle() {
      return this.isProfileExists ? "Edit Order" : "Create Order";
    },
    ...mapState([
      "carts",
      "bouquets",
      "bouquetMessages",
      "customers",
      "recipients",
    ]),
  },
  watch: {
    id(newValue) {
      this.isProfileExists = false;

      if (!newValue) {
        this.form.id = null;
        this.form.quantity = null;
        this.form.bouquetId = null;
        this.form.bouquetName = null;
        this.form.customerId = null;
        this.form.customerName = null;
        this.form.recipientId = null;
        this.form.recipientName = null;
        this.form.bouquetMessageId = null;
        this.form.bouquetMessageMessage = null;
      } else {
        this.getData();
      }
    },
  },
  created() {
    this.getData();
		console.log(this.form);
		console.log(this.customers);

  },
  methods: {
    getData() {
      if (this.id) {
        const item = find(
          this.carts,
          (item) => item.id === parseInt(this.id)
        );
        if (item) {
          this.isProfileExists = true;

          this.form.id = item.id;
          this.form.quantity = item.quantity;
          this.form.bouquetId = item.bouquetId;
          this.form.bouquetName = item.bouquetName;
          this.form.customerId = item.customerId;
          this.form.customerName = item.customerName;
          this.form.recipientId = item.recipientId;
          this.form.recipientName = item.recipientName;
          this.form.bouquetMessageId = item.bouquetMessageId;
          this.form.bouquetMessageMessage = item.bouquetMessageMessage;
        } else {
          this.$router.push({ name: "carts.new" });
        }
      }
    },
    createCart() {
      var cart = {
        quantity: parseInt(this.form.quantity),
        bouquetId: this.form.bouquetId,
        customerId: this.form.customerId,
        recipientId: this.form.recipientId,
        bouquetMessageId: this.form.bouquetMessageId,
      };
      var parse = JSON.stringify(cart);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .post(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Carts/add`, parse, options)
        .then((response) => {
          store.dispatch("fetchCarts", "carts");
        });
    },
    updateCart() {
      var cart = {
        id: this.form.id,
        quantity: parseInt(this.form.quantity),
        bouquetId: this.form.bouquetId,
        customerId: this.form.customerId,
        recipientId: this.form.recipientId,
        bouquetMessageId: this.form.bouquetMessageId,
      };
      var parse = JSON.stringify(cart);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .put(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Carts/update`, parse, options)
        .then((response) => {
          store.dispatch("fetchCarts", "carts");
        });
    },

    dateInput(v) {
      this.createdReadable = new Date(v).toISOString();
    },
    submit() {
      this.isLoading = true;
      if (!this.isProfileExists) {
        this.createCart();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/carts");
          this.$buefy.snackbar.open({
            message: "Success!",
            queue: false,
          });
        }, 750);
      } else if (this.isProfileExists) {
        this.updateCart();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/carts");
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
