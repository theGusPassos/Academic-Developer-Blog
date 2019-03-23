import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { IPost } from '../../interfaces/post';

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
        // mocked posts
        this.posts = [
            { id: 1, title: 'Teste Teste Teste Teste Trying to Creating new Stuff', date: new Date(), author: 'Gustavo Passos', tags: ['.net core'], content: 'Ullamco enim cillum nostrud officia tempor. Nostrud do id laboris eu id fugiat aliquip laboris aute veniam sint aute. Sunt ad sint consectetur cillum duis adipisicing sit id duis.' },
            { id: 1, title: 'Trying to Creating new Stuff II ', date: new Date(), author: 'Gustavo Passos', tags: ['.net core', 'architecture'], content: 'Ullamco enim cillum nostrud officia tempor. Nostrud do id laboris eu id fugiat aliquip laboris aute veniam sint aute. Sunt ad sint consectetur cillum duis adipisicing sit id duis.' },
            { id: 1, title: 'Trying to Creating new Stuff III', date: new Date(), author: 'Gustavo Passos', tags: ['html', 'css'], content: 'Ullamco enim cillum nostrud officia tempor. Nostrud do id laboris eu id fugiat aliquip laboris aute veniam sint aute. Sunt ad sint consectetur cillum duis adipisicing sit id duis.' },
            { id: 1, title: 'Trying to Creating new Stuff IV', date: new Date(), author: 'Gustavo Passos', tags: ['.net core', 'bootstrap'], content: 'Ullamco enim cillum nostrud officia tempor. Nostrud do id laboris eu id fugiat aliquip laboris aute veniam sint aute. Sunt ad sint consectetur cillum duis adipisicing sit id duis.' }
        ];
    }
}
