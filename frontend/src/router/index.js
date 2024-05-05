import {createRouter, createWebHistory} from "vue-router";
import HomeView from "@/views/HomeView.vue";
import RegisterView from "@/views/RegisterView.vue";
import LoginView from "@/views/LoginView.vue";

const routes =
    [
        // Main page
        {
            path: '/',
            name: 'home',
            component: HomeView
        },

        // Registration
        {
            path: '/register',
            name: 'register',
            component: RegisterView
        },

        // Login
        {
            path: '/login',
            name: 'login',
            component: LoginView
        },
    ]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router