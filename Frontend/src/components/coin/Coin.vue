<template>
  <div class="flex flex-col items-center justify-center border border-black">
    <h1 class="text-3xl font-bold mb-5">{{ symbol }} - {{ price }} {{ livePriceFormData.convertSymbol }}</h1>

    <div class="w-96">
      <FormKit type="form" :classes="{
      message: 'text-red-500 text-sm',
    }" :submit-attrs="{
      inputClass: 'hidden',
      wrapperClass: 'hidden',
    }">
        <FormKit type="select" name="convertSymbol" id="convertSymbol" validation="required" label="" :options="['USDT', 'EUR', 'RON']"
          :classes="{
      outer: 'mb-5',
      label: 'block mb-1 font-bold text-sm',
      inner: 'w-full border border-gray-400 rounded-md mb-1 overflow-hidden focus-within:border-blue-500',
      input: 'w-full h-10 px-3 border-none text-base text-gray-700 placeholder-gray-400',
      help: 'text-xs text-gray-500',
      message: 'text-red-500 text-sm'
    }" v-model="livePriceFormData.convertSymbol" />
      </FormKit>
    </div>

    <basic-chart :rsiValues="previousPrices" classes="w-[50rem]"></basic-chart>

  </div>
</template>

<script setup>
import { ref, watch, onMounted } from 'vue'
import axios from 'axios'
import { toast } from 'vue3-toastify'
import 'vue3-toastify/dist/index.css'
import BasicChart from '../charts/BasicChart.vue'

// Define the props
const props = defineProps({
  symbol: {
    type: String,
    required: true
  }
})

const livePriceFormData = ref({
  convertSymbol: 'USDT',
})

const previousPricesFormData = ref({
    convertSymbol: 'USDT',
    day: null,
    month: null,
    year: null,
    offset: 30, // Default to 30 days
})

const apiBaseUrl = 'https://localhost:7286/api/Coin'
const price = ref(null)
const previousPrices = ref([])

// Log the props to the console when the component is mounted
onMounted(() => {
  // Get the current date
  const currentDate = new Date()

  // Get the date 30 days ago
  const previousDate = new Date()
  previousDate.setDate(currentDate.getDate() - 30)

  // Set the previousPricesFormData to 30 days ago
  previousPricesFormData.value.day = previousDate.getDate()
  previousPricesFormData.value.month = previousDate.getMonth() + 1 // Months are zero-based
  previousPricesFormData.value.year = previousDate.getFullYear()

  getLivePrice()
  fetchPreviousPrices()
})

async function getLivePrice() {
  try {
    const response = await axios.get(`${apiBaseUrl}/LivePrice/${props.symbol + livePriceFormData.value.convertSymbol}`)
    price.value = response.data;
  } catch (error) {
    handleApiError(error);
  }
}

// Watch the convertSymbol value for changes and call getLivePrice
watch(() => livePriceFormData.value.convertSymbol, () => {
  getLivePrice()
})

async function fetchPreviousPrices() {
  const loadingToastId = toast.loading("Loading previous prices...");

  try {
    const response = await axios.get(`${apiBaseUrl}/PreviousPrices/${props.symbol + previousPricesFormData.value.convertSymbol}/${previousPricesFormData.value.day}/${previousPricesFormData.value.month}/${previousPricesFormData.value.year}/${previousPricesFormData.value.offset}`)
    previousPrices.value = response.data;  
    toast.update(loadingToastId, { type: toast.TYPE.SUCCESS, render: "Previous prices loaded", autoClose: 3000, isLoading: false });
  } catch (error) {
    toast.update(loadingToastId, { type: toast.TYPE.ERROR, render: "Failed to load previous prices", autoClose: 3000, isLoading: false });
    handleApiError(error);
  }
}

function handleApiError(error) {
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
</script>

<style scoped></style>
