import Vue from 'vue'
import VueRouter from 'vue-router'
import store from './../store/index'

Vue.use(VueRouter)

const routes = [
  {
    path: '/login',
    name: 'Login',
    component: () => import(/* webpackChunkName: 'login' */ '../views/Login.vue')
  },
  {
    path: '/otgul',
    name: 'otgul',
    component: () => import(/* webpackChunkName: 'otgul' */ '../views/Otgul.vue')
  },
  {
    path: '/employees',
    name: 'employees',
    component: () => import(/* webpackChunkName: 'employees' */ '../views/Employees.vue')
  },
  {
    path: '/settings/users',
    name: 'users',
    component: () => import(/* webpackChunkName: 'users' */ '../views/Users.vue')
  },
  {
    path: '/settings/journals',
    name: 'journals',
    component: () => import(/* webpackChunkName: 'journals' */ '../views/Journals.vue')
  }
]

const router = new VueRouter({
  routes
})

async function isAuthentificated () {
  let result = false
  if (localStorage.getItem('token')) {
    await store.dispatch('login/setUser')
    if (Object.keys(store.getters['login/user']).length > 0) {
      result = true
    } else {
      result = false
    }
  } else {
    result = false
  }
  return result
}

router.beforeEach((to, from, next) => {
  if (to.path !== '/login') {
    isAuthentificated().then(result => {
      if (!result) {
        next('/login')
      } else {
        if (to.path === '/') {
          next('/otgul')
        } else {
          next()
        }
      }
    })
  } else {
    isAuthentificated()
      .then(result => {
        if (result) {
          next('/otgul')
        } else {
          next()
        }
      })
      .catch(e => {
        console.log(e)
      })
  }
})

export default router
