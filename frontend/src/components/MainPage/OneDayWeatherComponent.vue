<script setup>
import {defineProps} from "vue";

const props = defineProps({
  weather: Object
})

</script>

<template>
  <div class="one-day-weather-container">
      <div>
        <div>Дата: {{ props.weather.timestamp }}</div>
        <div>Температура: {{ props.weather.temperature }}°C</div>
        <div>Влажность: {{ props.weather.humidity }}%</div>
        <div>Давление: {{ props.weather.pressure }}гПа</div>
      </div>
    </div>
</template>