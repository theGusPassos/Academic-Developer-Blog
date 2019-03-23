import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    props: ['comment']
})
export default class PostComponent extends Vue {
}
