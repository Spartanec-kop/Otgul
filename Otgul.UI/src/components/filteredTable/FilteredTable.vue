<template lang="pug">
.filtered-table-wrapper
  table.filtered-table
    thead
      th.select-all
        BaseCheckbox(
          v-model="selectAll"
        )
      th(
      v-for="column in columns"
      )
        .column-header(
          v-if="column.field"
        )
          .column-header-title {{column.name}}
          .column-header-ManageIpTableFilters(
            v-if="column.filtered"
          )
            FilteredTableFilters(
              position="left"
              :items="filtersData[column.field]"
              :name="column.field"
              :sorting="sorting"
              @setFilter="setFilter"
              @setSorting="setSorting"
            )
        .column-header(
          v-if="column.type === 'action'"
        )
          .column-header-title {{column.name}}
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
        td(
          v-for="column in columns"
          v-if="column.field"
        ) {{row[column.field]}}
        td.row-button-set-wrapper(
          v-for="column in columns"
          v-if="column.type === 'action'"
        )
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
    tableData: Array,
    columns: Array
  },
  data () {
    return {
      innerData: [],
      checkedItems: [],
      filters: {},
      sorting: {
        name: '',
        direction: 'asc'
      },
      filteredSortedData: {}
    }
  },
  watch: {
    tableData: {
      handler (newVal, oldVal) {
        this.innerData = JSON.parse(JSON.stringify(this.tableData))
        this.setFilteredSortedData()
      },
      deep: true
    },
    filters: {
      handler (newVal, oldVal) {
        this.setFilteredSortedData()
      },
      deep: true
    },
    sorting: {
      handler (newVal, oldVal) {
        this.setFilteredSortedData()
      },
      deep: true
    }
  },
  computed: {
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
    setFilteredSortedData () {
      const newData = this.innerData.filter(item => {
        let result = true
        for (const subItem in this.filters) {
          if (!(this.filters[subItem].length === 0 || this.filters[subItem].indexOf(item[subItem]) + 1)) result = false
        }
        return result
      })
      if (this.sorting.name) {
        newData.sort((a, b) => {
          const x = a[this.sorting.name].toLowerCase()
          const y = b[this.sorting.name].toLowerCase()
          if (x < y) return -1
          if (x > y) return 1
          return 0
        })
        if (this.sorting.direction === 'desc') {
          newData.reverse()
        }
      }
      this.filteredSortedData = newData
    },
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
      this.filters = { ...this.filters }
      this.checkedItems = []
    },
    setSorting (sorting) {
      this.sorting = sorting
    }
  },
  created () {
    this.columns.forEach(column => {
      if (column.field) this.filters[column.field] = []
    })
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
