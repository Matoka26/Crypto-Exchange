<template>
  <div>
    <button @click="fetchRSIs('BTCUSDT', 5, 20)">Fetch RSI</button>
    <div v-if="rsiData">
      RSI Values: <pre>{{ rsiData }}</pre>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import axios from 'axios';

const rsiData = ref(null);  // State to store RSI data

const apiBaseUrl = 'https://localhost:7286/api/Coin';

// Function to call the CalculateRSIs endpoint
async function fetchRSIs(pair, offset, amount) {
  try {
    const response = await axios.get(`${apiBaseUrl}/CalculateRSIs/${pair}/${offset}/${amount}`);
    rsiData.value = response.data;  // Set the fetched data to rsiData
    console.log('RSI values:', response.data);
  } catch (error) {
    if (error.response) {
      // The request was made and the server responded with a status code
      console.error('Request failed with status code:', error.response.status);
      console.error('Response data:', error.response.data);
      console.error('Response headers:', error.response.headers);
    } else if (error.request) {
      // The request was made but no response was received
      console.error('No response received:', error.request);
    } else {
      // Something happened in setting up the request that triggered an error
      console.error('Error:', error.message);
    }
  }
}
</script>

<style scoped>
/* Add your styles here */
</style>
