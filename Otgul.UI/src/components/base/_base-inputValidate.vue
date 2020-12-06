<template lang="pug">
 .input.tooltip(
    :class="[firstClass, {'input__error':isInvalid}]")
    input.valid-input(
      :value="value"
      @input="$emit('input', $event.target.value)"
      )
    .input-tooltip(:class="{'showed':isInvalid}") {{toolTipText}}
</template>
<script>
export default {
  name: 'BaseInputValidate',
  props: ['value', 'firstClass', 'isInvalid', 'toolTipText']
}
</script>
<style lang="scss" scoped>
.valid-input {
  width: 100%;
  height: 100%;
  box-shadow: 0px 8px 8px rgba(0, 75, 130, 0.14);
  border-radius: 15px;
  font-size: 24px;
}
/* Tooltip container */
.tooltip {
    position: relative;
    display: inline-block;
    visibility: visible;
}
.input-tooltip{
  visibility: hidden;
}

/* Tooltip text */
.tooltip .input-tooltip {
    width: 80%;
    background-color: red;
    color: #fff;
    text-align: center;
    padding: 5px 0;
    border-radius: 6px;
    position: absolute;
}

/* Show the tooltip text when you mouse over the tooltip container */
 .showed {
    visibility: visible;
}

.tooltip .input-tooltip::after {
    content: " ";
    position: absolute;
    bottom: 100%;
    left: 50%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: transparent transparent red transparent;
}
/* end tooltip */
</style>
