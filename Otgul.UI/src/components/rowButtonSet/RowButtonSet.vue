<template lang="pug">
  .row-button-set-wrapper(
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
export default {
  name: 'RowButtonSet',
  props: {
    row: Object
  },
  methods: {
    ...mapActions('modal', ['showModal'])
  }
}
</script>
<style lang="scss">
  .row-button-set-wrapper {
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
