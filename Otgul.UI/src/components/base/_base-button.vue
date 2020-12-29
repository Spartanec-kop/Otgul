<template lang="pug">
.button-wrapper
  .button(
    :class="disabled ? type == 'blue' ? 'button__disabled__blue' : 'button__disabled__red' : type == 'blue' ? 'button__blue' : 'button__red' "
  )
    span.button-label {{label}}
</template>
<script>
export default {
  name: 'BaseButton',
  props: {
    label: String,
    type: String,
    disabled: Boolean
  }
}
</script>
<style lang="scss" scouped>
.button{
  width: 118px;
  height: 40px;
  display: flex;
  justify-content: center;
  cursor: pointer;
  border-radius: 10px;
}
.button__blue {
  background: linear-gradient(259.67deg, #8293B8 -17.82%, #34508E 89.34%);
  box-shadow: 0px 4px 14px rgba(105, 136, 206, 0.62);

  &:hover{
    background: linear-gradient(259.67deg, #487AE8 -17.82%, #1E4499 89.34%);
    box-shadow: 0px 4px 14px rgba(105, 136, 206, 0.62);
  }

  &:active {
    background: linear-gradient(90deg, #4B7CBB 16.91%, #699EE7 81.72%);background: linear-gradient(91.26deg, #C1CADC -30.45%, #6A89CD 104.28%);
    box-shadow: 0px 4px 14px rgba(105, 136, 206, 0.62), inset 0px 4px 9px rgba(0, 0, 0, 0.25);
  }
}

.button__red {
  background: linear-gradient(259.67deg, #F9883C -17.82%, #EF7541 89.34%);
  box-shadow: 0px 4px 14px rgba(255, 160, 132, 0.4);

  &:hover{
    background: linear-gradient(260.82deg, #FF916F -14.16%, #FF2E00 100.91%);
    box-shadow: 0px 4px 14px rgba(255, 160, 132, 0.9);
  }

  &:active {
    background: linear-gradient(259.67deg, #FFA37B -17.82%, #FFAF52 89.34%);
    box-shadow: 0px 4px 14px rgba(255, 160, 132, 0.4), inset 0px 4px 10px rgba(135, 57, 0, 0.25);
  }
}

.button-label {
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 13px;
  line-height: 15px;
  display: flex;
  align-items: center;
  text-align: center;

  color: #FFFFFF;
}
.button__disabled__blue {
  background: linear-gradient(262.96deg, #C7D3EE -57.15%, #97A3BF 83.72%);
  cursor: default;
}
.button__disabled__red {
  background: linear-gradient(259.67deg, #FDDDC8 -17.82%, #F2C2AE 89.34%);
  cursor: default;
}
</style>
