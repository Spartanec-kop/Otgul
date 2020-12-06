<template lang="pug">
.pagination-wrapper
  .pagination-left-arround(
    @click="navigate('left')"
  )
    svg.pagination-left-arround-svg(
      )
        use(
          v-bind="{'xlink:href' : require('../../public/img/sprite.svg')+'#arround'}"
        )
  .pafination-current-page {{pageNumber}}
  .pagination-text из
  .pagination-count-page {{pageCount}}
  .pagination-right-arroun(
    @click="navigate('right')"
  )
    svg.pagination-right-arround-svg(
      )
        use(
          v-bind="{'xlink:href' : require('../../public/img/sprite.svg')+'#arround'}"
        )
</template>
<script>
export default {
  name: 'Paginator',
  props: {
    pageNumber: Number,
    pageCount: Number
  },
  methods: {
    navigate (direction) {
      switch (direction) {
        case 'left':
          if (this.pageNumber > 1) {
            this.$emit('navigate', this.pageNumber - 1)
          }
          break
        case 'right':
          if (this.pageNumber < this.pageCount) {
            this.$emit('navigate', this.pageNumber + 1)
          }
          break
      }
    }
  }
}
</script>
<style lang="scss" scoped>
.pagination-wrapper {
  display: flex;
  align-items: center;
  padding-top:20px;
}
.pagination-left-arround-svg {
  fill: #40689C;
  transform: rotate(-90deg);
  height: 8px;
  width: 13px;
  margin-right: 14px;
  cursor: pointer;
}

.pagination-right-arround-svg {
  fill: #40689C;
  height: 8px;
  width: 13px;
  transform: rotate(90deg);
  margin-left: 14px;
  cursor: pointer;
}

.pafination-current-page {
  height: 20px;
  width: 20px;
  background: #F1F1F1;

  font-family: Roboto;
  font-style: normal;
  font-weight: bold;
  font-size: 14px;
  line-height: 16px;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #40689C;

  border: double 3px transparent;
  border-radius: 5px;
  background-image: linear-gradient(#F1F1F1, #F1F1F1), radial-gradient(circle at top left, #7e9dc3, #b9cbe4);
  background-origin: border-box;
  background-clip: content-box, border-box;

  margin-right: 3px;
}

.pagination-text {
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 16px;
  display: flex;
  align-items: center;
  color: #777777;
  margin-right: 3px;
}

.pagination-count-page {
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 16px;
  display: flex;
  align-items: center;

  color: #777777;
}
</style>
