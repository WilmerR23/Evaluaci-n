import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import { VueMaskDirective } from 'v-mask';
import Multiselect from 'vue-multiselect';

Vue.directive('mask', VueMaskDirective);
Vue.use(VueRouter);
Vue.component('multiselect', Multiselect);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/examen', component: require('./components/examen/examen.vue.html') }
];

let vueInstance = new VueRouter({ mode: 'history', routes: routes, });

// vueInstance.beforeEach((to, from, next) => {
//     let isLoggedIn = localStorage.getItem('isLogin');
//     if (!isLoggedIn && to.fullPath !== "/") {
//         next('/');
//     } else {
//         next();
//     }
// })

new Vue({
    el: '#app-root',
    router: vueInstance,
    render: h => h(require('./components/app/app.vue.html'))
});
