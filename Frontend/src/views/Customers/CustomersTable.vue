<template>
  <div>
    <title-bar :title-stack="titleStack" />
    <hero-bar>
      Customers
      <router-link
        slot="right"
        to="/customers/new"
        class="button"
      >
        Create New
      </router-link>
    </hero-bar>
    <section class="section is-main-section">
      <card-component
        class="has-table has-mobile-sort-spaced"
        title="Customers"
        icon="account-multiple"
      >
        <customers-table-data checkable />
      </card-component>
    </section>
  </div>
</template>

<script>
import CustomersTableData from '@/views/Customers/CustomersTableData.vue'
import CardComponent from '@/components/CardComponent.vue'
import TitleBar from '@/components/TitleBar.vue'
import HeroBar from '@/components/HeroBar.vue'

export default {
  name: 'Tables',
  components: {
    HeroBar,
    TitleBar,
    CardComponent,
    CustomersTableData
  },
  data () {
    return {
      titleStack: ['Admin', 'Tables', 'Customers']
    }
  }
}
</script>
