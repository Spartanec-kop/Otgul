import Vue from 'vue'
import Vuex from 'vuex'
import router from '../router/index'
import login from './modules/login'
import modal from './modules/modal'
import mainMenu from './modules/mainMenu'
import users from './modules/users'
import role from './modules/role'
import otdel from './modules/otdel'
import department from './modules/department'
import right from './modules/right'

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
      router.push({ name: content })
    },
    setActiveContent ({ commit }, content) {
      commit('SET_ACTIVE_CONTENT', content)
    }
  },
  modules: {
    login,
    modal,
    mainMenu,
    users,
    role,
    otdel,
    department,
    right
  }
})
