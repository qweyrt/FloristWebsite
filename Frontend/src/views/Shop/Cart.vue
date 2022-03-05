<template>
  <!DOCTYPE html>
  <html lang="en">
    <head>
      <meta charset="utf-8" />
      <meta http-equiv="X-UA-Compatible" content="IE=edge" />
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <title>Cart</title>

      <!-- Google Fonts -->
      <link
        href="http://fonts.googleapis.com/css?family=Titillium+Web:400,200,300,700,600"
        rel="stylesheet"
        type="text/css"
      />
      <link
        href="http://fonts.googleapis.com/css?family=Roboto+Condensed:400,700,300"
        rel="stylesheet"
        type="text/css"
      />
      <link
        href="http://fonts.googleapis.com/css?family=Raleway:400,100"
        rel="stylesheet"
        type="text/css"
      />
      <!-- Bootstrap -->
      <link rel="stylesheet" src="css/bootstrap.min.css" />

      <!-- Font Awesome -->
      <link rel="stylesheet" src="css/font-awesome.min.css" />

      <!-- Custom CSS -->
      <link rel="stylesheet" src="css/owl.carousel.css" />
      <link rel="stylesheet" src="style.css" />
      <link rel="stylesheet" src="css/responsive.css" />
    </head>
    <body>
      <div class="header-area">
        <div class="container">
          <div class="row">
            <div class="col-md-8">
              <div class="user-menu">
                <ul>
                  <li>
                    <a target="_blank" href="http://localhost:8080/#/cart-check"
                      ><i class="fa fa-user"></i> My Cart</a
                    >
                  </li>
                  <li>
                    <a target="_blank" href="http://localhost:8080/#/check-out"
                      ><i class="fa fa-user"></i> Checkout</a
                    >
                  </li>
                  <li v-if="userData.id">Hello {{ userData.userName }}</li>
                  <li v-else>
                    <a target="_blank" href="http://localhost:8080/#/login"
                      ><i class="fa fa-user"></i> Login</a
                    >
                  </li>
                </ul>
              </div>
            </div>

            <div class="col-md-4">
              <div class="user-menu">
                <ul>
                  <li v-if="userData.id">
                    <a target="_blank" v-on:click="logout()"
                      ><i class="fa fa-user"></i> Log out</a
                    >
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- End header area -->

      <div class="site-branding-area">
        <div class="container">
          <div class="row">
            <div class="col-sm-6">
              <div class="logo">
                <h1>
                  <a target="_blank" href="http://localhost:8080/#/shop"
                    ><img src="../Shop/img/banner.png" width="100" height="100"
                  /></a>
                </h1>
              </div>
            </div>

            <div class="col-sm-6">
              <div class="shopping-item">
                <a target="_blank" href="http://localhost:8080/#/cart-check"
                  >Cart - <span class="cart-amunt">${{ cartsData.total }}</span>
                  <i class="fa fa-shopping-cart"></i>
                  <span class="product-count">{{ cartsData.item }}</span></a
                >
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- End site branding area -->

      <div class="mainmenu-area">
        <div class="container">
          <div class="row">
            <div class="navbar-header">
              <button
                type="button"
                class="navbar-toggle"
                data-toggle="collapse"
                data-target=".navbar-collapse"
              >
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
            </div>
            <div class="navbar-collapse collapse">
              <ul class="nav navbar-nav">
                <li>
                  <a target="_blank" href="http://localhost:8080/#/shop"
                    >Home</a
                  >
                </li>
              </ul>

              <ul
                class="nav navbar-nav"
                v-for="category in categories"
                v-bind:key="category.id"
              >
                <li>
                  <a
                    target="_blank"
                    :href="'http://localhost:8080/#/products/' + category.name"
                    >{{ category.name }}</a
                  >
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <!-- End mainmenu area -->

      <div class="product-big-title-area">
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <div class="product-bit-title text-center">
                <h2>Shopping Cart</h2>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- End Page title area -->

      <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <div class="product-content-right">
                <div class="woocommerce">
                  <form method="post" action="#">
                    <table cellspacing="0" class="shop_table cart">
                      <thead>
                        <tr>
                          <th class="product-remove">&nbsp;</th>
                          <th class="product-thumbnail">&nbsp;</th>
                          <th class="product-name">Product</th>
                          <th class="product-price">Price</th>
                          <th class="product-quantity">Quantity</th>
                          <th class="product-subtotal">Total</th>
                        </tr>
                      </thead>
                      <tbody
                        v-for="(cart, index) in carts"
                        v-bind:key="cart.id"
                      >
                        <tr class="cart_item">
                          <td class="product-remove">
                            <a
                              title="Remove this item"
                              class="remove"
                              v-on:click="deleteCartItem(index)"
                              >×</a
                            >
                          </td>

                          <td class="product-thumbnail">
                            <a
                              :href="
                                'http://localhost:8080/#/products/' +
                                cart.bouquetId
                              "
                              ><img
                                width="145"
                                height="145"
                                alt="poster_1_up"
                                class="shop_thumbnail"
                                :src="cart.bouquetImages"
                            /></a>
                          </td>

                          <td class="product-name">
                            <a
                              target="_blank"
                              :href="
                                'http://localhost:8080/#/products/' +
                                cart.bouquetId
                              "
                              >{{ cart.bouquetName }}</a
                            >
                          </td>

                          <td class="product-price">
                            <span class="amount">${{ cart.bouquetPrice }}</span>
                          </td>

                          <td class="product-quantity">
                            <div class="quantity buttons_added">
                              <input
                                type="button"
                                v-on:click="cart.quantity--"
                                class="minus"
                                value="-"
                              />
                              <input
                                type="number"
                                size="4"
                                class="input-text qty text"
                                title="Qty"
                                value="1"
                                min="0"
                                step="1"
                                v-model="cart.quantity"
                              />
                              <input
                                type="button"
                                v-on:click="cart.quantity++"
                                class="plus"
                                value="+"
                              />
                            </div>
                          </td>

                          <td class="product-subtotal">
                            <span class="amount"
                              >${{ cart.bouquetPrice * cart.quantity }}</span
                            >
                          </td>
                        </tr>
                      </tbody>
                      <tbody>
                        <tr>
                          <td class="actions" colspan="6">
                            <a
                              class="add_to_cart_button"
                              data-quantity="1"
                              data-product_sku=""
                              data-product_id="70"
                              rel="nofollow"
                              v-on:click="updateCart()"
                              >Update Cart</a
                            >

                            <a
                              class="add_to_cart_button"
                              data-quantity="1"
                              data-product_sku=""
                              data-product_id="70"
                              rel="nofollow"
                              href="http://localhost:8080/#/check-out"
                              >checkout</a
                            >
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </form>

                  <div class="cart-collaterals">
                    <div class="cross-sells">
                      <h2>You may be interested in...</h2>
                      <ul
                        class="products"
                        v-for="index in 2"
                        v-bind:key="index"
                      >
                        <li class="product">
                          <a
                            target="_blank"
                            :href="
                              'http://localhost:8080/#/product/' +
                              randomProducts[index - 1].id
                            "
                          >
                            <img
                              width="325"
                              height="325"
                              alt="T_4_front"
                              class="attachment-shop_catalog wp-post-image"
                              :src="randomProducts[index - 1].images"
                            />
                            <h3>
                              {{ randomProducts[index - 1].name }} {{ index }}
                            </h3>
                            <span class="price"
                              ><span class="amount"
                                >${{ randomProducts[index - 1].price }}</span
                              ></span
                            >
                          </a>
                        </li>
                      </ul>
                    </div>

                    <div class="cart_totals">
                      <h2>Cart Totals</h2>

                      <table cellspacing="0">
                        <tbody>
                          <tr class="cart-subtotal">
                            <th>Cart Subtotal</th>
                            <td>
                              <span class="amount">${{ total }}</span>
                            </td>
                          </tr>

                          <tr class="shipping">
                            <th>Shipping and Handling</th>
                            <td>Free Shipping</td>
                          </tr>

                          <tr class="order-total">
                            <th>Order Total</th>
                            <td>
                              <strong
                                ><span class="amount"
                                  >${{ total }}</span
                                ></strong
                              >
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="footer-top-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
          <div class="row">
            <div class="col-md-3 col-sm-6">
              <div class="footer-about-us">
                <h2>u<span>Stora</span></h2>
              </div>
            </div>

            <div class="col-md-3 col-sm-6">
              <div class="footer-menu">
                <h2 class="footer-wid-title">User Navigation</h2>
                <ul>
                  <li><a href="#">My account</a></li>
                  <li><a href="#">Front page</a></li>
                </ul>
              </div>
            </div>

            <div class="col-md-3 col-sm-6"></div>

            <div class="col-md-3 col-sm-6"></div>
          </div>
        </div>
      </div>
      <!-- End footer top area -->

      <div class="footer-bottom-area">
        <div class="container">
          <div class="row">
            <div class="col-md-8">
              <div class="copyright">
                <p>&copy; 2022 group 3. All Rights Reserved.</p>
              </div>
            </div>

            <div class="col-md-4">
              <div class="footer-card-icon">
                <i class="fa fa-cc-discover"></i>
                <i class="fa fa-cc-mastercard"></i>
                <i class="fa fa-cc-paypal"></i>
                <i class="fa fa-cc-visa"></i>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- End footer bottom area -->
    </body>
  </html>
