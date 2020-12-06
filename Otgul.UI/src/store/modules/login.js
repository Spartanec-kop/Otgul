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
    SET_LOGIN_ERROR: (state, data) => (state.loginError = data.error.message),
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
          localStorage.setItem('token', response.data)
          axios.defaults.headers.Authorization = `Bearer ${response.data}`
          // router.push({ path: 'student' })
          dispatch('navigate', 'student', { root: true })
        })
        .catch(error => {
          console.log(error.response)
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
