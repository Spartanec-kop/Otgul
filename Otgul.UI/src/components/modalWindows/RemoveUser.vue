<template lang="pug">
.remove-user-wrapper
  .body-wrapper
    .remove-user-title Вы действительно хотите удалить пользователя "{{`${user.lastName} ${user.firstName} ${user.middleName}`}}"?
  .battons
    .button-logout(
      @click="removeUser(user)"
    )
      BaseButton(
        type="blue"
        label="Удалить"
      )
    .button-cancel(
      @click="closeModal()"
    )
      BaseButton(
        type="red"
        label="Отмена"
      )

</template>
<script>
import { mapActions, mapState } from 'vuex'
export default {
  name: 'removeUser',
  data () {
    return {
    }
  },
  computed: {
    ...mapState('role', {
      roles: state => state.roles
    }),
    ...mapState('modal', {
      user: state => state.modalContent
    })
  },
  methods: {
    ...mapActions('users', ['removeUser']),
    ...mapActions('modal', ['closeModal'])
  }
}
</script>
<style lang="scss" scoped>
select {
  width: 100%;
}
.icon {
  text-align: center;
  padding-top: 55px;
}
.body-wrapper {
  margin: 0 auto;
}
.remove-user-title {
  padding: 20px 0px;
  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 23px;
  line-height: 18px;
  color: black;
}
.battons {
  display: flex;
  justify-content: space-around;
}
.user-input-title {
  padding-top: 5px;
  padding-bottom: 5px;
}
.remove-user-body {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  row-gap: 10px;
  column-gap: 25px;
}
.remove-user-wrapper {
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
.group-select {
  width: 100%;
}
</style>
