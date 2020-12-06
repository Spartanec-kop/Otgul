<template lang="pug">
.craate-student-wrapper
  .body-wrapper
    .craate-student-title Добавить нового студента
    .craate-student-body
      .student-input
        .student-input-title
          span Имя
        .student-input-input
          input.student-name(
            type="text"
            v-model="name"
          )
      .student-input
        .student-input-title
          span Фамилия
        .student-input-input
          input.student-last-name(
            type="text"
            v-model="lastName"
          )
      .student-input
        .student-input-title
          span Отчество
        .student-input-input
          input.student-middle-name(
            type="text"
            v-model="middleName"
          )
      .student-input
        .student-input-title
          span Прозвище
        .student-input-input
          input.student-nick-name(
            type="text"
            v-model="nickName"
          )
      .student-input
        .student-input-title
          span Пол
        .student-input-input-sex
          .sex-radio.radio-man
            input.student-sex-man(
              type="radio"
              id="man"
              :value="true"
              v-model="sex"
            )
            label(
              for="man"
            ) муж.
          .sex-radio.radio-woman
            input.student-sex-woman(
              type="radio"
              id="woman"
              :value="false"
              v-model="sex"
            )
            label(
              for="man"
            ) жен.
      .student-input
        .student-input-title
          span Группы
        .student-input-input
          multiselect(
            v-model="groupsList",
            :options="options",
            :multiple="true",
            :close-on-select="false",
            :clear-on-select="false",
            :preserve-search="true",
            placeholder="Группы"
            label="Группы",
            track-by="name",
            :preselect-first="true"
          )
  .battons
    .button-logout(
      @click="createStudent({ name, lastName, middleName, nickName, sex})"
    )
      BaseButton(
        type="blue"
        label="Сохранить"
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
  name: 'StudentCreate',
  data () {
    return {
      name: '',
      lastName: '',
      middleName: '',
      nickName: '',
      sex: true,
      groupsList: [],
      ohptions: []
    }
  },
  computed: {
    ...mapState('group', {
      groups: state => state.groups
    }),
    options () {
      const options = []
      if (this.groups.rows && this.groups.rows.length > 0) {
        this.groups.rows.forEach(option => {
          options.push({ name: option.name, value: option.id })
        })
      }

      return options
    }
  },
  methods: {
    ...mapActions('student', ['createStudent']),
    ...mapActions('modal', ['closeModal']),
    ...mapActions('group', ['fetchSelectorGroups']),
    changeGroups (event) {
      this.groupsList = event.targer.value
    }
  },
  mounted () {
    this.fetchSelectorGroups()
  }
}
</script>
<style lang="scss" scoped>
.craate-student-wrapper{
  width: 529px;
  height: 341px;
}
.icon {
  text-align: center;
  padding-top: 55px;
}
.body-wrapper {
  width: 365px;
  margin: 0 auto;
}
.craate-student-title {
  padding: 20px 0px;
  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 25px;
  line-height: 18px;
  color: black;
}
.battons {
  display: flex;
  justify-content: space-around;
}
.student-input-title {
  padding-top: 10px;
}
.craate-student-body {
  display: grid;
  grid-template-columns: 1fr 1fr;
  row-gap: 10px;
  column-gap: 25px;
}
.craate-student-wrapper {
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
.student-input-input-sex {
  display: flex;
  align-items: center;
  justify-content: space-around;
}
input[type="radio"] {
  height: 20px;
}
.sex-radio {
  display: flex;
  align-items: center;
}
.group-select {
  width: 100%;
}
</style>
