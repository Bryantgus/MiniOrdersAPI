<script setup lang="ts">
import type { OrderInfoType } from '@/types/types';

const props = defineProps<{
  order: OrderInfoType
}>()
</script>

<template>

  <tr class="hover:bg-neutral-500 bg-stone-400">
    <td class="py-2 px-4 border-b">{{ order.guid }}</td>
    <td class="py-2 px-4 border-b">{{ order.nombre }}</td>
    <td class="py-2 px-4 border-b">{{ order.fecha }}</td>
    <td class="py-2 px-4 border-b">${{ order.total }}</td>
  </tr>
</template>