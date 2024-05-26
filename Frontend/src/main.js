import { createApp } from 'vue'
import { plugin, defaultConfig } from '@formkit/vue'
import formkitConfig from '../formkit.config'
import './style.css'
import App from './App.vue'
import './index.css'
import router from './router';
import VueApexCharts from "vue3-apexcharts";
import Vue3Toastify, { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';


createApp(App).use(router).use(plugin, defaultConfig).use(VueApexCharts).use(Vue3Toastify).mount('#app');




