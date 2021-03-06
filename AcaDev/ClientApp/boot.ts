import './css/site.css';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/blog/blog.vue.html') },
    { path: '/about', component: require('./components/about/about.vue.html') },
    { path: '/post/:title', component: require('./components/blog/post-view/post-view.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
