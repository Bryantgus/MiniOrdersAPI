<script setup lang="ts">
import OrderInfo from './OrderInfo.vue';
import type { OrderInfoType } from './../types/types'
import { computed, onMounted, ref } from 'vue';
import NumberPage from './NumberPage.vue';


const guid = ref('')
const orders = ref<OrderInfoType[]>([]);
const fetchData = async () => {
  try {
    const response = await fetch("http://localhost:5068/api/Orders")
    if (!response.ok) throw new Error('Error en la solicitud')
    const allOrders: OrderInfoType[] = await response.json()

    
    orders.value = allOrders.map((value: OrderInfoType, index: number) => {
      guid.value = value.guid
      return {
        guid: (index += 1).toString(),
        nombre: value.nombre,
        fecha: value.fecha.toString().slice(0, 10),
        total: value.total
      }
    })
  } catch (error) {
    console.error(error)
  }
}
const emit = defineEmits<{
  (event: 'update', payload: { value: boolean, apiResponse: string }): void;
  (event: 'accion', payload: { accion: string, guid: string }): void
}>()

const changeView = () => {
  emit('update', { value: false, apiResponse: '' })
}

const ordersPerPage = 3
const currentPage = ref(1)
const totalPages = computed(() => {
  return Math.ceil(orders.value.length / ordersPerPage);
});

const orderPerPages = computed(() => {
  const start = (currentPage.value - 1) * ordersPerPage;
  const end = start + ordersPerPage;
  return orders.value.slice(start, end);
});

const changePage = (page: number) => {
  if (page >= 1 && page <= totalPages.value) {
    currentPage.value = page;
  }
}

const changePageOnce = (value: number) => {
  if (value == -1 && currentPage.value == 1) return
  if (value == 1 && totalPages.value == currentPage.value) return
  currentPage.value = currentPage.value + value
}

const seleccionarAccion = (payload: { accion: 'ver' | 'editar' | 'eliminar', guid: string }) => {
  emit('accion', {
    accion: payload.accion,
    guid: guid.value    
  })
}

onMounted(fetchData)

</script>

<template>

  <div class="w-full flex justify-between items-center">
    <h2 class="text-[25px] font-semibold">Listado de Ordenes</h2>
    <button @click="changeView"
      class="bg-stone-500 rounded-xl p-3 font-bold cursor-pointer hover:bg-stone-400 border">Agregar
      Orden</button>
  </div>
  <span v-if="orders.length === 0">No tienes ninguna orden agregada</span>
  <table v-if="orders.length > 0" class="min-w-full border border-gray-300 rounded-lg text-center">
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
      <OrderInfo v-for="order in orderPerPages" :key="order.guid" :order="order" @update="seleccionarAccion" />
    </tbody>
  </table>

  <div class="flex gap-1">
    <button class="p-3 bg-stone-500 hover:bg-stone-400 rounded cursor-pointer" @click="changePageOnce(-1)"><</button>
        <NumberPage v-for="n in totalPages" :key="n" :number="n" :current-page="currentPage" @update="changePage" />
        <button class="p-3 bg-stone-500 hover:bg-stone-400 rounded cursor-pointer" @click="changePageOnce(1)">></button>
  </div>
</template>