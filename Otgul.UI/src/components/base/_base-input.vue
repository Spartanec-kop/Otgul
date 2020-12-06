<template lang="pug">
.base-input-wrapper
  input.base-input(
    type="text"
    @input="$emit('input', $event.target.value)"
  )
</template>
<script>
export default {
  name: 'BaseInput',
  props: {
    value: String
  }
}
</script>
<style lang="scss" scoped>
.base-input-wrapper {
  width: 100%;
  display: flex;
}

.base-input {
  width: 100%;
  border: double 1px transparent;
  border-radius: 15px;
  background-image: linear-gradient(white, white), radial-gradient(circle at top left, #7e9dc3, #b9cbe4);
  background-origin: border-box;
  background-clip: content-box, border-box;
  box-shadow: 0px 8px 8px rgba(0, 75, 130, 0.14);

  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 20px;
  line-height: 23px;
  color: #40689C;
  text-indent: 20px;
}
</style>
