import { createRouter, createMemoryHistory } from 'vue-router';
import Home from '../components/Home.vue';
import About from '../components/About.vue';
import Login from '../components/user/Login.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  // Add more routes here as needed
];

const router = createRouter({
    history: createMemoryHistory(),
    routes
});

export default router;
