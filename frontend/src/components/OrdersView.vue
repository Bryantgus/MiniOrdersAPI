<script setup lang="ts">
import OrderInfo from './OrderInfo.vue';
</script>

<template>
  <table class="min-w-full border border-gray-300 rounded-lg text-center">
    <thead class="bg-stone-500">
      <tr>
        <th class="py-2 border-b">Id</th>
        <th class="py-2 border-b">Nombre</th>
        <th class="py-2 border-b">Fecha</th>
        <th class="py-2 border-b">Total</th>
      </tr>
    </thead>
    <tbody>
      <OrderInfo/>
    </tbody>
  </table>
</template>