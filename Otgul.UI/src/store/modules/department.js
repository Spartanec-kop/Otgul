import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    departments: []
  },
  mutations: {
    SET_DEPARTMENTS: (state, departments) => (state.departments = departments)
  },
  actions: {
    fetchDepartments ({ commit }) {
      axios
        .get('/api/Department')
        .then(response => {
          commit('SET_DEPARTMENTS', response.data)
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
