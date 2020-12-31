<template lang="pug">
  .user-roles-selectors
    .user-roles-available
      .user-roles-label Доступные
      select.roles-multiselect.form-control(
        multiple='',
        v-model="selctedUnused"
        )
        option(
          v-for='right in unusedRightList'
          :value='right'
          ) {{right.name}}
    .user-roles-buttons
      button#rightAdd.user-roles-button.button.btn-secondary(
        type='button'
        @click='change(true)'
        :disabled="unusedRightList.length === 0"
        ) »
      button#rightRemove.user-roles-button.button.btn-secondary(
        type='button'
        @click='change(false)'
        :disabled="value.length === 0"
        ) «
    .user-roles-added
      .user-roles-label Добавленные *
      select.roles-multiselect.form-control(
        multiple=''
        v-model="selctedUsed"
        )
        option(
          v-for='right in value'
          :value='right'
          ) {{right.name}}
</template>
<script>
export default {
  name: 'Rights',
  props: {
    value: Array,
    rights: Array
  },
  data () {
    return {
      selctedUnused: [],
      selctedUsed: [],
      unusedRightList: this.rights.filter(f => { return this.value.findIndex(a => a.id === f.id) + 1 === 0 })
    }
  },
  watch: {
    value: {
      handler (newVal, oldVal) {
        this.unusedRightList = this.rights.filter(f => { return this.value.findIndex(a => a.id === f.id) + 1 === 0 })
      },
      deep: true
    },
    rights: {
      handler (newVal, oldVal) {
        this.unusedRightList = this.rights.filter(f => { return this.value.findIndex(a => a.id === f.id) + 1 === 0 })
      },
      deep: true
    }
  },
  methods: {
    change (isAdd) {
      const tmpValue = [...this.value]
      if (isAdd) {
        this.selctedUnused.forEach(right => {
          tmpValue.push(right)
        })
        this.$emit('input', tmpValue)
      } else {
        this.selctedUsed.forEach(right => {
          const index = tmpValue.findIndex(f => f.id === right.id)
          tmpValue.splice(index, 1)
        })

        this.$emit('input', tmpValue)
      }
    }
  }
}
</script>
<style lang="scss" scoped>
.user-roles-selectors {
  display: grid;
  grid-template-columns: 3fr 1fr 3fr;
  grid-column-gap: 10px;
  align-items: center;
}
.user-roles-label{
  font-style: normal;
  // font-weight: bold;
  color: black;
  padding: 10px 0;
}
.roles-multiselect{
  min-width: 200px;
  width: 100%;
}
.user-roles-buttons{
  align-self: center;
}
.user-roles-button{
  margin: 10px 0px;
  width: 100%;
  height: 20px;
}
select.form-control[multiple]{
  height: max-content;
  max-height: 200px;
}
</style>
