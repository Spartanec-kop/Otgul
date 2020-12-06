<template lang="pug">
  #app
    ModalWindow(
      v-if="showModal"
    )
    .header(
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
  margin: 0px;
}
ul {
  list-style-type: none;
  padding: 0px;
  margin: 0px;
}
input {
  margin-top: 5px;
  background: #FFFFFF;
  border: 1px solid #C0C0C0;
  box-sizing: border-box;
  border-radius: 4px;
  height: 25px;
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
  color: #969696;
}

</style>
