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
            <b-field
              label="Description"
              message="Bouquet's description"
              horizontal
            >
              <b-input type="textarea" v-model="form.description" />
            </b-field>
            <b-field label="Category" message="Category's name" horizontal>
              <b-select v-model="form.categoryId" placeholder="e.g. Birthday">
                <option
                  v-for="option in categories"
                  :value="option.id"
                  :key="option.id"
                >
                  {{ option.name }}
                </option>
              </b-select>
            </b-field>
            <b-field label="Image" message="Bouquet's image" horizontal>
              <b-upload v-model="dropFiles" multiple drag-drop expanded>
                <section class="section">
                  <div class="content has-text-centered">
                    <p>
                      <b-icon icon="upload" size="is-large"> </b-icon>
                    </p>
                    <p>Drop your files here or click to upload</p>
                  </div>
                </section>
              </b-upload>
              <div class="tags">
                <span
                  v-for="(file, index) in dropFiles"
                  :key="index"
                  class="tag is-primary"
                >
                  {{ file.name }}
                  <button
                    class="delete is-small"
                    type="button"
                    @click="deleteDropFile(index)"
                  ></button>
                </span>
              </div>
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
          <hr />
          <b-field label="Name">
            <b-input :value="form.name" custom-class="is-static" readonly />
          </b-field>
          <b-field label="Price">
            <b-input :value="form.price" custom-class="is-static" readonly />
          </b-field>
          <b-field label="Description">
            <b-input
              :value="form.description"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Category">
            <b-input
              :value="form.categoryName"
              custom-class="is-static"
              readonly
            />
          </b-field>
          <b-field label="Image">
            <b-upload v-model="dropFiles" multiple drag-drop>
              <section class="section">
                <div class="content has-text-centered">
                  <p>
                    <b-icon icon="upload" size="is-large"> </b-icon>
                  </p>
                  <p>Drop your files here or click to upload</p>
                </div>
              </section>
            </b-upload>
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
  name: "BouquetsForm",
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
        description: null,
        images: null,
        categoryId: null,
        categoryName: null,
      },
      createdReadable: null,
      dropFiles: [],
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
    ...mapState(["bouquets", "categories"]),
  },
  watch: {
    id(newValue) {
      this.isProfileExists = false;

      if (!newValue) {
        this.form.id = null;
        this.form.name = null;
        this.form.price = null;
        this.form.description = null;
        this.form.images = null;
        this.form.categoryId = null;
        this.form.categoryName = null;
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
          this.form.description = item.description;
          this.form.images = item.images;
          this.form.categoryId = item.categoryId;
          this.form.categoryName = item.categoryName;
        } else {
          this.$router.push({ name: "bouquets.new" });
        }
      }
    },
    createBouquet() {
      var bouquet = {
        name: this.form.name,
        price: parseInt(this.form.price),
        description: this.form.description,
        images: JSON.stringify(this.dropFiles),
        categoryId: this.form.categoryId,
      };
      var parse = JSON.stringify(bouquet);
		console.log(this.dropFiles)
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .post(`http://localhost:${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Bouquets/add`, parse, options)
        .then((response) => {
          store.dispatch("fetchBouquets", "bouquets");
        });
    },
    updateBouquet() {
      var bouquet = {
        id: this.form.id,
        name: this.form.name,
        price: parseInt(this.form.price),
        description: this.form.description,
        images: this.form.images,
        categoryId: this.form.categoryId,
      };
      var parse = JSON.stringify(bouquet);
      const options = {
        headers: { "content-type": "application/json" },
      };
      axios
        .put(`http://localhost:${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Bouquets/update`, parse, options)
        .then((response) => {
          store.dispatch("fetchBouquets", "bouquets");
        });
    },
    deleteDropFile(index) {
      this.dropFiles.splice(index, 1);
    },
    dateInput(v) {
      this.createdReadable = new Date(v).toLocaleDateString();
    },
    submit() {
      this.isLoading = true;
      if (!this.isProfileExists) {
        this.createBouquet();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/bouquets");
          this.$buefy.snackbar.open({
            message: "Success!",
            queue: false,
          });
        }, 750);
      } else if (this.isProfileExists) {
        this.updateBouquet();
        setTimeout(() => {
          this.isLoading = false;
          this.$router.push("/bouquets");
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
