<template>
  <div>
    <button @click="fetchRSIs('BTCUSDT', 1, 14)">Fetch RSI</button>
    <div v-if="rsiData">
      RSI Values: <pre>{{ rsiData }}</pre>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import axios from 'axios';

const apiBaseUrl = 'https://localhost:7286/api/Coin';

// Function to call the CalculateRSIs endpoint
async function fetchRSIs(pair, offset, amount) {
  try {
    // const response = await axios.get(`${apiBaseUrl}/CalculateRSIs${pair}/${offset}/${amount}`);
    const response = await axios.get(`${apiBaseUrl}/CalculateRSIs${pair}/${offset}/${amount}`, {
      headers: {
        'Access-Control-Allow-Origin': 'http://localhost:5173' // Add the desired origin here
      }
    });
    console.log('RSI values:', response.data);
  } catch (error) {
    console.error('Error fetching RSI values:', error);
  }
}
</script>

<style scoped>
/* Add your styles here */
</style>
