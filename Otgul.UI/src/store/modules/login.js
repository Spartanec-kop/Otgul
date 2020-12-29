import axios from '../../requests'
import router from '../../router/index'

export default {
  namespaced: true,
  state: {
    user: '',
    loginError: '',
    isLoading: false
  },
  mutations: {
    SET_USER: (state, data) => (state.user = data),
    SET_LOGIN_ERROR: (state, message) => (state.loginError = message),
    SET_IS_LOADING: (state, isLoading) => (state.isLoading = isLoading)
  },
  actions: {
    async setUser ({ commit }) {
      try {
        const { data } = await axios.get('/api/user')
        commit('SET_USER', data)
      } catch (e) {
        console.log(e)
        commit('SET_USER', {})
      }
    },
    logIn ({ commit, dispatch }, loginData) {
      commit('SET_IS_LOADING', true)
      axios
        .get(`/api/User/auth?login=${loginData.login}&password=${loginData.password}`)
        .then(response => {
          commit('SET_IS_LOADING', false)
          commit('SET_LOGIN_ERROR', '')
          localStorage.setItem('token', response.data)
          axios.defaults.headers.Authorization = `Bearer ${response.data}`
          dispatch('navigate', 'otgul', { root: true })
        })
        .catch(error => {
          if (error.response) {
            console.log(error.response)
            switch (error.response.status) {
              case 404:
                commit('SET_LOGIN_ERROR', 'Логин или пароль введены неверно')
                break
              default:
                commit('SET_LOGIN_ERROR', error.response.statusText)
                break
            }
          } else {
            commit('SET_LOGIN_ERROR', error)
          }
          console.log(error)
          commit('SET_IS_LOADING', false)
        })
    },
    logout ({ commit }) {
      localStorage.removeItem('token')
      router.push({ name: 'Login' })
      commit('SET_USER', '')
    }
  },
  getters: {
    user (state) {
      return state.user
    }
  }
}
