<script setup lang="ts">
import OrderInfo from './OrderInfo.vue';
import type { OrderInfoType } from './../types/types'
import { onMounted, ref } from 'vue';

const orders = ref<OrderInfoType[]>([]);
const fetchData = async () => {
  try {
    const response = await fetch("http://localhost:5068/api/Orders")
    if (!response.ok) throw new Error('Error en la solicitud')
    const allOrders : OrderInfoType[] = await response.json()
    orders.value = allOrders;
  } catch (error) {
    console.error(error)
  }
}
onMounted(fetchData)

</script>

<template>

  <div class="w-full flex justify-between items-center">
    <h2 class="text-[25px] font-semibold">Listado de Ordenes</h2>
    <button class="bg-stone-500 rounded-xl p-3 font-bold cursor-pointer hover:bg-stone-400 border">Agregar
      Orden</button>
  </div>

  <table class="min-w-full border border-gray-300 rounded-lg text-center">
    <thead class="bg-stone-500">
      <tr>
        <th class="py-2 border-b">Id</th>
        <th class="py-2 border-b">Nombre</th>
        <th class="py-2 border-b">Fecha</th>
        <th class="py-2 border-b">Total</th>
        <th class="py-2 border-b">Acciones</th>
      </tr>
    </thead>
    <tbody>
      <OrderInfo v-for="order in orders" :key="order.guid" :order="order" />
    </tbody>
  </table>
</template>