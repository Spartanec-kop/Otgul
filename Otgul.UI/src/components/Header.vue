<template lang="pug">
.header-wrapper
  ul.header-sections
    li.header-section-item.header-section-student(
      :class="{active: activeContent === 'otgul'}"
      @click="navigate('otgul')"
    ) Отгулы
    li.header-section-item.header-section-group(
      :class="{active: activeContent === 'users'}"
      @click="navigate('users')"
    ) Пользователи
  .logout(
    @click="showModal({ component: 'ModalLogout', showClose: false })"
  )
    img.icon-svg(
        src="../../public/img/icons/logout.svg"
      )
</template>
<script>
import { mapActions, mapState } from 'vuex'
export default {
  name: 'Header',
  computed: {
    ...mapState({
      activeContent: state => state.activeContent
    })
  },
  methods: {
    ...mapActions('login', ['logout']),
    ...mapActions('modal', ['showModal']),
    ...mapActions(['navigate', 'setActiveContent'])
  },
  watch: {
    $route (to, from) {
      this.setActiveContent(to.name)
    }
  }
}
</script>
<style lang="scss" scoped>
.header-wrapper {
  height: 70px;
  max-width: 700px;
  margin: 0 auto;
  display: flex;
  justify-content: space-between;
  align-items: center;

  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 23px;
  line-height: 27px;

  color: #40689C;

  box-shadow: 0px 8px 8px rgba(0, 75, 130, 0.14);
}
.header-sections {
  display: flex;
  align-items: center;
  height: 100%;
}
.header-section-item {
  padding: 0px 20px;
  height: 100%;
  border-bottom: 2px solid transparent;
  cursor: pointer;
  display: flex;
  align-items: center;

  &:hover {
    border-bottom: 2px solid #40689C;
  }
}
.active {
  border-bottom: 2px solid #40689C;
  background: #f7fbff;
}
.icon-svg {
  width: 40px;
  cursor: pointer;
}
.logout {
  margin-right: 20px;
}
</style>
