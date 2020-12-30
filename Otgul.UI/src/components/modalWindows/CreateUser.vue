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
          input.user-login(
            type="text"
            v-model="login"
          )
      .user-input
        .user-input-title
          span Отдел:
        .user-input-select
          select.user-otdel(
            v-model="otdel"
          )
            option(
              v-for="otdel in otdels"
              :value="otdel"
            ) {{otdel.nameOtdela}}
      .user-input
        .user-input-title
          span Департамент:
        .user-input-select
          select.user-department(
            v-model="department"
          )
            option(
              v-for="department in departments"
              :value="department"
            ) {{department.name}}
      .user-input
        .user-input-title
          span Роль:
        .user-input-select
          select.user-role(
            v-model="role"
          )
            option(
              v-for="role in roles"
              :value="role"
            ) {{role.name}}
  .battons
    .button-logout(
      @click="createUser({ firstName, lastName, middleName, login, role, otdel, department})"
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
      role: {},
      otdel: {},
      department: {}
    }
  },
  computed: {
    ...mapState('role', {
      roles: state => state.roles
    }),
    ...mapState('otdel', {
      otdels: state => state.otdels
    }),
    ...mapState('department', {
      departments: state => state.departments
    })
  },
  methods: {
    ...mapActions('users', ['createUser']),
    ...mapActions('modal', ['closeModal']),
    ...mapActions('role', ['fetchRoles']),
    ...mapActions('otdel', ['fetchOtdels']),
    ...mapActions('department', ['fetchDepartments'])
  },
  mounted () {
    this.fetchRoles()
    this.fetchOtdels()
    this.fetchDepartments()
  }
}
</script>
<style lang="scss" scoped>
select {
  width: 95%;
}
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
  padding-top: 5px;
  padding-bottom: 5px;
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
.user-input-select {
  width: 100%;
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
