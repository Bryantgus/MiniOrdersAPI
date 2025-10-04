<script setup lang="ts">
import { ref, onMounted } from 'vue'
import OrdersView from './components/OrdersView.vue'

const message = ref<string | null>(null)
// const fetchData = async () => {
//   try {
//     const response = await fetch("http://localhost:5068/api/Orders")
//     if (!response.ok) throw new Error('Error en la solicitud')
//     const data = await response.json()
//     message.value = data.message
//   } catch (error) {
//     console.error(error)
//   }
// }
// onMounted(fetchData)
</script>

<template>
  <div class="flex flex-col items-center w-[50%] mx-auto mt-20 gap-10">
    <div class="flex items-center justify-center gap-3">
      <h1 class="font-bold text-[35px]">Mini Orders App</h1>
      <img class="w-10 h-10" src="../public/orderlogo.png" alt="logo">
    </div>
    <!-- <p>{{ message }}</p> -->
    <div class="w-full flex justify-between items-center">
      <h2 class="text-[25px] font-semibold">Listado de Ordenes</h2>
      <button class="bg-stone-500 rounded-xl p-3 font-bold cursor-pointer hover:bg-stone-400 border">Agregar Orden</button>
    </div>

    <OrdersView />

  </div>

</template>

