<template lang="pug">
.login-wrapper
  .login-body
    .title
      span Пожалуйста, авторизуйтесь
    .form-wrapper
      form.form-login(
        @submit.prevent="submit"
      )
        .form-input.login
          .login.form-label
            span Логин
          .login.form-input-login
            BaseInputValidate.form-input-input(
              v-model="login"
              firstClass=""
              :isInvalid="validation.hasError('login')"
              :toolTipText="validation.firstError('login')"
            )
        .form-input.password
          .password.form-label
            span Пароль
          .password.form-input-password
            BaseInputValidate.form-input-input(
              v-model="password"
              firstClass=""
              type="password"
              :isInvalid="validation.hasError('password')"
              :toolTipText="validation.firstError('password')"
            )
        .error-message  {{loginError}}
        button.button-wrapper#sendLoginForm(
          :class="disableButton() ? 'buttonDisabled' : '' "
          :disabled="disableButton()"
        )
          span.Submit-title(
            ) {{isLoading ? '' : 'Войти'}}
            .spin-wrapper(
              v-if="isLoading"
            )
              svg(
                class="spinner"
                viewBox="0 0 50 50"
                )
                circle(
                  class="path"
                  cx="25"
                  cy="25"
                  r="20"
                  fill="none"
                  stroke-width="5"
                  )
</template>
<script>
import SimpleVueValidator from 'simple-vue-validator'
import { mapActions, mapState } from 'vuex'

const Validator = SimpleVueValidator.Validator
export default {
  mixins: [SimpleVueValidator.mixin],
  name: 'login',
  data () {
    return {
      login: '',
      password: '',
      saveMe: false
    }
  },
  computed: {
    ...mapState('login', {
      loginError: state => state.loginError,
      isLoading: state => state.isLoading
    })
  },
  validators: {
    login: function (value) {
      return Validator.value(value).required('Поле не должно быть пустым')
    },
    password: function (value) {
      return Validator.value(value).required('Поле не должно быть пустым')
    }
  },
  methods: {
    ...mapActions('login', ['logIn']),
    disableButton () {
      return (
        (this.validation.hasError('password') ||
        this.validation.hasError('login')) || this.validation.passedRecords.length < 2
      )
    },
    submit () {
      this.$validate().then(async success => {
        if (success) {
          this.logIn({ login: this.login, password: this.password })
        }
      })
    }
  }
}
</script>
<style lang="scss" scoped>
.login-wrapper{
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
}
.login-background {
  position: absolute;
  top: 0px;
  left: 0px;
  width: 100vw;
  height: 100vh;
  z-index: -2;
}
.login-body {
  height: max-content;
  width: 50vh;
  min-width: 450px;
  max-height: 650px;
  background: linear-gradient(180deg, #40689C 0%, rgba(255, 255, 255, 0) 368.66%);
  filter: drop-shadow(-3px 6px 25px rgba(0, 48, 140, 0.18));
  border-radius: 16px;
  text-align: center;
  padding: 40px;
}
.error-message{
  margin-top: 20px;
  color: red;
  height: 30px;
  font-weight: 600;
}
.button-wrapper {
  width: 204px;
  height: 61px;
  background: linear-gradient(180deg, #FFFFFF 0%, #FFFFFF 368.66%);
  box-shadow: -3px 6px 25px rgba(0, 48, 140, 0.18);
  border-radius: 16px;
  cursor: pointer;

  margin: 10px 30px 30px 30px;

  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 22px;
  line-height: 26px;
  color: #436A9D;
}
.form-label {
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 16px;
  line-height: 19px;
  color: #FFFFFF;
}
.form-input-input {
  width: 100%;
  height: 38px;

}
.title {
  font-family: Roboto;
  font-style: normal;
  font-weight: 300;
  font-size: 28px;
  line-height: 33px;
  text-align: center;
  color: #FFFFFF;

  margin-top: 3vh;
}
.image-title {
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 13px;
  line-height: 15px;
  text-align: center;
  color: #FFFFFF;
}
.login-img {
  margin-top: 2vh;
}
.form-input {
  margin-top: 35px;
  text-align: left;
}
.form-wrapper {
  width: 80%;
  margin: 0 auto;
}
.buttonDisabled {
  opacity: 0.5;
  cursor: default;
}
// spinner
.spin-wrapper{
  position: relative;
}
.spinner {
  animation: rotate 2s linear infinite;
  z-index: 2;
  position: absolute;
  top: 50%;
  left: 50%;
  margin: -25px 0 0 -25px;
  width: 50px;
  height: 50px;

  & .path {
    stroke: #2c3e50;
    stroke-linecap: round;
    animation: dash 1.5s ease-in-out infinite;
  }
}

@keyframes rotate {
  100% {
    transform: rotate(360deg);
  }
}

@keyframes dash {
  0% {
    stroke-dasharray: 1, 150;
    stroke-dashoffset: 0;
  }
  50% {
    stroke-dasharray: 90, 150;
    stroke-dashoffset: -35;
  }
  100% {
    stroke-dasharray: 90, 150;
    stroke-dashoffset: -124;
  }
}
</style>
