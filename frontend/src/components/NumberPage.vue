<script setup lang="ts">

const props = defineProps<{
  number: number
}>()

const emit = defineEmits<{ (event: 'update', numberOfPage: number): void }>()
const changePage = () => {
  emit('update', props.number)
}

</script>

<template>

<span @click="changePage" class="p-3 pl-5 pr-5 rounded bg-stone-500 hover:bg-stone-400 cursor-pointer">{{ number }}</span>

</template>