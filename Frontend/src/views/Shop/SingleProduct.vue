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
      <title>Product Page - Ustora Demo</title>

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
                    <a href="#"><i class="fa fa-user"></i> My Account</a>
                  </li>
                  <li>
                    <a target="_blank" href="http://localhost:8080/#/cart-check"><i class="fa fa-user"></i> My Cart</a>
                  </li>
                  <li>
                    <a target="_blank" href="http://localhost:8080/#/check-out"
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
                  <a href="./"><img src="img/logo.png" /></a>
                </h1>
              </div>
            </div>

            <div class="col-sm-6">
              <div class="shopping-item">
                <a target="_blank" href="http://localhost:8080/#/cart-check"
                  >Cart - <span class="cart-amunt">${{cartsData.total}}</span>
                  <i class="fa fa-shopping-cart"></i>
                  <span class="product-count">{{cartsData.item}}</span></a
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
             <ul class="nav navbar-nav" >
                <li><a target="_blank" href="http://localhost:8080/#/shop">Home</a></li>

              </ul>
              
              <ul class="nav navbar-nav" v-for="(category) in categories" v-bind:key="category.id">
                
                <li v-if="category.name === product.categoryName"  class="active"><a target="_blank" :href="'http://localhost:8080/#/products/'+category.name">{{category.name}}</a></li>
                <li v-else ><a target="_blank" :href="'http://localhost:8080/#/products/'+category.name">{{category.name}}</a></li>

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
                <h2>Shop</h2>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
          <div class="row">
            <div class="col-md-4">
              <!-- lấy category (chờ db) -->
              <div class="single-sidebar">
                <h2 class="sidebar-title" >Products</h2>
                <div class="thubmnail-recent" v-for="index in 3" v-bind:key="index">
                  <img
                    src="../Shop/img/product-thumb-1.jpg"
                    class="recent-thumb"
                    alt=""
                  />
                  <h2><a target="_blank" :href="'http://localhost:8080/#/product/'+(randomProducts[index-1].id)">{{ randomProducts[index-1].name }}</a></h2>
                  <div class="product-sidebar-price">
                    <ins>${{ randomProducts[index-1].price }}</ins> 
                  </div>
                </div>
                
              </div>
            </div>

            <div class="col-md-8">
              <div class="product-content-right">
                <div class="product-breadcroumb">
                  <a target="_blank" href="http://localhost:8080/#/shop">Home</a>
                  <a target="_blank" :href="'http://localhost:8080/#/products/'+product.categoryName">{{ product.categoryName }}</a>
                  <a href="#">{{ product.name }}</a>
                </div>

                <div class="row">
                  <div class="col-sm-6">
                    <div class="product-images">
                      <div class="product-main-img">
                        <img src="img/product-2.jpg" alt="" />
                      </div>

                      <div class="product-gallery">
                        <img src="img/product-thumb-1.jpg" alt="" />
                        <img src="img/product-thumb-2.jpg" alt="" />
                        <img src="img/product-thumb-3.jpg" alt="" />
                      </div>
                    </div>
                  </div>

                  <div class="col-sm-6">
                    <div class="product-inner">
                      <h2 class="product-name">{{ product.name }}</h2>
                      <div class="product-inner-price">
                        <ins>${{ product.price }}</ins>
                      </div>

                      <form action="" class="cart">
                        <div class="quantity">
                          <input
                            type="number"
                            size="4"
                            class="input-text qty text"
                            title="Qty"
                            value="1"
                            v-model="quantity"
                            name="quantity"
                            min="1"
                            step="1"
                          />
                        </div>
                        <button class="add_to_cart_button" v-on:click="addToCart(product,quantity)" type="submit">
                          Add to cart
                        </button>
                      </form>

                      <div class="product-inner-category">
                        <p>Category: <a :href="'http://localhost:8080/#/products/'+product.categoryName">{{ product.categoryName }}</a>.</p>
                      </div>

                      <div role="tabpanel">
                        <ul class="product-tab" role="tablist">
                          <li role="presentation" class="active">
                            <a
                              href="#home"
                              aria-controls="home"
                              role="tab"
                              data-toggle="tab"
                              >Description</a
                            >
                          </li>
                          
                        </ul>
                        <div class="tab-content">
                          <div
                            role="tabpanel"
                            class="tab-pane fade in active"
                            id="home"
                          >
                            <h2>Product Description</h2>
                            <p>{{ product.description }}</p>
                          </div>
                          
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="related-products-wrapper">
                  <h2 class="related-products-title">Related Products</h2>
                  <swiper class="swiper container" :options="swiperOptions1">
                    <swiper-slide
                      v-bind:key="relatedProduct.id"
                      v-for="relatedProduct in relatedProducts"
                    >
                      <div>
                        <img src="../Shop/img/product-4.jpg" alt="" />
                      </div>
                      <h2>
                        <a target="_blank" :href="'http://localhost:8080/#/product/'+(relatedProduct.id)">{{ relatedProduct.name }}</a>
                      </h2>
                      <div class="product-carousel-price">
                        <ins>${{ relatedProduct.price }}</ins> 
                      </div>
                    </swiper-slide>
                    <div class="swiper-pagination" slot="pagination"></div>
                  </swiper>
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
                  <li><a href="">My account</a></li>
                  <li><a href="">Front page</a></li>
                </ul>
              </div>
            </div>

            <div class="col-md-3 col-sm-6">
             
            </div>

            <div class="col-md-3 col-sm-6"></div>
          </div>
        </div>
      </div>
      <div class="footer-bottom-area">
        <div class="container">
          <div class="row">
            <div class="col-md-8">
              <div class="copyright">
                <p>&copy; 2022 Group3. All Rights Reserved.</p>
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
  name: "SingleProduct",
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
  //   beforeDestroy () {
  //     this.$store.dispatch('toggleFullPage', false)
  //   },
  data() {
    return {
      product: {},
      relatedProducts: [],
      randomProducts: [],
      categories: [],
      cartsData: {
        total:0,
        item: 0,
      },
      quantity:1,
      swiperOptions1: {
        slidesPerView: 3,
        spaceBetween: 30,
        navigation: {
          el: ".swiper-pagination",
          clickable: true,
        },

        // Some Swiper option/callback...
      },
    };
  },
  computed: {
    swiper() {
      return this.$refs.mySwiper.$swiper;
    },
  },

  mounted() {
    this.getProduct();
    this.getRandomProducts();
    this.getCategories();
    this.getCartDatas();
    loadScript("https://code.jquery.com/jquery.min.js");
    loadScript(
      "https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"
    );
    console.log("Current Swiper instance object", this.swiper);
    this.swiper.slideTo(3, 1000, false);
  },
  watch: {
    product(newValue, oldValue) {
      if (newValue) {
        this.getRelatedProducts(newValue);
      }
    },
  },
  methods: {
    async getProduct() {
      await axios
        .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Bouquets/${this.$route.params.id}`)
        .then((response) => {
          this.product = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    async getRandomProducts() {
      await axios
        .get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Bouquets`)
        .then((response) => {
          _.map(response.data, (item) => {
            this.randomProducts.push(Object.assign({}, item));
          });
           this.randomProducts= _.shuffle(this.randomProducts);
          console.log(this.randomProducts)
        })
        .catch((error) => {
          console.log(error);
        });
    },
    async getRelatedProducts(product) {
      await axios
        .get(
          `${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/bouquets-by-categories/${product.categoryId}`
        )
        .then((response) => {
          _.map(response.data, (item) => {
            console.log(item)
            this.relatedProducts.push(Object.assign({}, item));
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },
    async getCategories(){
      await axios.get(`${process.env.VUE_APP_LOCALHOST1_VARIABLE}/api/Data/categories`).then((res) => {
        this.categories = res.data;
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
        if(cartsDatas){
          _.map(cartsDatas, (cart) => {
            this.cartsData.total += cart.quantity * cart.bouquetPrice;
          });
          this.cartsData.item = cartsDatas.length;
        }

    },
    addToCart(product,quantity){
      this.$router.push({ path: '/cart-check', name:'Cart', params: {product,quantity }   })
    }
  },
};
</script>