</template>
<!-- End footer bottom area -->
<style>
@import url("http://fonts.googleapis.com/css?family=Titillium+Web:400,200,300,700,600");
@import url("http://fonts.googleapis.com/css?family=Roboto+Condensed:400,700,300");
@import url("http://fonts.googleapis.com/css?family=Raleway:400,100");
</style>

<script>
import "../Shop/css/bootstrap.min.css";
import "../Shop/css/font-awesome.min.css";
import "../Shop/css/responsive.css";
import "../Shop/style.css";
import "../Shop/css/owl.carousel.css";
import store from "../../store";

import axios from "axios";
import { mapState } from "vuex";

import _ from "lodash";

import { Swiper, SwiperSlide, directive } from "vue-awesome-swiper";

// import style (>= Swiper 6.x)
import "swiper/css/swiper.css";
import { loadScript } from "vue-plugin-load-script";
export default {
  name: "Cart",
  components: {},
  directives: {},
  created() {
    this.$store.dispatch("toggleFullPage", true);
  },
  //   beforeDestroy () {
  //     this.$store.dispatch('toggleFullPage', false)
  //   },
  data() {
    return {
      product: {},
      userData: {},
      relatedProducts: [],
      randomProducts: [],
      carts: [],
      cartsData: {
        total: 0,
        item: 0,
      },
      categories: [],
      total: 0,
    };
  },
  computed: {},

  mounted() {
    console.log(this.$route);
    this.getCurrentUser();
    if (this.$route.params.product) {
      this.addToCart();
    } else {
      this.getCartItems();
      this.getCartDatas();
    }
    this.getCategories();
    this.getRandomProducts();

    loadScript("https://code.jquery.com/jquery.min.js");
    loadScript(
      "https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"
    );
  },
  methods: {
    async getCartTotal() {
      let count = 0;
      await _.map(this.carts, (cart) => {
        count += cart.quantity * cart.bouquetPrice;
      });
      this.total = count;
    },
    async getCartItems() {
      const userId = localStorage.getItem("LoginData");
      if (userId) {
        await axios
          .get(
            `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/cart-by-customer/${userId}`
          )
          .then((response) => {
            this.carts = response.data;
            this.getCartTotal();
          })
          .catch((error) => {
            console.log(error);
          });
      }
    },
    async deleteCartItem(index) {
      const deletedCart = this.carts[index];
      await axios
        .delete(
          `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Carts/delete/${deletedCart.id}`
        )
        .then((res) => {
          console.log(res);
          if (res.status === 200) {
           this.$buefy.snackbar.open({
                message: "deleted",
                queue: false,
              });
            this.carts.splice(index, 1);
            this.getCartTotal();
          }
        });
    },
    async getRandomProducts() {
      await axios
        .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Bouquets`)
        .then((response) => {
          _.map(response.data, (item) => {
            this.randomProducts.push(Object.assign({}, item));
          });
          this.randomProducts = _.shuffle(this.randomProducts);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    updateCart() {
      _.map(this.carts, (cart) => {
        axios
          .put(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Carts/update`, {
            id: cart.id,
            quantity: cart.quantity,
            isActive: true,
            bouquetId: cart.bouquetId,
            customerId: cart.customerId,
            recipientId: cart.recipientId,
            bouquetMessageId: cart.bouquetMessageId,
          })
          .then((res) => {
            if (res.status === 200) {
              this.getCartTotal();
              this.getCartDatas();
              this.$buefy.snackbar.open({
                message: "updated",
                queue: false,
              });
            }
          });
      });
    },
    async getCategories() {
      await axios
        .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/categories`)
        .then((res) => {
          this.categories = res.data;
        });
    },
    async getCartDatas() {
      let cartsDatas = [];
      const userId = localStorage.getItem("LoginData");
      if (userId) {
        await axios
          .get(
            `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/cart-by-customer/${userId}`
          )
          .then((response) => {
            cartsDatas = response.data;
          })
          .catch((error) => {
            console.log(error);
          });
      }

      if (cartsDatas) {
        _.map(cartsDatas, (cart) => {
          this.cartsData.total += cart.quantity * cart.bouquetPrice;
        });
        this.cartsData.item = cartsDatas.length;
      }
    },
    async getCurrentUser() {
      const userId = localStorage.getItem("LoginData");
      if (userId) {
        await axios
          .get(
            `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Customers/${userId}`
          )
          .then((res) => {
            this.userData = res.data;
          });
      }
    },
    logout() {
      localStorage.removeItem("LoginData");
      this.$router.push("/shop");
      this.$buefy.snackbar.open({
        message: "Logged out!",
        queue: false,
      });
    },
     addToCart() {
      const userId = localStorage.getItem("LoginData");
      console.log(this.$route.params);
      console.log("a");
      const options = {
        headers: { "content-type": "application/json" },
      };
      const cart={
        quantity: parseInt(this.$route.params.quantity),
          bouquetId: this.$route.params.product.id,
          customerId: 2, //de ung voi khach hang
          recipientId: 1, //de ung voi khach hang
          bouquetMessageId: 1, //giu nguyen
      }
      var parse = JSON.stringify(cart);
       axios
        .post(`https://localhost:5001/api/Carts/add`,parse ,options)
        .then((res) => {
          console.log(res);
          if (res.statusText === "Created") {
            this.getCartItems();
            this.getCartTotal();
            this.getCartDatas();
          }
        })
        .catch((err) => console.log(err));
    }, //toi da khoc
    //AI qua thong minh
    //doc duoc ca suy nghi a
    //10/10

    //10/10 - lam chu cong nghe copilot - nguyen van a
  },
};
</script>
