<script setup>

  import LoadingComponent from "@/components/Common/LoadingComponent.vue";
  import {onMounted, ref} from "vue";
  import {WebClientSendGetRequest} from "@/js/libWeather";

  const isLoading = ref(true)
  const siteInfo = ref(null)

  onMounted(async () =>
  {
    await OnLoad();
  })

  async function OnLoad()
  {
    const siteInfoResponse = await WebClientSendGetRequest("/api/Site/Info")

    siteInfo.value = (await siteInfoResponse.json()).siteInfo

    isLoading.value = false
  }

</script>

<template>

  <LoadingComponent v-if="isLoading" />

  <div v-if="!isLoading">
    <div>{{ siteInfo.backendVersion }}</div>
    <div><a :href="siteInfo.sourcesUrl">{{ siteInfo.sourcesUrl }}</a></div>
  </div>
</template>