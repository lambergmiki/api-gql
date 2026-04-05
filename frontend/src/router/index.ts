import { createRouter, createWebHistory } from 'vue-router'

// createWebHistory uses the browser's History API for navigation (clean URLs, no # in the path).
// BASE_URL is set by Vite — defaults to "/" unless configured otherwise in vite.config.ts.
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [], // Route definitions go here e.g. { path: '/', component: HomeView }
})

export default router
