import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    props: ['isLoading']
})
export default class Loading extends Vue {


}
