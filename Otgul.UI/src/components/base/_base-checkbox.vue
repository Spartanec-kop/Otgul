<template lang="pug">
.checkbox-wrapper(
  @click="$emit('change', !checked)"
)
  svg.checkbox-icon(
    v-show="checked"
  )
    use(
      v-bind="{'xlink:href' : require('../../../public/img/sprite.svg') + '#check'}"
    )
</template>
<script>
export default {
  name: 'BaseCheckbox',
  model: {
    prop: 'checked',
    event: 'change'
  },
  props: {
    checked: Boolean
  }

}
</script>
<style lang="scss" scoped>
.checkbox-wrapper {
  height: 18px;
  width: 18px;
  background: #FFFFFF;
  border: 1px solid #BCBCBC;
  box-sizing: border-box;
  border-radius: 3px;
  cursor: pointer;
  text-align: center;
}
.checkbox-icon {
  height: 9px;
  width: 12px;
}
</style>
