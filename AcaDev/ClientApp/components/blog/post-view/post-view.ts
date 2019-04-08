import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IPost, IComment } from '../../../interfaces/post';

@Component({
    components: {
        PostComponent: require('../post/post.vue.html')
    }
})
export default class BlogComponent extends Vue {
    post: IPost = {} as IPost;
    comments: IComment[] = [];

    mounted() {
        var post_title = this.$route.params.title;
        console.log(post_title);

        this.fetchPost();
    }

    fetchPost() {
        this.comments =
            [
                { id: 1, author: 'Batman', content: 'Asduhasdhuf asudfha dhashdf ausdhf ausdf', date: new Date() },
                { id: 2, author: 'Superman', content: 'Asduhasdhuf asudfha dhashdf ausdhf ausdf', date: new Date() },
            ];

        // mocked posts
        this.post =
        {
            id: 1, title: 'Trying to Creating new Stuff IV', date: new Date(), author: 'Gustavo Passos', tags: ['.net core', 'bootstrap'], content: 'Ullamco enim cillum nostrud officia tempor. Nostrud do id laboris eu id fugiat aliquip laboris aute veniam sint aute. Sunt ad sint consectetur cillum duis adipisicing sit id duis.',
            comments: this.comments
            };
    }
}
