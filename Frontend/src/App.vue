<template>
  <div id="app">
    <nav-bar />
    <aside-menu :menu="menu" />
    <router-view />
    <footer-bar />
  </div>
</template>

<script>
import menu from "@/menu.js";
import NavBar from "@/components/NavBar.vue";
import AsideMenu from "@/components/AsideMenu.vue";
import FooterBar from "@/components/FooterBar.vue";
import axios from "axios";
import Vue from "vue";
require("dotenv").config();
export default {
  name: "Home",
  components: {
    FooterBar,
    AsideMenu,
    NavBar,
  },
  data() {
    return {
      menu,
      customer: {
        id: null,
        name: null,
        gender: null,
        address: null,
        phoneNumber: null,
        dateOfBirth: null,
        email: null,
		userName: null,
      },
    };
  },
  created() {
    this.getCustomer(localStorage.getItem("LoginData"));
  },
  methods: {
    getCustomer(id) {
      if (id != null && id != "") {
        axios
          .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Customers/${id}`)
          .then((r) => {
            this.customer = r.data;
            this.$store.commit("user", {
              name: this.customer.userName,
              email: this.customer.email,
            });
          })
          .catch((error) => {
            alert(error.message);
          });
      }
    },
  },
};
</script>
