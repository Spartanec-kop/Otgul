<template lang="pug">
  .filter-set-wrapper
    .actions-wrapper
      .action-type-rapper
        input.action-type(
          type="radio"
          id="all"
          value="all"
          v-model="actionType"
        )
        label(
          for="all"
        ) Все
      .action-type-rapper
        input.action-type(
          type="radio"
          id="added"
          value="added"
          v-model="actionType"
        )
        label(
          for="added"
        ) Добавленные
      .action-type-rapper
        input.action-type(
          type="radio"
          id="dropped"
          value="dropped"
          v-model="actionType"
        )
        label(
          for="dropped"
        ) Списанные
    .filter-date-wrapper
      .checkbox-wrapper
        input.show-date-filter(
          type="checkbox"
          v-model="showDateFilter"
          id="showDateFilter"
        )
        label(
          for="showDateFilter"
        ) За все время
      .date-filter-set(
        v-if="!showDateFilter"
      )
        span с
        input(
          type="date"
          v-model="filterFrom"
        )
        span по
        input(
          type="date"
          v-model="filterTo"
        )
</template>
<script>
export default {
  name: 'FilterSet',
  data () {
    return {
      actionType: 'all',
      showDateFilter: true,
      filterFrom: this.dateNow(),
      filterTo: this.dateNow()
    }
  },
  methods: {
    dateNow () {
      const date = new Date()
      return `${date.getFullYear()}-${date.getMonth() + 1 > 9 ? date.getMonth() + 1 : '0' + (date.getMonth() + 1)}-${date.getDate() > 9 ? date.getDate() : '0' + date.getDate()}`
    }
  }
}
</script>
<style lang="scss">
  span {
    padding: 0 15px;
  }
  input[type='date'] {
    padding-left: 5px;
    color: #000584;
  }
  .filter-set-wrapper {
    display: flex;
    justify-content: space-between;
    width: 100%;
    padding: 20px;
  }
  .actions-wrapper {
    display: flex;
    column-gap: 20px;
    width: 40%;
  }
  .action-type-rapper, .checkbox-wrapper {
    display: flex;
    align-items: center;

    label {
      padding-left: 5px;
      padding-top: 4px;
    }
  }
  .filter-date-wrapper {
    display: flex;
    width: 60%;
    align-items: center;
  }
  .date-filter-set {
    padding-top: 5px;
    padding-left: 20px;
  }
</style>
