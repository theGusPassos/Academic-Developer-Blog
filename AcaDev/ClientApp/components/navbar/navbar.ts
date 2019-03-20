import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class NavbarComponent extends Vue {
    showMobileNav: boolean = false;

    onHamburgerClick() {
        this.showMobileNav = !this.showMobileNav;
    }
}
