<template lang="pug">
  div
    FilteredTable(
      :tableData="users"
      :columns="columns"
      :toggleComponent="toggleComponent"
      :isToggle="true"
    )
</template>
<script>
import { mapState, mapActions } from 'vuex'
import FilteredTable from '../filteredTable/FilteredTable'
import RowButtonSet from '../../components/rowButtonSet/RowButtonSet'
import RowExpanded from '../../components/RowExpanded'
export default {
  name: 'EmployeesToggledTable',
  components: {
    FilteredTable,
    RowButtonSet,
    RowExpanded
  },
  data () {
    return {
      columns: [
        {
          field: 'tabel',
          name: 'Таб. №',
          filtered: true
        },
        {
          field: 'otdelName',
          name: 'Отдел',
          filtered: true
        },
        {
          field: 'departmentName',
          name: 'Департамент',
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
          field: 'workStatus',
          name: 'Статус',
          filtered: true
        },
        {
          name: 'Действия',
          component: RowButtonSet
        }
      ]
    }
  },
  computed: {
    ...mapState('users', {
      users: state => state.users
    }),
    toggleComponent () {
      return RowExpanded
    }
  },
  methods: {
    ...mapActions('users', ['fetchUsers'])
  },
  mounted () {
    this.fetchUsers()
  }
}
</script>
