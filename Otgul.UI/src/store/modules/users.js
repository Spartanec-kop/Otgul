import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    users: []
  },
  mutations: {
    SET_USERS: (state, users) => (state.users = users),
    ADD_USER: (state, user) => (state.users.push(user))
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
      axios
        .post('/api/User', user)
        .then(response => {
          commit('ADD_USER', response.data)
        })
    }
  },
  getters: {

  }
}
