<template lang="pug">
.filtered-table-wrapper
  table.filtered-table
    thead
      th.select-all
        BaseCheckbox(
          v-model="selectAll"
        )
      th
        .column-header
          .column-header-title Логин
          .column-header-ManageIpTableFilters
            FilteredTableFilters(
              position="left"
              :items="filtersData.login"
              name="login"
              :sorting="sorting"
              @setFilter="setFilter"
              @setSorting="setSorting"
            )
      th
        .column-header
          .column-header-title Фамилия
          .column-header-ManageIpTableFilters
            FilteredTableFilters(
              position="right"
              :items="filtersData.lastName"
              name="lastName"
              :sorting="sorting"
              @setFilter="setFilter"
              @setSorting="setSorting"
            )
      th
        .column-header
          .column-header-title Имя
          .column-header-ManageIpTableFilters
            FilteredTableFilters(
              position="right"
              :items="filtersData.firstName"
              name="firstName"
              :sorting="sorting"
              @setFilter="setFilter"
              @setSorting="setSorting"
            )
      th
        .column-header
          .column-header-title Отчество
          .column-header-ManageIpTableFilters
            FilteredTableFilters(
              position="right"
              :items="filtersData.middleName"
              name="middleName"
              :sorting="sorting"
              @setFilter="setFilter"
              @setSorting="setSorting"
            )
      th
        .column-header
          .column-header-title Роль
          .column-header-ManageIpTableFilters
            FilteredTableFilters(
              position="right"
              :items="filtersData.role"
              name="role"
              :sorting="sorting"
              @setFilter="setFilter"
              @setSorting="setSorting"
            )
      th
        .column-header
          .column-header-title Действия
          .column-header-ManageIpTableFilters
    tbody
      tr(
        v-for="row in filteredSortedData"
        :class="{'selected-row': checkRow(checkedItems, row)}"
        :key="row.id"
        @click="checkItem(row)"
      )
        td.checkbox-cell
          BaseCheckbox(
            :checked="checkRow(checkedItems, row)"
          )
        td {{row.login}}
        td {{row.lastName}}
        td {{row.firstName}}
        td {{row.middleName}}
        td {{row.role.name}}
        td.row-button-set-wrapper
          .row-button-set
            .row-button-edit.row-button-set-item(
              title="Редактировать"
              @click.stop="showModal({ component: 'CreateUser', showClose: false, modalContent: row })"
            )
              svg.row-button-edit-svg(
              )
                  use(
                    v-bind="{'xlink:href' : require('../../../public/img/sprite.svg') + '#edit'}"
                  )
            .row-button-remove.row-button-set-item(
              title="Удалить"
              @click.stop="showModal({ component: 'RemoveUser', showClose: false, modalContent: row })"
            )
              img.array-item-remove-icon(
                src="../../../public/img/icons/remove-item.svg"
              )
</template>
<script>
import { mapActions } from 'vuex'
import FilteredTableFilters from './FilteredTableFilters'
export default {
  name: 'FilteredTable',
  components: { FilteredTableFilters },
  props: {
    tableData: Array
  },
  data () {
    return {
      innerData: [],
      checkedItems: [],
      filters: {
        login: [],
        firstName: [],
        lastName: [],
        middleName: [],
        role: []
      },
      sorting: {
        name: '',
        direction: 'asc'
      }
    }
  },
  watch: {
    tableData: {
      handler () {
        this.innerData = JSON.parse(JSON.stringify(this.tableData))
      },
      deep: true
    }
  },
  computed: {
    filteredSortedData () {
      const newData = this.innerData.filter(item => {
        return (this.filters.login.length === 0 || this.filters.login.indexOf(item.login) + 1) &&
          (this.filters.firstName.length === 0 || this.filters.firstName.indexOf(item.firstName) + 1) &&
          (this.filters.lastName.length === 0 || this.filters.lastName.indexOf(item.lastName) + 1) &&
          (this.filters.middleName.length === 0 || this.filters.middleName.indexOf(item.middleName) + 1) &&
          (this.filters.role.length === 0 || this.filters.role.indexOf(item.role) + 1)
      })
      if (this.sorting.name) {
        newData.sort(function (a, b) {
          var x = a[this.sorting.name].toLowerCase()
          var y = b[this.sorting.name].toLowerCase()
          if (x < y) return -1
          if (x > y) return 1
          return 0
        })
        if (this.sorting.direction === 'desc') {
          newData.reverse()
        }
      }
      return newData
    },
    filtersData () {
      const data = {}
      this.innerData.forEach(item => {
        for (const key in item) {
          if (data[key]) {
            if (data[key].indexOf(item[key]) + 1) {

            } else {
              data[key].push(item[key])
            }
          } else {
            data[key] = []
            data[key].push(item[key])
          }
        }
      })
      return data
    },
    selectAll: {
      get () {
        return this.filteredSortedData && this.filteredSortedData.length === this.checkedItems.length
      },
      set (checked) {
        this.checkAllItems(checked)
      }
    }
  },
  methods: {
    ...mapActions('modal', ['showModal']),
    checkRow (checkedItems, address) {
      return checkedItems.indexOf(address) + 1 > 0
    },
    checkItem (item) {
      const id = this.checkedItems.indexOf(item)
      if (id < 0) {
        this.checkedItems.push(item)
      } else {
        this.checkedItems.splice(id, 1)
      }
    },
    checkAllItems (checked) {
      if (checked) {
        this.checkedItems = [...this.filteredSortedData]
      } else {
        this.checkedItems = []
      }
    },
    setFilter (filter) {
      this.filters[filter.name] = filter.checkedFilter
      this.checkedItems = []
    },
    setSorting (sorting) {
      this.sorting = sorting
    }
  }
}
</script>
<style lang="scss" scoped>
.filtered-table-wrapper {
  width: 100%;
  height: 100%;
  min-height: 400px;
  overflow-y: auto;
}
.select-all {
  padding-left: 7px;
}
thead {
  background: #F2F2F2;
  border-radius: 3px;
}
table {
  border-spacing: 0px;
  width: 100%;
}
td, th {
  border: 0.5px solid #BCBCBC;
}
th {
  height: 36px;
  max-width: 200px;
}
tr {
  height: 30px;
  &:hover {
    background: #FFECD6;
  }
}
td {
  padding: 0px 35px;
}
.checkbox-cell {
  width: 35px;
  padding: 0px 7px;
}
.column-header {
  position: relative;
  display: grid;
  grid-template-columns: 1fr 30px;
  padding: 0px 10px;
}
.selected-row {
  background: #FFECD6;
}
.row-button-set-wrapper {
  width: 80px;
}
.row-button-set {
  display: flex;
  align-items: center;
}
.row-button-set-item {
  cursor: pointer;
  margin: 0px 5px;
}
.row-button-edit-svg {
  width: 23px;
  height: 23px;
  fill: #ff8900;
}
.row-button-remove {
  width: 23px;
  height: 25px;
}
</style>
