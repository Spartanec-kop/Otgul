<template lang="pug">
.loguot-wrapper
  .body
    .icon
      img.icon-svg(
        src="../../../public/img/icons/logout.svg"
      )
    .message
      span.message-text Вы действительно хотите выйти?
    .battons
      .button-logout(
        @click="confirmLogout"
      )
        BaseButton(
          type="blue"
          label="Выйти"
        )
      .button-cancel(
        @click="closeModal()"
      )
        BaseButton(
          type="red"
          label="Отмена"
        )

</template>
<script>
import { mapActions } from 'vuex'
export default {
  name: 'ModalLogout',
  methods: {
    ...mapActions('login', ['logout']),
    ...mapActions('modal', ['closeModal']),
    confirmLogout () {
      this.logout()
      this.closeModal()
    }
  }
}
</script>
<style lang="scss" scoped>
.loguot-wrapper{
  width: 529px;
  height: 341px;
}
.icon {
  text-align: center;
  padding-top: 55px;
}
.body {
  width: 365px;
  margin: 0 auto;
}
.message {
  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 23px;
  line-height: 27px;

  color: #40689C;
  padding-top: 37px;
  padding-bottom: 47px;
}
.battons {
  display: flex;
  justify-content: space-between;
}
</style>
