<template lang="pug">
  div
    FilteredTable(
      :tableData="users"
      :columns="columns"
    )
</template>
<script>
import { mapState, mapActions } from 'vuex'
import FilteredTable from '../filteredTable/FilteredTable'
export default {
  name: 'EmployeesToggledTable',
  components: { FilteredTable },
  data () {
    return {
      columns: [
        {
          field: 'login',
          name: 'Логин',
          filtered: true
        },
        {
          field: 'lastName',
          name: 'Фамилия',
          filtered: true
        },
        {
          field: 'firstName',
          name: 'Имя',
          filtered: true
        },
        {
          field: 'middleName',
          name: 'Отчество',
          filtered: true
        },
        {
          field: 'roleName',
          name: 'Роль',
          filtered: true
        },
        {
          name: 'Действия',
          type: 'action'
        }
      ]
    }
  },
  computed: {
    ...mapState('users', {
      users: state => state.users
    })
  },
  methods: {
    ...mapActions('users', ['fetchUsers'])
  },
  mounted () {
    this.fetchUsers()
  }
}
</script>
