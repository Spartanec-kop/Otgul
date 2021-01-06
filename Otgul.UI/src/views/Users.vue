<template lang="pug">
  .users-wrapper
    .button-set
    .add-item(
      @click.stop="showModal({ component: 'CreateUser', showClose: false })"
    )
      img.plus(
        src="../../public/img/icons/plus.svg"
      )
      .add-item-title Добавить пользователя
    .users-list
      FilteredTable(
        :tableData="users"
      )
    .user-data-wrapper
</template>
<script>
import { mapState, mapActions } from 'vuex'
import FilteredTable from '../components/filteredTable/FilteredTable'
export default {
  name: 'Users',
  components: {
    FilteredTable
  },
  computed: {
    ...mapState('users', {
      users: state => state.users
    })
  },
  methods: {
    ...mapActions('users', ['fetchUsers']),
    ...mapActions('modal', ['showModal'])
  },
  mounted () {
    this.fetchUsers()
  }
}
</script>
<style lang="scss" scoped>
.button-set {
  display: flex;
}
</style>
