export default {
  namespaced: true,
  state: {
    mainMenuItems: {
      otgul: {
        title: 'Отгулы',
        enabled: false,
        name: 'otgul'
      },
      employees: {
        title: 'Сотрудники',
        enabled: false,
        name: 'employees'
      },
      settings: {
        title: 'Настройки',
        name: 'settings',
        enabled: false,
        items: {
          users: {
            name: 'users',
            enabled: false,
            title: 'Управление пользователями'
          },
          journals: {
            name: 'journals',
            enabled: false,
            title: 'Управление журналированием'
          }
        }
      }
    }
  },
  mutations: {
  },
  actions: {
  },
  getters: {
  }
}
