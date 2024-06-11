<template>
  <div class="w-1/2 mt-12">
    <div class="border flex flex-row justify-between items-center py-3 shadow-lg rounded-lg mb-4 bg-white">
      <p class="w-1/4 flex items-center justify-center text-gray-600 font-bold">SYMBOL</p>
      <p class="w-1/4 flex items-center justify-center text-gray-600 font-bold">PRICE</p>
      <p class="w-1/4 flex items-center justify-center text-gray-600 font-bold">MARKETCAP</p>
    </div>
    <RouterLink v-for="coin in coins" :key="coin.symbol" :to="'/coin/' + coin.symbol" class="border flex flex-row justify-between items-center py-3 shadow-lg rounded-lg mb-4 bg-white">
      <p class="w-1/4 flex items-center justify-center text-gray-600">{{ coin.symbol }}</p>
      <p class="w-1/4 flex items-center justify-center text-gray-600">{{ coin.price }}</p>
      <p class="w-1/4 flex items-center justify-center text-gray-600">{{ coin.marketCap }}</p>
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
  