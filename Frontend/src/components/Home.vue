<template>
  <div>
    <p class="bg-red-500">HOME!</p>
    <div>
      <apexchart width="500" type="bar" :options="options" :series="series"></apexchart>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

defineProps({
})

// Define your chart options
const options = ref({
  chart: {
    id: 'vuechart-example'
  },
  xaxis: {
    categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997]  // Example categories
  }
})

// Define the series data
const series = ref([{
  name: 'series-1',
  data: [30, 40, 35, 50, 49, 60, 70]  // Example data
}])

</script>

<style scoped>
</style>
