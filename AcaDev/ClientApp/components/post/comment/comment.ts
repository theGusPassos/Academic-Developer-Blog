import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import moment from 'moment';

@Component({
    props: ['comment']
})
export default class Comment extends Vue {
    getFormatedDate(date: any) {
        return moment(date).format('MM/DD/YYYY hh:mm');
    }
}
