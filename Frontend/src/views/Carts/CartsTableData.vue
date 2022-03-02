<template>
  <div>
    <modal-box
      :is-active="isModalActive"
      :trash-object-name="trashObject ? trashObject.firstName : null"
      @confirm="trashConfirm"
      @cancel="trashCancel"
    />
    <b-table
      :checked-rows.sync="checkedRows"
      :checkable="checkable"
      :paginated="paginated"
      :per-page="perPage"
      :data="carts"
      default-sort="name"
      striped
      hoverable
    >
      <b-table-column
        v-slot="props"
        cell-class="has-no-head-mobile is-image-cell"
      >
        <div class="image">
          <img :src="props.row.avatar" class="is-rounded" />
        </div>
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Customer"
        field="customerName"
        sortable
      >
        {{ props.row.customerName }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Recipient"
        field="recipientName"
        sortable
      >
        {{ props.row.recipientName }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Bouquet"
        field="bouquetName"
        sortable
      >
        {{ props.row.bouquetName }}
      </b-table-column>
      <b-table-column v-slot="props" label="Quantity" field="quantity" sortable>
        {{ props.row.quantity }}
      </b-table-column>

      <b-table-column
        v-slot="props"
        label="Bouquet Message"
        field="bouquetMessageMessage"
        sortable
      >
        {{ props.row.bouquetMessageMessage }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        custom-key="actions"
        cell-class="is-actions-cell"
      >
        <div class="buttons is-right no-wrap">
          <router-link
            :to="{ name: 'carts.edit', params: { id: props.row.id } }"
            class="button is-small is-info"
          >
            <b-icon icon="account-edit" size="is-small" />
          </router-link>
          <b-button
            type="is-danger"
            size="is-small"
            @click.prevent="trashModalOpen(props.row)"
            @click="getCart(props.row.id)"
          >
            <b-icon icon="trash-can" size="is-small" />
          </b-button>
        </div>
      </b-table-column>

      <section slot="empty" class="section">
        <div class="content has-text-grey has-text-centered">
          <p>
            <b-icon icon="emoticon-sad" size="is-large" />
          </p>
          <p>Nothing's here&hellip;</p>
        </div>
      </section>
    </b-table>
  </div>
</template>

<script>
import { mapState } from "vuex";
import ModalBox from "@/components/ModalBox.vue";
import axios from "axios";
import store from "@/store/index.js";

export default {
  name: "CartsTableData",
  components: { ModalBox },
  props: {
    checkable: Boolean,
    isEmpty: Boolean,
    perPage: {
      type: Number,
      default: 10,
    },
  },
  data() {
    return {
      checkedRows: [],
      isModalActive: false,
      trashObject: null,
      cart: {
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
    };
  },
  filters: {},

  computed: {
    paginated() {
      return this.carts.length > this.perPage;
    },
    ...mapState(["carts"]),
  },
  methods: {
    trashModalOpen(obj) {
      this.trashObject = obj;
      this.isModalActive = true;
    },
    deleteCart(id) {
      axios
        .delete(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Carts/delete/${id}`)
        .then((r) => {
          store.dispatch("fetchCarts", "carts");
        })
        .catch((error) => {
          alert(error.message);
        });
    },
    getCart(id) {
      axios
        .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Carts/${id}`)
        .then((r) => {
          this.cart = r.data;
        })
        .catch((error) => {
          alert(error.message);
        });
    },

    trashConfirm() {
      this.isModalActive = false;
      this.deleteCart(this.cart.id);
      this.$buefy.snackbar.open({
        message: "Success!",
        queue: false,
      });
    },
    moment(date) {
      return new Date(date).toLocaleDateString();
    },
    trashCancel() {
      this.isModalActive = false;
    },
  },
};
</script>
