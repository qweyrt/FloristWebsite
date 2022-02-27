/* Styles */
import '@/scss/main.scss'

/* Core */
import Vue from 'vue'
import Buefy from 'buefy'

/* Router & Store */
import router from './router'
import store from './store'
import FileSelector from 'vue-file-selector';
import LoadScript from "vue-plugin-load-script"

/* Vue. Main component */
import App from './App.vue'

/* Fetch sample data */
store.dispatch('fetch', 'clients')
store.dispatch('fetchBouquets', 'bouquets')
store.dispatch('fetchBouquetMessages', 'bouquetMessages')
store.dispatch('fetchRecipients', 'recipients')
store.dispatch('fetchCustomers', 'customers')
store.dispatch('fetchCategories', 'categories')
store.dispatch('fetchCarts', 'carts')

/* Default title tag */
const defaultDocumentTitle = 'Admin One Bulma Buefy'

/* Collapse mobile aside menu on route change & set document title from route meta */
router.afterEach(to => {
  store.commit('asideMobileStateToggle', false)

  if (to.meta && to.meta.title) {
    document.title = `${to.meta.title} — ${defaultDocumentTitle}`
  } else {
    document.title = defaultDocumentTitle
  }
})

Vue.config.productionTip = false

Vue.use(Buefy)
Vue.use(FileSelector)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
