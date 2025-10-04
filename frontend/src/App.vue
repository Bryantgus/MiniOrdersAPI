<script setup lang="ts">
import OrdersView from './components/OrdersView.vue'
import FormOrder from './components/FormOrder.vue';
</script>

<template>

  <div class="flex flex-col items-center w-[50%] mx-auto mt-20 gap-10">
    <div class="flex items-center justify-center gap-3">
      <h1 class="font-bold text-[35px]">Mini Orders App</h1>
      <img class="w-10 h-10" src="../public/orderlogo.png" alt="logo">
    </div>
    
    <OrdersView/>
    <FormOrder/>

  </div>

</template>

