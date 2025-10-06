<script setup lang="ts">
import OrdersView from './components/OrdersView.vue'
import FormOrder from './components/FormOrder.vue'
import Acciones from './components/Acciones.vue';
import { ref, watch } from 'vue';

const ordersKey = ref(0)

const changeView = ref({
  apiResponse: '',
  value: true
})

const accionAndGuid = ref({
  accion: '',
  guid: 0
})
const accion = (payload: any) => {  
  accionAndGuid.value = payload
}

const cerrarAcciones = (apiResponse: string) => {
  accionAndGuid.value.accion = ''
  accionAndGuid.value.guid = 0
  ordersKey.value += 1

  //Cambiando mensaje de api Response
  changeView.value.apiResponse = apiResponse      
}

// watch(accionAndGuid, (newVal, oldVal) => {
//   console.log('showAcciones cambió:', newVal)
// }, { deep: true })

</script>

<template>

  <Acciones v-if="accionAndGuid.accion !== ''" :accion="accionAndGuid.accion" :guid="accionAndGuid.guid" @close="cerrarAcciones"/>

  <div class="flex flex-col items-center w-[50%] mx-auto mt-10 gap-10">
    <div class="flex items-center justify-center gap-3">
      <h1 class="font-bold text-[35px]">Mini Orders App</h1>
      <img class="w-10 h-10" src="../public/orderlogo.png" alt="logo">
    </div>

    <span v-if="changeView.apiResponse !== ''" :class="[
      'absolute top-[10%] left-[80%] px-4 py-2 rounded-lg shadow-lg z-10',
      changeView.apiResponse[0] === 'O' ? 'bg-green-500 text-white' :
        changeView.apiResponse[0] === 'E' ? 'bg-red-500 text-white' :
          'bg-gray-500 text-white'
    ]">
      {{ changeView.apiResponse }}</span>

    <OrdersView :key="ordersKey" @update="changeView = $event" @accion="accion" v-if="changeView.value" />

    <FormOrder @update="changeView = $event" v-else/>

  </div>

</template>
