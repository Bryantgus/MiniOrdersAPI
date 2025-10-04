<script setup lang="ts">
import { ref, onMounted } from 'vue'

const message = ref<string | null>(null)
const fetchData = async () => {
  try {
    const response = await fetch("http://localhost:5068/api/Orders")
    if (!response.ok) throw new Error('Error en la solicitud')
    const data = await response.json()
    message.value = data.message 
  } catch (error) {
    console.error(error)
  }
}
onMounted(fetchData)
</script>

<template>
  <h1 class="text-red-300 font-bold">Mi Mini Orders API</h1>
  <p>{{ message }}</p>
</template>

<style scoped></style>
