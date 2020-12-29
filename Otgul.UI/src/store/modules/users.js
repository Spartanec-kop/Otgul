import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    users: []
  },
  mutations: {
    SET_USERS: (state, users) => (state.users = users)
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
    }
  },
  getters: {

  }
}
