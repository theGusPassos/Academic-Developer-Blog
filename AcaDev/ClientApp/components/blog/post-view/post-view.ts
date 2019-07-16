import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IPost, IComment } from '../../../interfaces/post';
import axios from 'axios';

@Component({
    components: {
        PostComponent: require('../post/post.vue.html')
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
                if (response.status === 200) {
                    this.post = <IPost>response.data;
                    this.loading = false;
                }
                else {
                    console.error('Post API call status code: ' + response.status);
                    this.error = true;
                    this.errorCode = response.status;
                    this.errorMessage = this.getErrorMessage(this.errorCode);
                }
            })
            .catch(error => {
                console.error(error);
                this.error = true;
            }); 
    }

    getErrorMessage(code: number) {
        if (code === 404) {
            return "Sorry... Post not found =(";
        }
        else {
            return "Sorry... This is an internal server, please try again later";
        }
    }
}
