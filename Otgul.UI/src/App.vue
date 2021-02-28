<template lang="pug">
  #app
    ModalWindow(
      v-if="showModal"
    )
    header.header(
      v-if="Object.keys(user).length > 0"
    )
      Header
    .body-wrapper
      router-view
</template>
<script>
import ModalWindow from './components/modalWindows/ModalWindow'
import Header from './components/Header'
import { mapState } from 'vuex'
export default {
  components: { Header, ModalWindow },
  data () {
    return {
    }
  },
  computed: {
    ...mapState('login', {
      user: state => state.user
    }),
    ...mapState('modal', {
      showModal: state => state.showModal
    })
  },
  methods: {
  }
}
</script>
<style lang="scss">
/* Fonts */
@font-face {
  font-family:Roboto;
  src:url("../public/fonts/roboto/Roboto.ttf") format("truetype");
}

/* End fonts */
body {
  margin: 0;
}
ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
}
input, select, textarea {
  background: #FFFFFF;
  border: 1px solid #C0C0C0;
  box-sizing: border-box;
  border-radius: 4px;
  height: 25px;
}
.body-wrapper {
  max-width: 1200px;
  margin: 0 auto;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 16px;
  line-height: 14px;
  color: #000584;
}
.add-item {
  display: flex;
  align-items: center;
  margin: 10px 0;
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 14px;
  color: #969696;
  width: max-content;
  cursor: pointer;
}

</style>
