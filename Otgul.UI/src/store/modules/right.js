import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    rights: []
  },
  mutations: {
    SET_RIGHTS: (state, rights) => (state.rights = rights)
  },
  actions: {
    fetchRights ({ commit }) {
      axios
        .get('/api/Right')
        .then(response => {
          commit('SET_RIGHTS', response.data)
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
