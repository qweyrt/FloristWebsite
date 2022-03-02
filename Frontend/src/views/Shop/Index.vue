<template>
  <div>
    <html lang="en">
      <head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <title>Ustora Demo</title>

        <!-- Bootstrap -->
        <link rel="stylesheet" src="css/bootstrap.min.css" />

        <!-- Font Awesome -->
        <link rel="stylesheet" src="css/font-awesome.min.css" />

        <!-- Custom CSS -->
        <link rel="stylesheet" src="css/owl.carousel.css" />
        <link rel="stylesheet" src="style.css" />
        <link rel="stylesheet" src="css/responsive.css" />

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
                      <a href="#"><i class="fa fa-user"></i> My Account</a>
                    </li>
                    <li>
                      <a
                        target="_blank"
                        href="http://localhost:8080/#/cart-check"
                        ><i class="fa fa-user"></i> My Cart</a
                      >
                    </li>
                    <li>
                      <a
                        target="_blank"
                        href="http://localhost:8080/#/check-out"
                        ><i class="fa fa-user"></i> Checkout</a
                      >
                    </li>
                    <li>
                      <a href="#"><i class="fa fa-user"></i> Login</a>
                    </li>
                  </ul>
                </div>
              </div>

              <div class="col-md-4"></div>
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
                    <a href="./"><img src="../Shop/img/logo.png" /></a>
                  </h1>
                </div>
              </div>

              <div class="col-sm-6">
                <div class="shopping-item">
                  <a target="_blank" href="http://localhost:8080/#/cart-check"
                    >Cart -
                    <span class="cart-amunt">${{ cartsData.total }}</span>
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
                  <li class="active">
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
                      :href="
                        'http://localhost:8080/#/products/' + category.name
                      "
                      >{{ category.name }}</a
                    >
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
        <!-- End mainmenu area -->

        <swiper ref="mySwiper" class="container" :options="swiperOptions2">
          <swiper-slide class="block-slider">
            <img src="../Shop/img/h4-slide.png" alt="Slide" />
            <div class="caption-group">
              <h2 class="caption title">
                iPhone <span class="primary">6 <strong>Plus</strong></span>
              </h2>
              <h4 class="caption subtitle">Dual SIM</h4>
              <a class="caption button-radius" href="#"
                ><span class="icon"></span>Shop now</a
              >
            </div>
          </swiper-slide>
          <swiper-slide class="block-slider">
            <img src="../Shop/img/h4-slide.png" alt="Slide" />
            <div class="caption-group">
              <h2 class="caption title">
                iPhone <span class="primary">6 <strong>Plus</strong></span>
              </h2>
              <h4 class="caption subtitle">Dual SIM</h4>
              <a class="caption button-radius" href="#"
                ><span class="icon"></span>Shop now</a
              >
            </div>
          </swiper-slide>
          <div class="swiper-pagination" slot="pagination"></div>
        </swiper>
        <!-- End slider area -->

        <div class="promo-area">
          <div class="zigzag-bottom"></div>
          <div class="container">
            <div class="row">
              <div class="col-md-3 col-sm-6">
                <div class="single-promo promo1">
                  <i class="fa fa-refresh"></i>
                  <p>30 Days return</p>
                </div>
              </div>
              <div class="col-md-3 col-sm-6">
                <div class="single-promo promo2">
                  <i class="fa fa-truck"></i>
                  <p>Free shipping</p>
                </div>
              </div>
              <div class="col-md-3 col-sm-6">
                <div class="single-promo promo3">
                  <i class="fa fa-lock"></i>
                  <p>Secure payments</p>
                </div>
              </div>
              <div class="col-md-3 col-sm-6">
                <div class="single-promo promo4">
                  <i class="fa fa-gift"></i>
                  <p>New products</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- End promo area -->

        <div class="maincontent-area">
          <div class="zigzag-bottom"></div>
          <swiper class="swiper container" :options="swiperOptions1">
            <swiper-slide v-bind:key="product.id" v-for="product in products">
              <div>
                <img :src="product.images" alt="" />
              </div>
              <h2>
                <a href="single-product.html">{{ product.name }}</a>
              </h2>
              <div class="product-carousel-price">
                <ins>${{ product.price }}</ins> <del>$225.00</del>
              </div>
            </swiper-slide>
            <div class="swiper-pagination" slot="pagination"></div>
          </swiper>
        </div>

        <!-- End main content area -->

        <div class="brands-area">
          <div class="zigzag-bottom"></div>
          <div class="container">
            <div class="row">
              <div class="col-md-12">
                <div class="brand-wrapper">
                  <div class="brand-list">
                    <img src="img/brand1.png" alt="" />
                    <img src="img/brand2.png" alt="" />
                    <img src="img/brand3.png" alt="" />
                    <img src="img/brand4.png" alt="" />
                    <img src="img/brand5.png" alt="" />
                    <img src="img/brand6.png" alt="" />
                    <img src="img/brand1.png" alt="" />
                    <img src="img/brand2.png" alt="" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- End brands area -->

        <div class="product-widget-area">
          <div class="zigzag-bottom"></div>
          <div class="container">
            <div class="row">
              <div class="col-md-4">
                <div class="single-product-widget">
                  <h2 class="product-wid-title">Brithday</h2>
                  <a
                    target="_blank"
                    href="http://localhost:8080/#/products/Birthday"
                    class="wid-view-more"
                    >View All</a
                  >
                  <div
                    v-for="brithdayProduct in brithdayProducts"
                    v-bind:key="brithdayProduct.id"
                  >
                    <div class="single-wid-product">
                      <a
                        target="_blank"
                        :href="
                          'http://localhost:8080/#/product/' +
                          brithdayProduct.id
                        "
                        ><img
                          :src="brithdayProduct.images"
                          alt=""
                          class="product-thumb"
                      /></a>
                      <h2>
                        <a
                          target="_blank"
                          :href="
                            'http://localhost:8080/#/product/' +
                            brithdayProduct.id
                          "
                          >{{ brithdayProduct.name }}</a
                        >
                      </h2>
                      <div class="product-wid-price">
                        <ins>${{ brithdayProduct.price }}</ins>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-4">
                <div class="single-product-widget">
                  <h2 class="product-wid-title">Christmas</h2>
                  <a
                    target="_blank"
                    href="http://localhost:8080/#/products/Christmas"
                    class="wid-view-more"
                    >View All</a
                  >
                  <div
                    v-for="christmasProduct in christmasProducts"
                    v-bind:key="christmasProduct.id"
                  >
                    <div class="single-wid-product">
                      <a
                        target="_blank"
                        :href="
                          'http://localhost:8080/#/product/' +
                          christmasProduct.id
                        "
                        ><img
                          :src="christmasProduct.images"
                          alt=""
                          class="product-thumb"
                      /></a>
                      <h2>
                        <a
                          target="_blank"
                          :href="
                            'http://localhost:8080/#/product/' +
                            christmasProduct.id
                          "
                          >{{ christmasProduct.name }}</a
                        >
                      </h2>
                      <div class="product-wid-price">
                        <ins>${{ christmasProduct.price }}</ins>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-4">
                <div class="single-product-widget">
                  <h2 class="product-wid-title">Anniversary</h2>
                  <a
                    target="_blank"
                    href="http://localhost:8080/#/products/Anniversary"
                    class="wid-view-more"
                    >View All</a
                  >
                  <div
                    v-for="anniversaryProduct in anniversaryProducts"
                    v-bind:key="anniversaryProduct.id"
                  >
                    <div class="single-wid-product">
                      <a
                        target="_blank"
                        :href="
                          'http://localhost:8080/#/product/' +
                          anniversaryProduct.id
                        "
                        ><img
                          :src="anniversaryProduct.images"
                          alt=""
                          class="product-thumb"
                      /></a>
                      <h2>
                        <a
                          target="_blank"
                          :href="
                            'http://localhost:8080/#/product/' +
                            anniversaryProduct.id
                          "
                          >{{ anniversaryProduct.name }}</a
                        >
                      </h2>
                      <div class="product-wid-price">
                        <ins>${{ anniversaryProduct.price }}</ins>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- End product widget area -->

        <div class="footer-top-area">
          <div class="zigzag-bottom"></div>
          <div class="container">
            <div class="row">
              <div class="col-md-3 col-sm-6">
                <div class="footer-about-us">
                  <h2>u<span>Stora</span></h2>
                  <p></p>
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
                  <p>
                    &copy; 2022 Group 3. All Rights Reserved.
                    <a href="http://www.freshdesignweb.com" target="_blank"
                      >freshDesignweb.com</a
                    >
                  </p>
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
  </div>
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
  name: "Index",
  components: {
    Swiper,
    SwiperSlide,
  },
  directives: {
    swiper: directive,
  },
  created() {
    this.$store.dispatch("toggleFullPage", true);
  },
  beforeDestroy() {
    this.$store.dispatch("toggleFullPage", false);
  },
  data() {
    return {
      products: [],
      categories: [],
      brithdayProducts: [],
      christmasProducts: [],
      anniversaryProducts: [],
      cartsData: {
        total: 0,
        item: 0,
      },
      swiperOptions1: {
        slidesPerView: 3,
        spaceBetween: 30,
        navigation: {
          el: ".swiper-pagination",
          clickable: true,
        },

        // Some Swiper option/callback...
      },
      swiperOptions2: {
        spaceBetween: 30,
        centeredSlides: true,
        autoplay: {
          delay: 2500,
          disableOnInteraction: false,
        },
        pagination: {
          el: ".swiper-pagination",
          clickable: true,
        },
        navigation: {
          nextEl: ".swiper-button-next",
          prevEl: ".swiper-button-prev",
        },
      },
    };
  },
  computed: {
    swiper() {
      return this.$refs.mySwiper.$swiper;
    },
  },

  mounted() {
    this.listProducts();
    this.getCategories();
    this.getRelatedProducts();
    this.getCartDatas();
    loadScript("https://code.jquery.com/jquery.min.js");
    loadScript(
      "https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"
    );
    this.swiper.slideTo(3, 1000, false);
  },
  methods: {
    async listProducts() {
      await axios
        .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Bouquets`)
        .then((response) => {
          _.map(response.data, (item) => {
            this.products.push(Object.assign({}, item));
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
    async getRelatedProducts() {
      await axios
        .get(
          `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/bouquets-by-categories/1`
        )
        .then((response) => {
          _.map(response.data, (item) => {
            this.brithdayProducts.push(Object.assign({}, item));
          });
          console.log(this.brithdayProducts);
        })
        .catch((error) => {
          console.log(error);
        });
      await axios
        .get(
          `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/bouquets-by-categories/2`
        )
        .then((response) => {
          _.map(response.data, (item) => {
            this.christmasProducts.push(Object.assign({}, item));
          });
        })
        .catch((error) => {
          console.log(error);
        });
      await axios
        .get(
          `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/bouquets-by-categories/3`
        )
        .then((response) => {
          _.map(response.data, (item) => {
            this.anniversaryProducts.push(Object.assign({}, item));
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },
    async getCartDatas() {
      let cartsDatas = [];
      await axios
        .get(
          `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/cart-by-customer/1`
        )
        .then((response) => {
          cartsDatas = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
      console.log(cartsDatas);
      if (cartsDatas) {
        _.map(cartsDatas, (cart) => {
          this.cartsData.total += cart.quantity * cart.bouquetPrice;
        });
        this.cartsData.item = cartsDatas.length;
      }
    },
  },
};
</script>
