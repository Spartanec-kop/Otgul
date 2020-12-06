<template lang="pug">
.button-wrapper
  div(
    :class="{'button__blue': type == 'blue', 'button__red': type == 'red'}"
  )
    span.button-label {{label}}
</template>
<script>
export default {
  name: 'BaseButton',
  props: {
    label: String,
    type: String
  }
}
</script>
<style lang="scss" scoped>
.button-wrapper {
  cursor: pointer;
}
.button__blue {
  background: linear-gradient(90deg, #40689C 16.91%, #6183B1 81.72%);
  box-shadow: 0px 7px 35px -1px rgba(43, 109, 194, 0.42);
  border-radius: 18px;
  border: 2px solid transparent;

  width: 160px;
  height: 50px;
  display: flex;
  justify-content: center;

  &:hover{
    background: linear-gradient(90deg, #40689C 16.91%, #699FE7 81.72%);
    border: 2px solid #AACFFF;
    box-shadow: 0px 7px 35px -1px rgba(44, 112, 201, 0.42);
    border-radius: 18px;
  }

  &:active {
    background: linear-gradient(90deg, #4B7CBB 16.91%, #699EE7 81.72%);
  }
}

.button__red {
  background: linear-gradient(90deg, #FF5A5A 16.91%, #FF9A9A 107.14%);
  box-shadow: 0px 4px 20px rgba(237, 18, 18, 0.33);
  border-radius: 18px;
  border: 2px solid transparent;

  width: 160px;
  height: 50px;
  display: flex;
  justify-content: center;

  &:hover{
    background: linear-gradient(90deg, #FF5A5A 16.91%, #FFB1A6 107.14%);
    border: 2px solid #FFC4BC;
    box-shadow: 0px 4px 20px rgba(237, 18, 18, 0.33);
    border-radius: 18px;
  }

  &:active {
    background: linear-gradient(90deg, #FE7C7C 16.91%, #FFB0A6 91.42%);
  }
}

.button-label {
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 18px;
  line-height: 21px;
  display: flex;
  align-items: center;
  text-align: center;
  color: #FFFFFF;
}
</style>
