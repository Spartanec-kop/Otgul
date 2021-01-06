// import axios from '../../requests'
// import router from '../../router/index'

export default {
  namespaced: true,
  state: {
    bodyComponent: '',
    showModal: false,
    showCloseButton: false,
    modalContent: null
  },
  mutations: {
    SHOW_MODAL: (state, body) => {
      state.showModal = true
      state.bodyComponent = body.component
      state.showCloseButton = body.showClose
      state.modalContent = body.modalContent
    },
    CLOSE_MODAL: (state) => {
      state.showModal = false
      state.bodyComponent = ''
    }
  },
  actions: {
    showModal ({ commit }, body) {
      commit('SHOW_MODAL', body)
    },
    closeModal ({ commit }) {
      commit('CLOSE_MODAL')
    }
  },
  getters: {
  }
}
