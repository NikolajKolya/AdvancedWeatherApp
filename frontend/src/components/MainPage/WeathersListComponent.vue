<script setup>
import {defineProps, onMounted, ref} from "vue";
import LoadingComponent from "@/components/Common/LoadingComponent.vue";
import {WebClientSendPostRequest} from "@/js/libWeather";
import OneDayWeatherComponent from "@/components/MainPage/OneDayWeatherComponent.vue";

  const props = defineProps({
    weathersIds: Array
  })

  const isLoading = ref(true)

  const weathers = ref([])

  onMounted(async () =>
  {
    await OnLoad();
  })

  async function OnLoad()
  {
    weathers.value = await GetWeathersByReferences(props.weathersIds)

    isLoading.value = false
  }

  async function GetWeathersByReferences(weathersReferences)
  {
    return (await (await WebClientSendPostRequest(
        "/api/Weathers/Get/ByIds",
        {
          weathersIds: weathersReferences
        })).json())
        .weathers
  }

</script>

<template>

  <LoadingComponent
      v-if="isLoading" />

  <div
      v-if="!isLoading"
      class="weathers-list-container">

    <OneDayWeatherComponent
        v-for="weather in weathers"
        v-bind:key="weather.id"
        :weather="weather">
    </OneDayWeatherComponent>

  </div>

</template>
