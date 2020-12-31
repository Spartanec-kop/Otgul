import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    users: [],
    loginIsFail: true
  },
  mutations: {
    SET_USERS: (state, users) => (state.users = users),
    ADD_USER: (state, user) => (state.users.push(user)),
    SET_FAIL_LOGIN: (state, loginIsFail) => (state.loginIsFail = loginIsFail)
  },
  actions: {
    fetchUsers ({ commit }) {
      axios
        .get('/api/User/all')
        .then(response => {
          commit('SET_USERS', response.data)
        })
        .catch(error => {
          if (error.response) {
            console.log(error.response)
          } else {
            console.log(error)
          }
        })
    },
    createUser ({ commit }, user) {
      user.rights = user.role.roleRights
      user.workStatus = 'workStatus1'
      axios
        .post('/api/User', user)
        .then(response => {
          commit('ADD_USER', response.data)
        })
    },
    ChechLogin ({ commit }, login) {
      axios
        .get(`/api/User?login=${login}`)
        .then(response => {
          commit('SET_FAIL_LOGIN', response.data)
        })
        .catch(error => {
          if (error.response) {
            console.log(error.response)
          } else {
            console.log(error)
          }
        })
    }
  },
  getters: {

  }
}
