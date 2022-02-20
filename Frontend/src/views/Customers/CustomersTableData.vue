<template>
  <div>
    <modal-box
      :is-active="isModalActive"
      :trash-object-name="trashObject ? trashObject.name : null"
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
      <b-table-column v-slot="props" label="First Name" field="firstName" sortable>
        {{ props.row.firstName }}
      </b-table-column>
      <b-table-column v-slot="props" label="Last Name" field="lastName" sortable>
        {{ props.row.lastName }}
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
        {{ props.row.dateOfBirth }}
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
    };
  },
  computed: {
    paginated() {
      return this.customers.length > this.perPage;
    },
    ...mapState(['customers']),
	
  },
  methods: {
    trashModalOpen(obj) {
      this.trashObject = obj;
      this.isModalActive = true;
    },
    trashConfirm() {
      this.isModalActive = false;

      this.$buefy.snackbar.open({
        message: "Confirmed",
        queue: false,
      });
    },
    trashCancel() {
      this.isModalActive = false;
    },
  },
};
</script>
