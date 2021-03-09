<template lang="pug">
  .expanded-body это тело развернутого объекта {{row ? row.id : 'undefined'}}
</template>
<script>
export default {
  name: 'RowExpanded',
  props: {
    row: Object
  }
}
</script>
<style lang="scss">

</style>
