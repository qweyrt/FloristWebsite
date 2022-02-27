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
      :data="bouquets"
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
      <b-table-column v-slot="props" label="Price" field="price" sortable>
        {{ props.row.price }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Category"
        field="categoryName"
        sortable
      >
        {{ props.row.categoryName }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        label="Description"
        field="description"
        sortable
      >
        {{ props.row.description }}
      </b-table-column>
      <b-table-column
        v-slot="props"
        custom-key="actions"
        cell-class="is-actions-cell"
      >
        <div class="buttons is-right no-wrap">
          <router-link
            :to="{ name: 'bouquets.edit', params: { id: props.row.id } }"
            class="button is-small is-info"
          >
            <b-icon icon="account-edit" size="is-small" />
          </router-link>
          <b-button
            type="is-danger"
            size="is-small"
            @click.prevent="trashModalOpen(props.row)"
            @click="getBouquet(props.row.id)"
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
import store from "@/store/index.js";
import axios from "axios";

export default {
  name: "BouquetsTableData",
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
      bouquet: {
        id: null,
        name: null,
        price: null,
        description: null,
        images: null,
        categoryId: null,
        categoryName: null,
      },
    };
  },
  computed: {
    paginated() {
      return this.bouquets.length > this.perPage;
    },
    ...mapState(["bouquets"]),
  },
  methods: {
    trashModalOpen(obj) {
      this.trashObject = obj;
      this.isModalActive = true;
    },
    deleteBouquet(id) {
      axios
        .delete(`http://localhost:30102/api/Bouquets/delete/${id}`)
        .then((r) => {
          store.dispatch("fetchBouquets", "bouquets");
        })
        .catch((error) => {
          alert(error.message);
        });
    },
    getBouquet(id) {
      axios
        .get(`http://localhost:30102/api/Bouquets/${id}`)
        .then((r) => {
          this.bouquet = r.data;
        })
        .catch((error) => {
          alert(error.message);
        });
    },

    trashConfirm() {
      this.isModalActive = false;
      this.deleteBouquet(this.bouquet.id);
      this.$buefy.snackbar.open({
        message: "Success",
        queue: false,
      });
    },
    trashCancel() {
      this.isModalActive = false;
    },
  },
};
</script>
