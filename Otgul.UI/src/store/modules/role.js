import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    roles: []
  },
  mutations: {
    SET_ROLES: (state, roles) => (state.roles = roles)
  },
  actions: {
    fetchRoles ({ commit }) {
      axios
        .get('/api/Role')
        .then(response => {
          commit('SET_ROLES', response.data)
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
