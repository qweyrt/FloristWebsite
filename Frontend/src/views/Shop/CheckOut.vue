<template>
  <!DOCTYPE html>
  <!--
	ustora by freshdesignweb.com
	Twitter: https://twitter.com/freshdesignweb
	URL: https://www.freshdesignweb.com/ustora/
-->
  <html lang="en">
    <head>
      <meta charset="utf-8" />
      <meta http-equiv="X-UA-Compatible" content="IE=edge" />
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <title>Checkout Page - Ustora Demo</title>

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
      <link rel="stylesheet" href="css/bootstrap.min.css" />

      <!-- Font Awesome -->
      <link rel="stylesheet" href="css/font-awesome.min.css" />

      <!-- Custom CSS -->
      <link rel="stylesheet" href="css/owl.carousel.css" />
      <link rel="stylesheet" href="style.css" />
      <link rel="stylesheet" href="css/responsive.css" />

      <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
      <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
      <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
      <![endif]-->
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
                    <a target="_blank" href="http://localhost:8080/#/login"
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
                <h2>Checkout</h2>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <div class="product-content-right">
                <div class="woocommerce">
                  

                  <form
                    enctype="multipart/form-data"
                    action="#"
                    class="checkout"
                    method="post"
                    name="checkout"
                  >
                    <div id="customer_details" class="col2-set">
                      
                    </div>

                    <h3 id="order_review_heading">Your order</h3>

                    <div id="order_review" style="position: relative">
                      <table class="shop_table">
                        <thead>
                          <tr>
                            <th class="product-name">Product</th>
                            <th class="product-total">Total</th>
                          </tr>
                        </thead>
                        <tbody v-for="cart in carts" v-bind:key="cart.id">
                          <tr class="cart_item">
                            <td class="product-name">
                              {{ cart.bouquetName }}
                              <strong class="product-quantity"
                                >×{{ cart.quantity }}
                              </strong>
                            </td>
                            <td class="product-total">
                              <span class="amount"
                                >${{ cart.bouquetPrice * cart.quantity }}</span
                              >
                            </td>
                          </tr>
                        </tbody>
                        <tfoot>
                          <tr class="cart-subtotal">
                            <th>Cart Subtotal</th>
                            <td>
                              <span class="amount">${{ total }}</span>
                            </td>
                          </tr>

                          <tr class="shipping">
                            <th>Shipping and Handling</th>
                            <td>
                              Free Shipping
                              <input
                                type="hidden"
                                class="shipping_method"
                                value="free_shipping"
                                id="shipping_method_0"
                                data-index="0"
                                name="shipping_method[0]"
                              />
                            </td>
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
                        </tfoot>
                      </table>

                      <div id="payment">
                        <ul class="payment_methods methods">
                          <li class="payment_method_bacs">
                            <input
                              type="radio"
                              data-order_button_text=""
                              checked="checked"
                              value="bacs"
                              name="payment_method"
                              class="input-radio"
                              id="payment_method_bacs"
                            />
                            <label for="payment_method_bacs"
                              >Direct Bank Transfer
                            </label>
                            <div class="payment_box payment_method_bacs">
                              <p>
                                Make your payment directly into our bank
                                account. Please use your Order ID as the payment
                                reference. Your order won’t be shipped until the
                                funds have cleared in our account.
                              </p>
                            </div>
                          </li>
                          <li class="payment_method_cheque">
                            <input
                              type="radio"
                              data-order_button_text=""
                              value="cheque"
                              name="payment_method"
                              class="input-radio"
                              id="payment_method_cheque"
                            />
                            <label for="payment_method_cheque"
                              >Cheque Payment
                            </label>
                            <div
                              style="display: none"
                              class="payment_box payment_method_cheque"
                            >
                              <p>
                                Please send your cheque to Store Name, Store
                                Street, Store Town, Store State / County, Store
                                Postcode.
                              </p>
                            </div>
                          </li>
                          <li class="payment_method_paypal">
                            <input
                              type="radio"
                              data-order_button_text="Proceed to PayPal"
                              value="paypal"
                              name="payment_method"
                              class="input-radio"
                              id="payment_method_paypal"
                            />
                            <label for="payment_method_paypal"
                              >PayPal
                              <img
                                alt="PayPal Acceptance Mark"
                                src="https://www.paypalobjects.com/webstatic/mktg/Logo/AM_mc_vs_ms_ae_UK.png"
                              /><a
                                title="What is PayPal?"
                                onclick="javascript:window.open('https://www.paypal.com/gb/webapps/mpp/paypal-popup','WIPaypal','toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, width=1060, height=700'); return false;"
                                class="about_paypal"
                                href="https://www.paypal.com/gb/webapps/mpp/paypal-popup"
                                >What is PayPal?</a
                              >
                            </label>
                            <div
                              style="display: none"
                              class="payment_box payment_method_paypal"
                            >
                              <p>
                                Pay via PayPal; you can pay with your credit
                                card if you don’t have a PayPal account.
                              </p>
                            </div>
                          </li>
                        </ul>

                        <div class="form-row place-order">
                          <a
                            class="add_to_cart_button"
                            data-quantity="1"
                            data-product_sku=""
                            data-product_id="70"
                            rel="nofollow"
                            href="http://localhost:8080/#/check-out"
                            >Place order</a
                          >
                        </div>

                        <div class="clear"></div>
                      </div>
                    </div>
                  </form>
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
            <div class="col-md-3 col-sm-6"></div>

            <div class="col-md-3 col-sm-6">
              <div class="footer-menu">
                <h2 class="footer-wid-title">User Navigation</h2>
                <ul>
                  <li><a href="">My account</a></li>
                  <li><a href="">Front page</a></li>
                </ul>
              </div>
            </div>

            <div class="col-md-3 col-sm-6"></div>

            <div class="col-md-3 col-sm-6"></div>
          </div>
        </div>
      </div>
      <div class="footer-bottom-area">
        <div class="container">
          <div class="row">
            <div class="col-md-8">
              <div class="copyright">
                <p>&copy; 2022 Group 3. All Rights Reserved.</p>
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
import axios from "axios";
import _ from "lodash";

import { Swiper, SwiperSlide, directive } from "vue-awesome-swiper";

// import style (>= Swiper 6.x)
import "swiper/css/swiper.css";
import { loadScript } from "vue-plugin-load-script";
export default {
  name: "CheckOut",
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
      categories: [],
      total: 0,
    };
  },
  computed: {},

  mounted() {
    this.getCurrentUser();
    this.getCartItems();
    this.getCategories();
    this.getRandomProducts();
    loadScript("https://code.jquery.com/jquery.min.js");
    loadScript(
      "https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"
    );
  },
  methods: {
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
    async getCartTotal() {
      await _.map(this.carts, (cart) => {
        this.total += cart.quantity * cart.bouquetPrice;
      });
    },
    logout() {
      localStorage.removeItem("LoginData");
      this.$router.push("/shop");
      this.$buefy.snackbar.open({
        message: "Logged out!",
        queue: false,
      });
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
          if (res.status === 200) {
            this.$buefy.snackbar.open({
              message: "deleted",
              queue: false,
            });
            this.carts.splice(index, 1);
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
          console.log(this.randomProducts);
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

    //10/10 - lam chu cong nghe copilot - nguyen van a
  },
};
</script>
