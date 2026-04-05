import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

/**
 * Example Pinia store — demonstrates basic store functionality.
 * In practice, create one store per resource e.g. people.ts, auth.ts
 */
export const useCounterStore = defineStore('counter', () => {
  // ref() is a reactive state
  const count = ref(0)
  
  // computed() is derived state (from count) - recalculates when counts value changes
  const doubleCount = computed(() => count.value * 2)
  function increment() {
    count.value++
  }

  // all of these are accessible when calling useCounterStore() in a component
  return { count, doubleCount, increment }
})
