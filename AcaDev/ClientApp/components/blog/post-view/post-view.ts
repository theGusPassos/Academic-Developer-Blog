import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IPost, IComment } from '../../../interfaces/post';
import axios from 'axios';
import moment from 'moment';

@Component({
    components: {
        Post: require('../post/post.vue.html'),
        CommentSection: require('../../post/comment-section/comment-section.vue.html')
    }
})
export default class BlogComponent extends Vue {
    loading: boolean = true;

    error: boolean = false;
    errorCode: number = 404;
    errorMessage: string = "Post not found";

    post: IPost = {} as IPost;
    comments: IComment[] = [];

    mounted() {
        var post_title = this.$route.params.title;
        this.fetchPost(post_title);
    }

    fetchPost(title: string) {
        axios.get('/api/posts?title=' + title)
            .then(response => {
                this.loading = false;

                if (response.status === 200) {
                    this.post = <IPost>response.data;
                    // using an outside property to allow vue binding
                    this.comments = this.post.comments;
                }
                else {
                    this.setError(response.status);
                }
            })
            .catch(error => {
                this.setError(500);
            }); 
    }

    setError(code: number) {
        this.error = true;
        this.errorCode = code;
        this.errorMessage = this.getErrorMessage(code);
    }

    getErrorMessage(code: number) {
        if (code === 404) {
            return 'Sorry... Post not found =(';
        }
        else {
            return 'Sorry... This is an internal server, please try again later';
        }
    }
}
