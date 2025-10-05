<script setup lang="ts">
import OrdersView from './components/OrdersView.vue'
import FormOrder from './components/FormOrder.vue';
import { ref, watch } from 'vue';

const changeView = ref({
  apiResponse: '',
  value: true
})

watch(changeView, (newVal, oldVal) => {
  console.log('changeView cambió:', newVal)
}, { deep: true })

</script>

<template>

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

    <OrdersView @update="changeView = $event" v-if="changeView.value" />

    <FormOrder @update="changeView = $event" v-else />

  </div>

</template>
