<script setup lang="ts">
import type { OrderInfoType } from '@/types/types'
import { onMounted, ref } from 'vue'

const nombre = ref('')
const total = ref('')

const emit = defineEmits<{ (event: 'update', payload: {value: boolean, apiResponse: string}): void }>()

const postOrder = async () => {
  try {
    const response = await fetch('http://localhost:5068/api/Orders', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        nombre: nombre.value,
        total: Number(total.value),
      })
    })

    if (!response.ok) {
      emit('update', {value: true, apiResponse: "Orden agregada correctamente"})
      throw new Error('Error al crear la orden')
    }
    const data = await response.json()
    nombre.value = ''
    total.value = ''
    emit('update', {value: true, apiResponse: "Orden agregada correctamente"})

  } catch (error) {
    console.error(error)
  }
}

</script>

<template>
  <section class="flex flex-col items-center justify-center bg-stone-500 rounded-xl p-6 gap-3 shadow shadow-stone-400">
    <h2 class="text-[30px] font-semibold">Crear nueva Orden</h2>
    <form @submit.prevent="postOrder" class="flex flex-col gap-2">
      <div class="flex flex-col gap-1">
        <span class="text-[18px] font-semibold">Nombre</span>
        <input v-model="nombre" class="focus:outline focus:outline-stone-300 p-1 bg-stone-400 rounded-xl"
          placeholder="Ingresar nombre" type="text">
      </div>
      <div class="flex flex-col gap-1">
        <span class="text-[18px] font-semibold">Total</span>
        <input v-model="total" class="focus:outline focus:outline-stone-300 p-1 bg-stone-400 rounded-xl"
          placeholder="Ingresar el Total" type="text">
      </div>
      <button type="submit"
        class="cursor-pointer bg-stone-700 mt-10 mb-5 text-white p-2 rounded hover:bg-stone-600">Agregar Orden</button>
    </form>
  </section>
</template>
