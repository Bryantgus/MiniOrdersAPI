<script setup lang="ts">
import type { OrderInfoType } from '@/types/types';
import watch from '../assets/watch.svg'
import edit from '../assets/edit.svg'
import trash from '../assets/trash.svg'

const props = defineProps<{
  order: OrderInfoType
}>()

const emit = defineEmits<{
  (event: 'update', payload: { accion: 'ver' | 'editar' | 'eliminar', guid: number }): void
}>()

const acciones = (accionesType: 'ver' | 'editar' | 'eliminar') => {
  emit('update', {accion: accionesType, guid: props.order.guid})
}
</script>

<template>

  <tr class="bg-stone-400">
    <td class="py-2 px-4 border-b">{{ order.guid }}</td>
    <td class="py-2 px-4 border-b">{{ order.nombre }}</td>
    <td class="py-2 px-4 border-b">{{ order.fecha }}</td>
    <td class="py-2 px-4 border-b">${{ order.total }}</td>
    <td class="py-2 px-4 border-b">
      <div class="flex gap-5 items-center justify-center">
        <img @click="acciones('ver')"
          class="w-8 h-8 cursor-pointer bg-stone-500 rounded-full p-2 hover:bg-stone-400 border " :src="watch"
          alt="watch">
        <img @click="acciones('editar')"
          class="w-8 h-8 cursor-pointer bg-stone-500 rounded-full p-2 hover:bg-stone-400 border " :src="edit"
          alt="edit">
        <img @click="acciones('eliminar')"
          class="w-8 h-8 cursor-pointer bg-stone-500 rounded-full p-2 hover:bg-stone-400 border " :src="trash"
          alt="edit">
      </div>
    </td>
  </tr>
</template>