<template>
  <div>
    <title-bar :title-stack="titleStack" />
    <hero-bar>
      Bouquets
      <router-link
        slot="right"
        to="/client/new"
        class="button"
      >
        Create New
      </router-link>
    </hero-bar>
    <section class="section is-main-section">
      <card-component
        class="has-table has-mobile-sort-spaced"
        title="Bouquets"
        icon="account-multiple"
      >
        <bouquets-table-data checkable />
      </card-component>
    </section>
  </div>
</template>

<script>
import BouquetsTableData from '@/views/Bouquets/BouquetsTableData.vue'
import CardComponent from '@/components/CardComponent.vue'
import TitleBar from '@/components/TitleBar.vue'
import HeroBar from '@/components/HeroBar.vue'

export default {
  name: 'Tables',
  components: {
    HeroBar,
    TitleBar,
    CardComponent,
    BouquetsTableData
  },
  data () {
    return {
      titleStack: ['Admin', 'Tables', 'Bouquets']
    }
  }
}
</script>
