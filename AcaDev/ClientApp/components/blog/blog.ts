import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IPost } from '../../interfaces/post';
import axios from 'axios';

@Component({
    components: {
        PostComponent: require('./post/post.vue.html')
    }
})
export default class BlogComponent extends Vue {
    posts: IPost[] = [];

    mounted() {
        this.fetchPosts();
    }

    fetchPosts() {

        axios.get('api/posts')
            .then(response => {
                if (response.status === 200) {
                    this.posts = response.data as IPost[];
                }
                else {
                    // handle errors
                }
            })
            .catch(ex => {
                // handle errors
            });
    }
}
