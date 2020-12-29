<template lang="pug">
.craate-user-wrapper
  .body-wrapper
    .craate-user-title Добавить нового пользователя
    .craate-user-body
      .user-input
        .user-input-title
          span Фамилия:
        .user-input-input
          input.user-name(
            type="text"
            v-model="lastName"
          )
      .user-input
        .user-input-title
          span Имя:
        .user-input-input
          input.user-last-name(
            type="text"
            v-model="firstName"
          )
      .user-input
        .user-input-title
          span Отчество:
        .user-input-input
          input.user-middle-name(
            type="text"
            v-model="middleName"
          )
      .user-input
        .user-input-title
          span Логин:
        .user-input-input
          input.user-nick-name(
            type="text"
            v-model="login"
          )
      .user-input
        .user-input-title
          span Роль:
        .user-input-input
          input.user-role(
            type="text"
            v-model="role"
          )
  .battons
    .button-logout(
      @click="createUser({ name, lastName, middleName, nickName, sex})"
    )
      BaseButton(
        type="blue"
        label="Сохранить"
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
import { mapActions, mapState } from 'vuex'
export default {
  name: 'CreateUser',
  data () {
    return {
      firstName: '',
      lastName: '',
      middleName: '',
      login: '',
      role: ''
    }
  },
  computed: {
    ...mapState('group', {
      groups: state => state.groups
    })
  },
  methods: {
    ...mapActions('users', ['createUser']),
    ...mapActions('modal', ['closeModal'])
  }
}
</script>
<style lang="scss" scoped>
.craate-user-wrapper{
  width: 529px;
  height: 341px;
}
.icon {
  text-align: center;
  padding-top: 55px;
}
.body-wrapper {
  width: 365px;
  margin: 0 auto;
}
.craate-user-title {
  padding: 20px 0px;
  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 23px;
  line-height: 18px;
  color: black;
}
.battons {
  display: flex;
  justify-content: space-around;
}
.user-input-title {
  padding-top: 10px;
}
.craate-user-body {
  display: grid;
  grid-template-columns: 1fr 1fr;
  row-gap: 10px;
  column-gap: 25px;
}
.craate-user-wrapper {
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
.user-input-input-sex {
  display: flex;
  align-items: center;
  justify-content: space-around;
}
input[type="radio"] {
  height: 20px;
}
.sex-radio {
  display: flex;
  align-items: center;
}
.group-select {
  width: 100%;
}
</style>
