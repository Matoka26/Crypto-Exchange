import { createApp } from 'vue'
import { plugin, defaultConfig } from '@formkit/vue'
import './style.css'
import App from './App.vue'
import './index.css'
import router from './router';


createApp(App).use(router).use(plugin, defaultConfig).mount('#app');




