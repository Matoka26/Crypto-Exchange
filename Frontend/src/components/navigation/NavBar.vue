<template>
    <nav class="bg-white border border-black text-black p-5">
      <div class="max-w-7xl mx-auto px-4">
        <div class="flex justify-between">
          <div class="flex space-x-4">
            <!-- logo -->
            <div>
              <a href="#" class="flex items-center py-5 px-2 text-gray-700 hover:text-gray-900">
                <svg class="h-8 w-8 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11.049 2.927c.3-.921 1.603-.921 1.902 0a20.038 20.038 0 018.381 8.381c.921 1.299.921 2.603 0 3.902a20.04 20.04 0 01-8.381 8.381c-1.299.921-2.603.921-3.902 0a20.04 20.04 0 01-8.381-8.381c-.921-1.299-.921-2.603 0-3.902a20.038 20.038 0 018.381-8.381z"></path><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 13l-3-3-3 3m0-3h12"></path></svg>
                <span class="font-bold">MyApp</span>
              </a>
            </div>
            <!-- primary nav -->
            <div class="hidden md:flex items-center space-x-1">
              <RouterLink to="/" class="py-5 px-3">Go to Home</RouterLink>
              <RouterLink to="/about" class="py-5 px-3">Go to About</RouterLink>
              <RouterLink to="/calculate-rsi" class="py-5 px-3">Calculate RSIs</RouterLink>
              <RouterLink to="/live-price" class="py-5 px-3">Live Price</RouterLink>
            </div>
          </div>
          <!-- secondary nav -->
          <div class="hidden md:flex items-center space-x-1">
            <RouterLink to="/login" class="py-2 px-3">Login</RouterLink>
            <RouterLink to="/register" class="py-2 px-3">Register</RouterLink>
            <RouterLink to="/logout" class="py-2 px-3">Logout</RouterLink>
              <!-- <RouterLink to="/about" class="py-2 px-3">Go to About</RouterLink> -->
          </div>
          <!-- mobile button goes here -->
          <div class="md:hidden flex items-center">
            <button @click="isOpen = !isOpen" class="mobile-menu-button">
              <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16m-7 6h7"></path></svg>
            </button>
          </div>
        </div>
      </div>
      <!-- mobile menu -->
      <div v-show="isOpen" class="mobile-menu md:hidden">
        <a href="#" class="block py-2 px-4 text-sm hover:bg-gray-700">Features</a>
        <a href="#" class="block py-2 px-4 text-sm hover:bg-gray-700">Pricing</a>
        <a href="#" class="block py-2 px-4 text-sm hover:bg-gray-700">Login</a>
        <a href="#" the class="block py-2 px-4 text-sm hover:bg-gray-700">Sign Up</a>
      </div>
    </nav>
  </template>
  
  <script setup>
  import { ref } from 'vue'
  const isOpen = ref(false)
  </script>
  
  <style scoped>
  .mobile-menu-button:focus {
    outline: none;
  }
  </style>
  