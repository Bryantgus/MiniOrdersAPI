<script setup lang="ts">

const props = defineProps<{
  accion: string,
  guid: number
}>()

const emit = defineEmits<{
  (event: "close"): void
}>()

const cerrarAcciones = () => {
  emit('close')
}
</script>

<template>

  <div class="fixed inset-0 z-50 flex items-center justify-center bg-black/50">
    <div class="bg-white rounded-2xl shadow-lg p-6 relative max-w-lg w-full">

      <span v-if="props.accion === 'ver'">Ver Info</span>
      <span v-if="props.accion === 'editar'">Editar</span>
      <span v-if="props.accion === 'eliminar'">Eliminar</span>
      <button @click="cerrarAcciones">Cerrar</button>
    </div>
  </div>
</template>