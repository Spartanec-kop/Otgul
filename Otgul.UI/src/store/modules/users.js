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
    SET_FAIL_LOGIN: (state, loginIsFail) => (state.loginIsFail = loginIsFail),
    REMOVE_USER: (state, user) => {
      const userId = state.users.findIndex(f => f.id === user.id)
      state.users.splice(userId, 1)
    },
    UPDATE_USER: (state, user) => {
      const userId = state.users.findIndex(f => f.id === user.id)
      state.users[userId] = user
      state.users = JSON.parse(JSON.stringify(state.users))
    }
  },
  actions: {
    fetchUsers ({ commit }) {
      axios
        .get('/api/User/all')
        .then(response => {
          const users = response.data.map(user => {
            user.roleName = user.role.name
            return user
          })
          commit('SET_USERS', users)
        })
        .catch(error => {
          if (error.response) {
            console.log(error.response)
          } else {
            console.log(error)
          }
        })
    },
    createUser ({ commit, dispatch }, user) {
      // TODO вспомнить что за "workStatus", сделать заполнение.
      user.workStatus = 'workStatus1'
      axios
        .post('/api/User', user)
        .then(response => {
          commit('ADD_USER', response.data)
          dispatch('modal/closeModal', null, { root: true })
        })
    },
    updateUser ({ commit, dispatch }, user) {
      user.workStatus = 'workStatus1'
      axios
        .put('/api/User', user)
        .then(response => {
          commit('UPDATE_USER', response.data)
          dispatch('modal/closeModal', null, { root: true })
        })
    },
    removeUser ({ commit, dispatch }, user) {
      axios
        .delete(`/api/user?id=${user.id}`)
        .then(response => {
          commit('REMOVE_USER', user)
          dispatch('modal/closeModal', null, { root: true })
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
