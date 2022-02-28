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
      :data="customers"
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
        label="Name"
        field="name"
        sortable
      >
        {{ props.row.name }}
      </b-table-column>
      <b-table-column v-slot="props" label="Gender" field="gender" sortable>
        {{ props.row.gender }}
      </b-table-column>
      <b-table-column v-slot="props" label="Address" field="address" sortable>
        {{ props.row.address }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Phone Number"
        field="phoneNumber"
        sortable
      >
        {{ props.row.phoneNumber }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Date of Birth"
        field="dateOfBirth"
        sortable
      >
        {{ moment(props.row.dateOfBirth) }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        custom-key="actions"
        cell-class="is-actions-cell"
      >
        <div class="buttons is-right no-wrap">
          <router-link
            :to="{ name: 'customers.edit', params: { id: props.row.id } }"
            class="button is-small is-info"
          >
            <b-icon icon="account-edit" size="is-small" />
          </router-link>
          <b-button
            type="is-danger"
            size="is-small"
            @click.prevent="trashModalOpen(props.row)"
            @click="getCustomer(props.row.id)"
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
  name: "CustomersTableData",
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
      customer: {
        id: null,
        name: null,
        gender: null,
        address: null,
        phoneNumber: null,
        dateOfBirth: null,
      },
    };
  },
  filters: {},

  computed: {
    paginated() {
      return this.customers.length > this.perPage;
    },
    ...mapState(["customers"]),
  },
  methods: {
    trashModalOpen(obj) {
      this.trashObject = obj;
      this.isModalActive = true;
    },
    deleteCustomer(id) {
      axios
        .delete(`http://localhost:${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Customers/delete/${id}`)
        .then((r) => {
          store.dispatch("fetchCustomers", "customers");
        })
        .catch((error) => {
          alert(error.message);
        });
    },
    getCustomer(id) {
      axios
        .get(`http://localhost:${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Customers/${id}`)
        .then((r) => {
          this.customer = r.data;
        })
        .catch((error) => {
          alert(error.message);
        });
    },

    trashConfirm() {
      this.isModalActive = false;
      this.deleteCustomer(this.customer.id);
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
