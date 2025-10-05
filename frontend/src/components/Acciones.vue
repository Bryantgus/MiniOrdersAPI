<script setup lang="ts">
import { onMounted, ref } from 'vue';


const dataOrder = ref({
  guid: 0,
  nombre: '',
  fecha: '',
  total: ''
})

const props = defineProps<{
  accion: string,
  guid: number
}>()

const emit = defineEmits<{
  (event: "close", responseAPi: string): void
}>()

const fetchOrder = () => {
  try {
    fetch(`http://localhost:5068/api/Orders/${props.guid}`)
      .then(response => response.json())
      .then(data => {
        dataOrder.value = data
      })
  } catch (error) {
    emit("close", "Error al realizar accion")
  }
}

const editOrDeleteFetch = async (accion: string) => {
  
  if (accion === 'editar') {
    try {

      const response = await fetch(`http://localhost:5068/api/Orders/${props.guid}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          nombre: dataOrder.value.nombre,
          total: Number(dataOrder.value.total)
        })
      })
      if (!response.ok) {
        emit("close", "Error al editar Orden")
        throw new Error('Error al eliminar')
      }
      emit("close", "Order editada correctamente")
    } catch (error) {
      emit("close", "Error al editar Orden")
    }
  } else if (accion === 'eliminar') {
    console.log("Eliminar");
    
    try {
      const response = await fetch(`http://localhost:5068/api/Orders/${props.guid}`, {
        method: 'DELETE'
      })
      
      if (!response.ok) {
        emit("close", "Error al editar Orden")
        throw new Error('Error al eliminar')
      }
      emit("close", "Order editada correctamente")
    } catch (error) {
      emit("close", "Error al editar Orden")
    }
  }
}

const cerrarAcciones = () => {
  emit('close', '')
}

onMounted(fetchOrder)
</script>

<template>

  <div class="fixed inset-0 z-50 flex items-center justify-center bg-black/50">
    <div class="bg-white rounded-2xl shadow-lg p-5 relative max-w-lg w-full flex flex-col items-center justify-center">

      <div v-if="props.accion === 'ver'">
        <h3 class="text-[24px] font-bold mb-5">Vizualizando informacion de la orden</h3>
        <div class="text-[18px] flex flex-col gap-3">
          <div
            class="shadow shadow-stone-300 flex gap-3 bg-stone-200 p-2 rounded-xl cursor-not-allowed hover:bg-stone-300 items-center justify-center">
            <span class="font-semibold">Guid: </span>
            <span>{{ dataOrder.guid }}</span>
          </div>

          <div
            class="shadow shadow-stone-300 flex gap-3 bg-stone-200 p-2 rounded-xl cursor-not-allowed hover:bg-stone-300 items-center justify-center">
            <span>Nombre:</span>
            <span>{{ dataOrder.nombre }}</span>
          </div>

          <div
            class="shadow shadow-stone-300 flex gap-3 bg-stone-200 p-2 rounded-xl cursor-not-allowed hover:bg-stone-300 items-center justify-center">
            <span>Fecha:</span>
            <span>{{ dataOrder.fecha }}</span>
          </div>

          <div
            class="shadow shadow-stone-300 flex gap-3 bg-stone-200 p-2 rounded-xl cursor-not-allowed hover:bg-stone-300 items-center justify-center">
            <span>Total:</span>
            <span>{{ dataOrder.total }}</span>
          </div>

        </div>
      </div>

      <div class="flex flex-col gap-3" v-if="props.accion === 'editar'">
        <h3 class="text-[24px] font-bold">Vizualizando informacion de la orden</h3>

        <form @submit.prevent="editOrDeleteFetch(props.accion)" class="flex flex-col gap-2 ">
          <div
            class="jutify-center shadow shadow-stone-300 flex gap-3 bg-stone-200 p-2 rounded-xl hover:bg-stone-300 items-center justify-center">
            <span class="font-semibold">Nombre: </span>
            <input class="border border-stone-400 rounded-xl p-1 pl-3" type="text" v-model="dataOrder.nombre">
          </div>

          <div
            class="jutify-center shadow shadow-stone-300 flex gap-3 bg-stone-200 p-2 rounded-xl hover:bg-stone-300 items-center justify-center">
            <span class="font-semibold">Total: </span>
            <input class="border border-stone-400 rounded-xl p-1 pl-3" type="text" v-model="dataOrder.total">
          </div>
          <button type="submit"
            class="w-[400px] mt-3 p-3 bg-stone-400 text-white rounded-xl pl-10 pr-10 cursor-pointer hover:bg-stone-500">Agregar
            Orden</button>
        </form>
      </div>

      <div v-if="props.accion === 'eliminar'">
        <h3 class="text-[20px] font-semibold">Desea eliminar orden de {{ dataOrder.nombre }}?</h3>
        <button @click="editOrDeleteFetch(props.accion)"
          class="w-[400px] mt-3 p-3 bg-red-900 font-bold text-white rounded-xl pl-10 pr-10 cursor-pointer hover:bg-stone-500">Eliminar</button>
      </div>
      <button @click="cerrarAcciones"
        class="w-[400px] mt-3 p-3 bg-stone-400 rounded-xl pl-10 pr-10 text-white cursor-pointer hover:bg-stone-500">Cerrar</button>
    </div>
  </div>
</template>``