<template lang="pug">
.filters-wrapper(
  v-click-outside="closeFilter"
)
  svg.filters-svg(
    @click="opened = !opened"
    :class="{opened: opened}"
  )
    use(
      v-bind="{'xlink:href' : require('../../../public/img/sprite.svg') + '#filters'}"
    )
  div(
    v-show="opened"
    :class="[{ filters__left: position == 'left' }, {filters__right: position =='right'}]"
  )
    .filters
      .sorting-a-z(
        :class="{'current-sorting': sorting.name === this.name && sorting.direction === 'asc'}"
        @click="setInnerSort('asc')"
      )
        .sorting-a-z-icon
          svg.sorting-a-z-icon-svg
            use(
              v-bind="{'xlink:href' : require('../../../public/img/sprite.svg') + '#sort_a-z'}"
            )
        .sorting-a-z-title Сортировка по возрастанию
      .sorting-z-a(
        :class="{'current-sorting': sorting.name === this.name && sorting.direction === 'desc'}"
        @click="setInnerSort('desc')"
      )
        .sorting-z-a-icon
          svg.sorting-z-a-icon-svg
            use(
              v-bind="{'xlink:href' : require('../../../public/img/sprite.svg') + '#sort_z-a'}"
            )
        .sorting-z-a-title Сортировка по убыванию
      hr
      .search-input
        input.search-input-input(
          type="text"
          v-model="filterToFilters"
        )
        .search-input-button
          svg.search-input-button-svg
            use(
              v-bind="{'xlink:href' : require('../../../public/img/sprite.svg') + '#find'}"
            )

      ul.filters-items
        li.filters-item.show-all
          BaseCheckbox(
            v-model="showAll"
            @change="checkShowAll($event)"
          )
          .show-all-title показать все
        li.filters-item(
          v-for="(item, id) in filteredFilters"
        )
          BaseCheckbox(
            :checked="checkRow(checkedFilter, item)"
            @change="checkFilter($event, item)"
          )
          .filters-item-title {{item}}
</template>
<script>
export default {
  name: 'FilteredTableFilters',
  props: {
    position: String,
    name: String,
    items: Array,
    sorting: Object
  },
  data () {
    return {
      opened: false,
      checkedFilter: [],
      filterToFilters: ''
    }
  },
  computed: {
    filteredFilters () {
      return this.items ? this.items.filter(item => {
        return !this.filterToFilters || item.toLowerCase().indexOf(this.filterToFilters.toLowerCase()) + 1 || this.checkedFilter.indexOf(item) + 1
      }).sort((a, b) => {
        if (this.checkedFilter.indexOf(a) + 1 && this.checkedFilter.indexOf(b) + 1) {
          if (a > b) {
            return 1
          } else {
            return -1
          }
        }
        if (this.checkedFilter.indexOf(a) + 1 && !this.checkedFilter.indexOf(b) + 1) {
          return -1
        }
        if (!this.checkedFilter.indexOf(a) + 1 && this.checkedFilter.indexOf(b) + 1) {
          return 1
        }
        if (!this.checkedFilter.indexOf(a) + 1 && !this.checkedFilter.indexOf(b) + 1) {
          if (a > b) {
            return 1
          } else {
            return -1
          }
        }
      }) : []
    },
    showAll: {
      get () {
        return this.checkedFilter.length === 0
      },
      set (value) {
        if (value) {
          this.checkedFilter = []
          for (const ref in this.$refs) {
            this.$refs[ref][0].checked = false
          }
        }
      }
    }
  },
  methods: {
    checkFilter (value, filter) {
      if (value) {
        this.checkedFilter.push(filter)
      } else {
        const index = this.checkedFilter.indexOf(filter)
        this.checkedFilter.splice(index, 1)
      }
      if (this.checkedFilter.length === 0) {
        this.showAll = true
      } else {
        this.showAll = false
      }
      this.$emit('setFilter', { name: this.name, checkedFilter: this.checkedFilter })
    },
    checkRow (checkedFilter, item) {
      return checkedFilter.indexOf(item) + 1 > 0
    },
    checkShowAll (value) {
      if (value) {
        this.showAll = true
        this.checkedFilter = []
        this.$emit('setFilter', { name: this.name, checkedFilter: this.checkedFilter })
      }
    },
    setInnerSort (direction) {
      this.$emit('setSorting', { name: this.name, direction })
    },
    closeFilter () {
      if (this.opened) {
        this.opened = false
      }
    }
  }
}
</script>
<style lang="scss" scoped>
.filters-svg {
  width: 15px;
  height: 18px;
}
.filters-wrapper {
  position: absolute;
  top: 0px;
  right: 19px;
  cursor: pointer;
  max-height: 400px;

  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 13px;
  line-height: 15px;

  color: #666666;
}
.filters__left {
  position: absolute;
  left: -150px;
  width: 230px;
  background: linear-gradient(359.08deg, #FFFFFF -106.15%, #F3F3F3 1055.53%);
  box-shadow: 0px 15px 33px rgba(72, 72, 72, 0.28);
  border-radius: 13px;
  padding: 16px;
  z-index: 10;
  cursor: default;
}
.filters__right {
  position: absolute;
  right: 0px;
  width: 230px;
  background: linear-gradient(359.08deg, #FFFFFF -106.15%, #F3F3F3 1055.53%);
  box-shadow: 0px 15px 33px rgba(72, 72, 72, 0.28);
  border-radius: 13px;
  padding: 16px;
  z-index: 10;
  cursor: default;
}
.opened {
  fill: #FF843F;
}
.sorting-a-z-icon-svg, .sorting-z-a-icon-svg {
  width: 17px;
  height: 18px;
  padding-right: 10px;
}
.sorting-a-z, .sorting-z-a {
  display: flex;
  cursor: pointer;
  padding: 7px 0;
}
.search-input {
  position: relative;
  height: 24px;
  margin-top: 17px;
}
.search-input-input {
  position: absolute;
  left: 0px;
  height: 100%;
  width: 89%;
  background: #FFFFFF;
  border: 1px solid #CDCDCD;
  box-sizing: border-box;
  border-radius: 4px 0px 0px 4px;
  border-right: 0px;
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 16px;

  color: #AAAAAA;
  }
.search-input-button {
  position: absolute;
  right: 0px;
  width: 27px;
  height: 100%;
  background: linear-gradient(140.53deg, #F4672D 9.14%, #FA8F3F 74.33%);
  box-shadow: 0px 4px 7px rgba(255, 160, 132, 0.52);
  border-radius: 4px;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
}
.search-input-button-svg {
  width: 13px;
  height: 14px;
}
.filters-item {
  display: flex;
  align-items: center;
  padding-top: 10px;
}
.show-all-title, .filters-item-title {
  padding-left: 16px;
}
.current-sorting {
  background: #ffede0;
  border-radius: 10px;
}
</style>
