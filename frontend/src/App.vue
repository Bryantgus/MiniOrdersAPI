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

  <div class="flex flex-col items-center w-[50%] mx-auto mt-20 gap-10">
    <div class="flex items-center justify-center gap-3">
      <h1 class="font-bold text-[35px]">Mini Orders App</h1>
      <img class="w-10 h-10" src="../public/orderlogo.png" alt="logo">
    </div>

    <OrdersView @update="changeView = $event" v-if="changeView.value" />

    <FormOrder @update="changeView = $event" v-else />


  </div>

</template>
