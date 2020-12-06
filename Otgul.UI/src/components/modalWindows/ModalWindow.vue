<template lang="pug">
  transition(name="modal")
    .modal-mask
      .modal-wrapper(
        @click.once="closeModal()"
      )
        .modal-container(
          @click.stop=""
        )
          .modal-body
            .closeButton(
              v-if="showCloseButton"
              @click="closeModal()"
            )
              img.closeButton-svg(
                :src="require(`../../../public/img/icons/closeButton.svg`)"
              )
            component(
              :is="bodyComponent"
            )
            //- ModalLogout
          //- .modal-footer
</template>
<script>
import { mapState, mapActions } from 'vuex'
import ModalLogout from './ModalLogout'
import StudentCreate from './StudentCreate'
export default {
  name: 'ModalWindow',
  components: {
    ModalLogout,
    StudentCreate
  },
  computed: {
    ...mapState('modal', {
      bodyComponent: state => state.bodyComponent,
      showCloseButton: state => state.showCloseButton
    })
  },
  methods: {
    ...mapActions('modal', ['closeModal'])
  }
}
</script>
<style lang="scss" scoped>
.modal-footer{
  text-align: right;
}

/* modal */
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}
.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}
.modal-container {
  width: max-content;
  margin: 0px auto;

  background: linear-gradient(207.51deg, #E6E6E6 -1.14%, #FFFFFF 72.85%);
  box-shadow: 1px -2px 22px rgba(0, 62, 97, 0.24);
  border-radius: 17px;

  transition: all 0.3s ease;
}

.modal-header h3 {
  font-size: 14px;
  margin: 0;
  color: #555;
  display: inline-block;
}

.modal-body {
  position: relative;
}

.closeButton {
  position: absolute;
  top: 0px;
  right: 0px;
  cursor: pointer;
  padding: 20px;
}
.closeButton-svg {
  width: 19px;
  height: 19px;
}

.modal-enter {
  opacity: 0;
}

.modal-leave-active {
  opacity: 0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
.modal-footer {
    border-top: 1px solid #e5e5e5;
    padding: 8px 10px;
}
.modal-header {
  padding-top: 20px;
  padding: 10px 8px;
}
</style>
