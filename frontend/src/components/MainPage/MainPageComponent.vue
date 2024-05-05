<script setup>

  import LoadingComponent from "@/components/Common/LoadingComponent.vue";
  import {onMounted, ref} from "vue";
  import {WebClientSendGetRequest} from "@/js/libWeather";
  import WeathersListComponent from "@/components/MainPage/WeathersListComponent.vue";

  const isLoading = ref(true)

  const allWeathersReferences = ref(null)

  onMounted(async () =>
  {
    await OnLoad();
  })

  async function OnLoad()
  {
    allWeathersReferences.value = (await
        (await WebClientSendGetRequest("/api/Weathers/References/All"))
        .json())
        .allWeathersReferences
        .map(w => w.weatherId)

    isLoading.value = false
  }
</script>

<template>

  <LoadingComponent v-if="isLoading" />

  <div v-if="!isLoading">

    <WeathersListComponent
      :weathersIds="allWeathersReferences"/>

  </div>
</template>