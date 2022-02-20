import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    // Document title tag
    // We combine it with defaultDocumentTitle set in `src/main.js` on router.afterEach hook
    meta: {
      title: 'Dashboard'
    },
    path: '/home',
    name: 'home',
    component: Home
  },
  {
    meta: {
      title: 'Tables'
    },
    path: '/tables',
    name: 'tables',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "tables" */ '@/views/Tables.vue')
  },
  {
    meta: {
      title: 'Forms'
    },
    path: '/forms',
    name: 'forms',
    component: () => import(/* webpackChunkName: "forms" */ '@/views/Forms.vue')
  },
  {
    meta: {
      title: 'Profile'
    },
    path: '/profile',
    name: 'profile',
    component: () => import(/* webpackChunkName: "profile" */ '@/views/Profile.vue')
  },
  {
    meta: {
      title: 'New Client'
    },
    path: '/client/new',
    name: 'client.new',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/ClientForm.vue')
  },
  {
    meta: {
      title: 'Edit Client'
    },
    path: '/client/:id',
    name: 'client.edit',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/ClientForm.vue'),
    props: true
  },
  {
    path: '/full-page',
    component: () => import(/* webpackChunkName: "full-page" */ '@/views/FullPage.vue'),
    children: [
      {
        meta: {
          title: 'Login'
        },
        path: '/login',
        name: 'login',
        component: () => import(/* webpackChunkName: "full-page" */ '@/views/full-page/Login.vue')
      }
    ]
  },
  {
    meta: {
      title: 'Bouquets'
    },
    path: '/bouquets',
    name: 'bouquets',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Bouquets/BouquetsTable.vue'),
    props: true
  },
  {
    meta: {
      title: 'New Bouquet'
    },
    path: '/bouquets/new',
    name: 'bouquets.new',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Bouquets/BouquetsForm.vue')
  },
  {
    meta: {
      title: 'Edit Bouquet'
    },
    path: '/bouquets/:id',
    name: 'bouquets.edit',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Bouquets/BouquetsForm.vue'),
    props: true
  },

  {
    meta: {
      title: 'Bouquet Messages'
    },
    path: '/bouquet-messages',
    name: 'bouquetMessages',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/BouquetMessages/BouquetMessagesTable.vue'),
    props: true
  },
  {
    meta: {
      title: 'New Bouquet Messages'
    },
    path: '/bouquetMessages/new',
    name: 'bouquetMessages.new',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/BouquetMessages/BouquetMessagesForm.vue')
  },
  {
    meta: {
      title: 'Edit Bouquet Messages'
    },
    path: '/bouquetMessages/:id',
    name: 'bouquetMessages.edit',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/BouquetMessages/BouquetMessagesForm.vue'),
    props: true
  },
  {
    meta: {
      title: 'Customers'
    },
    path: '/customers',
    name: 'customers',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Customers/CustomersTable.vue'),
    props: true
  },
  {
    meta: {
      title: 'New Customer'
    },
    path: '/customers/new',
    name: 'customers.new',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Customers/CustomersForm.vue')
  },
  {
    meta: {
      title: 'Edit Customer'
    },
    path: '/customers/:id',
    name: 'customers.edit',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Customers/CustomersForm.vue'),
    props: true
  },

  {
    meta: {
      title: 'Recipients'
    },
    path: '/recipients',
    name: 'recipients',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Recipients/RecipientsTable.vue'),
    props: true
  },
  {
    meta: {
      title: 'New Recipient'
    },
    path: '/recipients/new',
    name: 'recipients.new',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Recipients/RecipientsForm.vue')
  },
  {
    meta: {
      title: 'Edit Recipient'
    },
    path: '/recipients/:id',
    name: 'recipients.edit',
    component: () => import(/* webpackChunkName: "client-form" */ '@/views/Recipients/RecipientsForm.vue'),
    props: true
  },

]

const router = new VueRouter({
  routes,
  scrollBehavior (to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { x: 0, y: 0 }
    }
  }
})

export default router

export function useRouter () {
  return router
}
