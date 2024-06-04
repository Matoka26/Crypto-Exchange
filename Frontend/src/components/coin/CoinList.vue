<template>
    <div class="w-1/2 mt-12">
      <RouterLink v-for="coin in coins" :key="coin.symbol" :to="'/coin/' + coin.symbol" class="border flex flex-row justify-between items-center py-3 shadow-lg rounded-lg mb-4 bg-white">
        <h1 class="w-1/4 flex items-center justify-center text-lg font-semibold">{{ coin.name }}</h1>
        <p class="w-1/4 flex items-center justify-center text-gray-600">{{ coin.symbol }}</p>
        <p class="w-1/4 flex items-center justify-center text-gray-600">{{ coin.marketCap }}</p>
        <p class="w-1/4 flex items-center justify-center text-gray-600">{{ coin.currentPrice }}</p>
      </RouterLink>
    </div>
  </template>
  
  <script setup>
  import { ref, defineProps } from 'vue'
  
  const props = defineProps({
    coins: {
      type: Array,
      required: true
    }
  })
  </script>
  
  <style scoped>
  /* Additional styles if needed */
  </style>
  