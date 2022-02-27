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
      :data="recipients"
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
      <b-table-column v-slot="props" label="Name" field="name" sortable>
        {{ props.row.name }}
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
      <b-table-column v-slot="props" label="Date" field="date" sortable>
        {{ moment(props.row.date) }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        custom-key="actions"
        cell-class="is-actions-cell"
      >
        <div class="buttons is-right no-wrap">
          <router-link
            :to="{ name: 'recipients.edit', params: { id: props.row.id } }"
            class="button is-small is-info"
          >
            <b-icon icon="account-edit" size="is-small" />
          </router-link>
          <b-button
            type="is-danger"
            size="is-small"
            @click.prevent="trashModalOpen(props.row)"
            @click="getRecipient(props.row.id)"
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
  name: "RecipientsTableData",
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
      recipient: {
        id: null,
        name: null,
        address: null,
        phoneNumber: null,
        date: null,
      },
    };
  },
  computed: {
    paginated() {
      return this.recipients.length > this.perPage;
    },
    ...mapState(["recipients"]),
  },
  methods: {
    trashModalOpen(obj) {
      this.trashObject = obj;
      this.isModalActive = true;
    },
    deleteRecipient(id) {
      axios
        .delete(`http://localhost:30102/api/Recipients/delete/${id}`)
        .then((r) => {
          store.dispatch("fetchRecipients", "recipients");
        })
        .catch((error) => {
          alert(error.message);
        });
    },
    getRecipient(id) {
      axios
        .get(`http://localhost:30102/api/Recipients/${id}`)
        .then((r) => {
          this.recipient = r.data;
        })
        .catch((error) => {
          alert(error.message);
        });
    },
    trashConfirm() {
      this.isModalActive = false;
      this.deleteRecipient(this.recipient.id);
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
