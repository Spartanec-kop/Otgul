<template lang="pug">
.header-wrapper
  .main-menu
    ul.header-sections
      li.header-section-item.header-section-student(
        v-for="item in mainMenuItems"
        :class="{'nav-item__active': activeItem && activeItem.name === item.name}"
        @click="innerNavigate(item)"
      ) {{item.title}}
    .sub-menu(
      v-if="activeSubItem"
    )
      ul.sub-menu-list
        li.sub-menu-item(
          v-for="item in activeItem.items"
          :class="{'sub-menu-item__active': activeSubItem && activeSubItem.name == item.name,'item-disabled' : !item.enabled}"
          @click="innerNavigate(item)"
        )
          a.sub-menu-item__link {{item.title}}
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
  data () {
    return {
    }
  },
  computed: {
    ...mapState({
      activeContent: state => state.activeContent
    }),
    ...mapState('mainMenu', {
      mainMenuItems: state => state.mainMenuItems
    }),
    activeItem () {
      return this.mainMenuItems[this.activeContent.split('/')[1]]
    },
    activeSubItem () {
      const urlSections = this.activeContent.split('/')
      if (urlSections.length > 2) {
        return this.activeItem.items[this.activeContent.split('/')[2]]
      } else {
        return null
      }
    }
  },
  methods: {
    ...mapActions('login', ['logout']),
    ...mapActions('modal', ['showModal']),
    ...mapActions(['navigate', 'setActiveContent']),
    innerNavigate (item) {
      if (!('items' in item)) {
        this.navigate(item.name)
      } else {
        const keys = Object.keys(item.items)
        this.navigate(item.items[keys[0]].name)
      }
    }
  },
  watch: {
    $route (to, from) {
      this.setActiveContent(to.path)
    }
  }
}
</script>
<style lang="scss" scoped>
.header-wrapper {
  height: max-content;
  max-width: 700px;
  margin: 0 auto;
  display: flex;
  justify-content: space-between;

  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 23px;
  line-height: 27px;

  color: #40689C;

  box-shadow: 0px 8px 8px rgba(0, 75, 130, 0.14);
}
.main-menu {
  height: 100%;
}
.header-sections {
  display: flex;
  align-items: center;
  height: 100%;
}
.header-section-item {
  padding: 0px 20px;
  height: 58px;
  border-bottom: 2px solid transparent;
  cursor: pointer;
  display: flex;
  align-items: center;

  &:hover {
    border-bottom: 2px solid #40689C;
  }
}
.icon-svg {
  width: 40px;
  cursor: pointer;
}
.logout {
  margin-right: 20px;
  padding-top: 10px;
}
.sub-menu {
    font-size: 19px;
    padding: 11px 0px;
}
.sub-menu-list {
  display: flex;
  align-items: center;
  margin: 0px;
  margin-left: 60px;
  padding: 0px;
  height: 100%;
}
.sub-menu-item {
  cursor: pointer;
  display: flex;
  align-items: center;
  padding: 0 10px;
  height: 100%;
  border-bottom: 2px solid transparent;
  border-right: 1px solid #e3e8ec;

  &:last-child {
    border-right: none;
  }
  &:first-child {
    padding-left: 0px;
  }
  &:hover {
    border-bottom: 2px solid #d6d8db;
  }
}
.nav-item__active {
  border-bottom: 2px solid #40689C;
  font-weight: 500;
  background: #f7fbff;
}

.sub-menu-item__active {
  font-weight: 500;
  border-bottom: 2px solid #d6d8db;
}
</style>
