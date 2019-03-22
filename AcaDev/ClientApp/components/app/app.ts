import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        NavbarComponent: require('../navbar/navbar.vue.html')
    }
})
export default class AppComponent extends Vue {
}
