import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({
    props: ['post']
})
export default class PostComponent extends Vue {
}
