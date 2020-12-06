import Vue from 'vue'
import Vuex from 'vuex'
import router from '../router/index'
import login from './modules/login'
import modal from './modules/modal'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    activeContent: ''
  },
  mutations: {
    SET_ACTIVE_CONTENT: (state, content) => (state.activeContent = content)
  },
  actions: {
    navigate ({ dispatch }, content) {
      dispatch('modal/closeModal')
      router.push({ path: content })
    },
    setActiveContent ({ commit }, content) {
      commit('SET_ACTIVE_CONTENT', content)
    }
  },
  modules: {
    login,
    modal
  }
})
