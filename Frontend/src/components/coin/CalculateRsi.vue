<template>
    <div>
      <rsi-form @data-generated="generateChart"></rsi-form>
      <rsi-chart :rsiValues="rsiValues"></rsi-chart>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue'
  import RsiChart from '../charts/RsiChart.vue'
  import RsiForm from '../forms/RsiForm.vue'
  
  const rsiValues = ref([])
  
  const generateChart = (data) => {
    rsiValues.value = data.value
  }
  </script>
  
  <style scoped>
  /* Add your styles here */
  </style>
  