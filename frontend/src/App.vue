<script setup lang="ts">
import PersonList from "@/components/PersonList.vue";
import { useCounterStore } from "@/stores/counter.ts";

const store = useCounterStore()
</script>

<template>
  <h1>You did it!</h1>
  <p>
    Visit <a href="https://vuejs.org/" target="_blank" rel="noopener">vuejs.org</a> to read the
    documentation
  </p>
  <div id="pinia-example">
    <p>{{ store.count }}</p>
    <p>{{ store.doubleCount }}</p>
    <button @click="store.increment()">Click to increment</button>
  </div>
  <PersonList />
</template>

<style scoped></style>
