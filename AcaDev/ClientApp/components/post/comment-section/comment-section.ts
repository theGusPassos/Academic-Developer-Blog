import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IComment } from '../../../interfaces/post';

@Component({
    props: ['post-id', 'comments'],
    components: {
        Comment: require('../comment/comment.vue.html'),
        CommentForm: require('../comment-form/comment-form.vue.html')
    }
})
export default class CommentSection extends Vue {
    addComment(comment: IComment) {
        this.$props.comments.push(comment);
    }
} 
