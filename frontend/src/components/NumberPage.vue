<script setup lang="ts">

const props = defineProps<{
  number: number,
  currentPage: number
}>()

const emit = defineEmits<{ (event: 'update', numberOfPage: number): void }>()
const changePage = () => {
  emit('update', props.number)
}

</script>

<template>

  <span @click="changePage" :class="[
    'p-3 pl-5 pr-5 rounded hover:bg-stone-400 cursor-pointer',
    number == currentPage ? 'bg-stone-600' : 'bg-stone-500' ]">{{ number
    }}</span>

</template>