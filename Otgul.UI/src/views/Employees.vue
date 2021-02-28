<template lang="pug">
  .employees-wrapper
    FilterSet
    EmployeesToggledTable
</template>
<script>
import FilterSet from '../components/employees/FilterSet'
import EmployeesToggledTable from '../components/employees/EmployeesToggledTable'
export default {
  name: 'Employees',
  components: { FilterSet, EmployeesToggledTable }
}
</script>
<style lang="scss" scoped>

</style>
