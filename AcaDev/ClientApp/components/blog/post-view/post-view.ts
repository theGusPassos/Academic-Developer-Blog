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
    loading: boolean = false;
    error: boolean = false;

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
                }
            })
            .catch(error => {
                console.error(error);
                this.error = true;
            }); 
    }
}
