<template lang="pug">
.create-user-wrapper
  .body-wrapper
    .create-user-title Добавить нового пользователя
    .create-user-body
      .user-input
        .user-input-title
          span Логин*:
        .user-input-input
          input.user-login(
            type="text"
            v-model="login"
          )
      .user-input
        .user-input-title
          span Пароль*:
        .user-input-input
          input.user-login(
            type="password"
            v-model="password"
          )
      .user-input
        .user-input-title
          span Роль*:
        .user-input-select
          select.user-role(
            v-model="role"
            @change="changeRole"
          )
            option(
              v-for="role in roles"
              :value="role"
            ) {{role.name}}
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
          span Телефон:
        .user-input-input
          input.user-phone(
            type="tel"
            pattern="((8|+7)[-s]?)?(?[0-9]{3})?[-s]?[0-9]{3}[-s]?[0-9]{2}[-s]?[0-9]{2}$"
            v-model="phone"
          )
      .user-input
        .user-input-title
          span Отдел*:
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
          span Департамент*:
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
          span Табельный №:
        .user-input-input
          input.user-tabel(
            type="number"
            v-model="tabel"
          )
    hr
    .user-rights
      .user-rights-label Права пользователя
      Rights(
        :rights="rights"
        v-model="userRights"
      )
  .battons
    .button-logout(
      @click="doAction()"
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
import Rights from '../user/Rights'
export default {
  name: 'CreateUser',
  components: { Rights },
  data () {
    return {
      inFirstName: null,
      inLastName: null,
      inMiddleName: null,
      inLogin: null,
      inPassword: null,
      inRole: null,
      inOtdel: null,
      inDepartment: null,
      inPhone: null,
      inTabel: null,
      inUserRights: []
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
    }),
    ...mapState('right', {
      rights: state => state.rights
    }),
    ...mapState('modal', {
      user: state => state.modalContent
    }),
    firstName: {
      get () {
        return this.inFirstName === null && this.user ? this.user.firstName : this.inFirstName
      },
      set (value) {
        this.inFirstName = value
      }
    },
    lastName: {
      get () {
        return this.inLastName === null && this.user ? this.user.lastName : this.inLastName
      },
      set (value) {
        this.inLastName = value
      }
    },
    middleName: {
      get () {
        return this.inMiddleName === null && this.user ? this.user.middleName : this.inMiddleName
      },
      set (value) {
        this.inMiddleName = value
      }
    },
    login: {
      get () {
        return this.inLogin === null && this.user ? this.user.login : this.inLogin
      },
      set (value) {
        this.inLogin = value
      }
    },
    password: {
      get () {
        return this.inPassword === null && this.user ? this.user.password : this.inPassword
      },
      set (value) {
        this.inPassword = value
      }
    },
    role: {
      get () {
        return !this.inRole && this.user ? this.user.role : this.inRole
      },
      set (value) {
        this.inRole = value
      }
    },
    otdel: {
      get () {
        return !this.inOtdel && this.user ? this.user.otdel : this.inOtdel
      },
      set (value) {
        this.inOtdel = value
      }
    },
    department: {
      get () {
        return !this.inDepartment && this.user ? this.user.department : this.inDepartment
      },
      set (value) {
        this.inDepartment = value
      }
    },
    userRights: {
      get () {
        return this.inUserRights.length === 0 && this.user ? this.user.userRights : this.inUserRights
      },
      set (value) {
        this.inUserRights = value
      }
    },
    phone: {
      get () {
        return this.inPhone === null && this.user ? this.user.phone : this.inPhone
      },
      set (value) {
        this.inPhone = value
      }
    },
    tabel: {
      get () {
        return this.inTabel === null && this.user ? this.user.tabel : this.inTabel
      },
      set (value) {
        this.inTabel = Number(value)
      }
    }
  },
  watch: {
    user: {
      handler (newVal, oldVal) {
        this.firstName = newVal.firstName
        this.lastName = newVal.lastName
        this.middleName = newVal.middleName
        this.login = newVal.login
        this.password = newVal.password
        this.role = newVal.role
        this.otdel = newVal.otdel
        this.department = newVal.department
        this.userRights = newVal.userRights
        this.phone = newVal.phone
        this.tabel = newVal.tabel
      },
      deep: true
    }
  },
  methods: {
    ...mapActions('users', ['createUser', 'updateUser']),
    ...mapActions('modal', ['closeModal']),
    ...mapActions('role', ['fetchRoles']),
    ...mapActions('otdel', ['fetchOtdels']),
    ...mapActions('department', ['fetchDepartments']),
    ...mapActions('right', ['fetchRights']),
    changeRole () {
      this.userRights = [...this.role.roleRights]
    },
    doAction () {
      if (!this.user) {
        this.createUser({
          firstName: this.firstName,
          lastName: this.lastName,
          middleName: this.middleName,
          login: this.login,
          password: this.password,
          role: this.role,
          otdel: this.otdel,
          department: this.department,
          userRights: this.userRights,
          phone: this.phone,
          tabel: this.tabel
        })
      } else {
        this.updateUser({
          id: this.user.id,
          firstName: this.firstName,
          lastName: this.lastName,
          middleName: this.middleName,
          login: this.login,
          password: this.password,
          role: this.role,
          otdel: this.otdel,
          department: this.department,
          userRights: this.userRights,
          phone: this.phone,
          tabel: this.tabel
        })
      }
    }
  },
  mounted () {
    this.fetchRoles()
    this.fetchOtdels()
    this.fetchDepartments()
    this.fetchRights()
  }
}
</script>
<style lang="scss" scoped>
select {
  width: 100%;
}
.icon {
  text-align: center;
  padding-top: 55px;
}
.body-wrapper {
  margin: 0 auto;
}
.create-user-title {
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
.create-user-body {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  row-gap: 10px;
  column-gap: 25px;
}
.user-rights {
  padding: 5px 0px;
}
.create-user-wrapper {
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
.user-input-select {
  width: 100%;
}
.group-select {
  width: 100%;
}
</style>
