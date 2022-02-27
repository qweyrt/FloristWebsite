<template>
  <div>
    <title-bar :title-stack="titleStack" />
    <hero-bar>
      Carts
      <router-link
        slot="right"
        to="/carts/new"
        class="button"
      >
        Create New
      </router-link>
    </hero-bar>
    <section class="section is-main-section">
      <card-component
        class="has-table has-mobile-sort-spaced"
        title="Carts"
        icon="account-multiple"
      >
        <carts-table-data checkable />
      </card-component>
    </section>
  </div>
</template>

<script>
import CartsTableData from '@/views/Carts/CartsTableData.vue'
import CardComponent from '@/components/CardComponent.vue'
import TitleBar from '@/components/TitleBar.vue'
import HeroBar from '@/components/HeroBar.vue'

export default {
  name: 'Tables',
  components: {
    HeroBar,
    TitleBar,
    CardComponent,
    CartsTableData
  },
  data () {
    return {
      titleStack: ['Admin', 'Tables', 'Carts']
    }
  }
}
</script>
