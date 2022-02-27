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
      <title>Shop Page- Ustora Demo</title>

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
                    <a href="#"><i class="fa fa-heart"></i> Wishlist</a>
                  </li>
                  <li>
                    <a href="cart.html"><i class="fa fa-user"></i> My Cart</a>
                  </li>
                  <li>
                    <a href="checkout.html"
                      ><i class="fa fa-user"></i> Checkout</a
                    >
                  </li>
                  <li>
                    <a href="#"><i class="fa fa-user"></i> Login</a>
                  </li>
                </ul>
              </div>
            </div>

            <div class="col-md-4">
              
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
                  <a href="./"><img src="img/logo.png" /></a>
                </h1>
              </div>
            </div>

            <div class="col-sm-6">
              <div class="shopping-item">
                <a href="cart.html"
                  >Cart - <span class="cart-amunt">$100</span>
                  <i class="fa fa-shopping-cart"></i>
                  <span class="product-count">5</span></a
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
                
                <li v-if="category.name === routeName"  class="active"><a target="_blank" :href="'http://localhost:8080/#/products/'+category.name">{{category.name}}</a></li>
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
                <h2>{{catName}}</h2>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
          <div class="row" v-for="(product,index) in products" v-bind:key="product.id">
            <div class="col-md-3 col-sm-6">
              <div class="single-shop-product">
                <div class="product-upper">
                  <img src="../Shop/img/product-2.jpg" alt="" />
                </div>
                <h2><a :href="'http://localhost:8080/#/product/'+(index+1)">{{ product.name }}</a></h2>
                <div class="product-carousel-price">
                  <ins>${{ product.price }}</ins> 
                </div>

                <div class="product-option-shop">
                  <a
                    class="add_to_cart_button"
                    data-quantity="1"
                    data-product_sku=""
                    data-product_id="70"
                    rel="nofollow"
                    href="/canvas/shop/?add-to-cart=70"
                    >Add to cart</a
                  >
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
                  <li><a href="">Order history</a></li>
                  <li><a href="">Wishlist</a></li>
                  <li><a href="">Vendor contact</a></li>
                  <li><a href="">Front page</a></li>
                </ul>
              </div>
            </div>

            
          </div>
        </div>
      </div>
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

// import style (>= Swiper 6.x)
import "swiper/css/swiper.css";
import { loadScript } from "vue-plugin-load-script";
export default {
  name: "Shop",
  components: {
   
  },
  directives: {
   
  },
  created() {
    this.$store.dispatch("toggleFullPage", true);
  },
  //   beforeDestroy() {
  //     this.$store.dispatch("toggleFullPage", false);
  //   },
  data() {
    return {
      products: [],
      categories: [],
      catName: '',
      routeName: '',
    };
  },
  computed: {
    swiper() {
      return this.$refs.mySwiper.$swiper;
    },
  },

  mounted() {
    this.listProductsByCategory();
    loadScript("https://code.jquery.com/jquery.min.js");
    loadScript(
      "https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"
    );
    this.swiper.slideTo(3, 1000, false);
  },
  methods: {
    async listProductsByCategory() {
      this.routeName = this.$route.params.category
      let id = 0
      await axios.get("https://localhost:5001/api/Data/categories").then((res) => {
        this.categories = res.data;
      });
      _.map(this.categories, (category) =>{
        if(category.name === this.$route.params.category){
          id = category.id;
          this.catName = category.name;
        }
      })
      console.log(id)
      //khong chac chan
      await axios
        .get(`https://localhost:5001/api/Data/bouquets-by-categories/${id}`)
        .then((response) => {
          console.log(response.data)
          _.map(response.data, (item) => {
            this.products.push(Object.assign({}, item));
          });
          console.log(this.products);
        });
    },
  },
};
</script>
