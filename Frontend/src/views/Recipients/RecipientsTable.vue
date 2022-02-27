<template>
  <div>
    <title-bar :title-stack="titleStack" />
    <hero-bar>
      Recipients
      <router-link
        slot="right"
        to="/recipients/new"
        class="button"
      >
        Create New
      </router-link>
    </hero-bar>
    <section class="section is-main-section">
      <card-component
        class="has-table has-mobile-sort-spaced"
        title="Recipients"
        icon="account-multiple"
      >
        <recipients-table-data checkable />
      </card-component>
    </section>
  </div>
</template>

<script>
import RecipientsTableData from '@/views/Recipients/RecipientsTableData.vue'
import CardComponent from '@/components/CardComponent.vue'
import TitleBar from '@/components/TitleBar.vue'
import HeroBar from '@/components/HeroBar.vue'

export default {
  name: 'Tables',
  components: {
    HeroBar,
    TitleBar,
    CardComponent,
    RecipientsTableData
  },
  data () {
    return {
      titleStack: ['Admin', 'Tables', 'Recipients']
    }
  }
}
</script>
