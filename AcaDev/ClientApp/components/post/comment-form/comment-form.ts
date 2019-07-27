import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IComment } from '../../../interfaces/post';
import axios from 'axios';

@Component({
    props: {
        method: { type: Function }
    }
})
export default class Comment extends Vue {
    username: string = "";
    commentContent: string = "";
    postClicked: boolean = false;

    commentError: string = "";
    commentFormError: boolean = false;

    postComment() {
        this.postClicked = true;

        axios.post('api/posts/' + this.post.id + '/comment', {
            username: this.username,
            content: this.commentContent
        })
            .then(response => {
                if (response.status === 200) {
                    this.comments.push(<IComment>response.data);
                    this.resetCommentForm();
                }
                else {
                    this.commentFormError = true;
                    this.commentError = response.data.error;
                }
            })
            .catch(exeption => {
                this.commentFormError = true;
                this.commentError = "Error while posting your comment, please try again later.";
            });
    }

    resetCommentForm() {
        this.postClicked = false;
        this.username = "";
        this.commentContent = "";
    }

    canPost(): boolean {
        return this.username !== "" && this.commentContent !== "";
    }
}
