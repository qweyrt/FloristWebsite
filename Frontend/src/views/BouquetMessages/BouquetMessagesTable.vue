<template>
  <div>
    <title-bar :title-stack="titleStack" />
    <hero-bar>
      Bouquet Messages
      <router-link
        slot="right"
        to="/bouquetMessages/new"
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
        <bouquet-messages-table-data checkable />
      </card-component>
    </section>
  </div>
</template>

<script>
import BouquetMessagesTableData from '@/views/BouquetMessages/BouquetMessagesTableData.vue'
import CardComponent from '@/components/CardComponent.vue'
import TitleBar from '@/components/TitleBar.vue'
import HeroBar from '@/components/HeroBar.vue'

export default {
  name: 'Tables',
  components: {
    HeroBar,
    TitleBar,
    CardComponent,
    BouquetMessagesTableData
  },
  data () {
    return {
      titleStack: ['Admin', 'Tables', 'Bouquet Messages']
    }
  }
}
</script>
