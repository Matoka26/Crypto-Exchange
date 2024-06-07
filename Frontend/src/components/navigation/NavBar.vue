<template>
    <nav class="bg-white text-black p-5 shadow-lg">
      <div class="max-w-7xl mx-auto px-4">
        <div class="flex justify-between">
          <div class="flex space-x-4">
            <!-- logo -->
            <div>
              <a href="#" class="flex items-center py-5 px-2 text-gray-700 hover:text-gray-900">
                <svg id="visual" viewBox="0 0 900 600" width="90" height="60" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1">
                  <path d="M0 319L4.8 333.3C9.7 347.7 19.3 376.3 29 348.3C38.7 320.3 48.3 235.7 58 226.3C67.7 217 77.3 283 87 291C96.7 299 106.3 249 116 231C125.7 213 135.3 227 145 253.2C154.7 279.3 164.3 317.7 174 301.2C183.7 284.7 193.3 213.3 203 193.3C212.7 173.3 222.3 204.7 232 217.2C241.7 229.7 251.3 223.3 261 253.8C270.7 284.3 280.3 351.7 290 365.3C299.7 379 309.3 339 319 319.2C328.7 299.3 338.3 299.7 348 299C357.7 298.3 367.3 296.7 377 312.2C386.7 327.7 396.3 360.3 406 364.5C415.7 368.7 425.3 344.3 435.2 354.8C445 365.3 455 410.7 464.8 403.7C474.7 396.7 484.3 337.3 494 321.2C503.7 305 513.3 332 523 362.8C532.7 393.7 542.3 428.3 552 405.8C561.7 383.3 571.3 303.7 581 285C590.7 266.3 600.3 308.7 610 344.8C619.7 381 629.3 411 639 376.8C648.7 342.7 658.3 244.3 668 213.2C677.7 182 687.3 218 697 223.8C706.7 229.7 716.3 205.3 726 216.5C735.7 227.7 745.3 274.3 755 321C764.7 367.7 774.3 414.3 784 401.7C793.7 389 803.3 317 813 270C822.7 223 832.3 201 842 181C851.7 161 861.3 143 871 187C880.7 231 890.3 337 895.2 390L900 443" fill="none" stroke-linecap="round" stroke-linejoin="miter" stroke="#89e7ff" stroke-width="28"></path>
                  <text x="450" y="340" font-family="Arial" font-size="150" font-weight="bold" text-anchor="middle" fill="black">CryptoPred</text>
                </svg>               </a>
            </div>
            <!-- primary nav -->
            <div class="hidden md:flex items-center space-x-1">
              <RouterLink to="/" class="py-5 px-3">Go to Home</RouterLink>
              <RouterLink to="/about" class="py-5 px-3">Go to About</RouterLink>
              <RouterLink to="/calculate-rsi" class="py-5 px-3">Calculate RSIs</RouterLink>
              <RouterLink to="/candles" class="py-5 px-3">Candles</RouterLink>
              <RouterLink to="/live-price" class="py-5 px-3">Live Price</RouterLink>
              <RouterLink to="/previous-prices" class="py-5 px-3">Previous Prices</RouterLink>
            </div>
          </div>
          <!-- secondary nav -->
          <div class="hidden md:flex items-center space-x-1">
            <RouterLink to="/profile" class="py-2 px-3">Profile</RouterLink>
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
  