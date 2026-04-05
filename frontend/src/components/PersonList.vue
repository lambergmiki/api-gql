<script setup lang="ts">
import { useQuery } from '@vue/apollo-composable'
import { GET_PEOPLE, type Person } from "@/queries/people.ts";

const { result, loading, error } = useQuery<{ people: Person[] }>(GET_PEOPLE)

</script>

<template>
  <h1>This is the person component!</h1>
<p v-if="loading">Loading...</p>
  <p v-else-if="error">{{ error.message }}</p>
  <ul v-else>
    <li v-for="person in result?.people" :key="person.id">
      {{ person.firstName }} {{ person.lastName }} - age: {{ person.age }}
    </li>
  </ul>
</template>