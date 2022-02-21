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
      :data="bouquetMessages"
      default-sort="id"
      striped
      hoverable
    >
      <b-table-column
        v-slot="props"
        cell-class="has-no-head-mobile is-image-cell"
		width="5%"
      >
        <div class="image">
          <img :src="props.row.avatar" class="is-rounded" />
        </div>
      </b-table-column>

      <b-table-column
        v-slot="props"
        label="Number"
        field="id"
        sortable
        width="10%"
      >
        {{ props.row.id }}
      </b-table-column>
      <b-table-column v-slot="props" label="Message" field="message" sortable>
        {{ props.row.message }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        custom-key="actions"
        cell-class="is-actions-cell"
      >
        <div class="buttons is-right no-wrap">
          <router-link
            :to="{ name: 'bouquetMessages.edit', params: { id: props.row.id } }"
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
  name: "BouquetMessagesTableData",
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
      return this.bouquetMessages.length > this.perPage;
    },
    ...mapState(["bouquetMessages"]),
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
