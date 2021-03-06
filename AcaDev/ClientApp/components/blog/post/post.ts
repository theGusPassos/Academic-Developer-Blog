﻿import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    props: ['post'],
    components: {
        CommentComponent: require('./comment/comment.vue.html')
    }
})
export default class PostComponent extends Vue {
}
