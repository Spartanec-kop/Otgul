import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    otdels: []
  },
  mutations: {
    SET_OTDELS: (state, otdels) => (state.otdels = otdels)
  },
  actions: {
    fetchOtdels ({ commit }) {
      axios
        .get('/api/Otdel')
        .then(response => {
          commit('SET_OTDELS', response.data)
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
