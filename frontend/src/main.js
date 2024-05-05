import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import "../public/css/weather.less"

createApp(App)
    .use(router)
    .mount('#app')
