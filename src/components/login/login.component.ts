import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { LoginUser } from '../../models/user.models';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit {
    private user: LoginUser;
    private flagInvalidUser = false;
    
    constructor(private router: Router) {
        this.user = new LoginUser();
    }

    ngOnInit() { 
        $(document).ready(function() {
            document.title = 'TeamSystem - Login';
        });
    }

    checkUser() {
        if(sessionStorage.getItem('username') == this.user.username && sessionStorage.getItem('password') == this.user.password) {
            this.flagInvalidUser = false;
            this.router.navigate(['/']);
        }
        else {
            this.flagInvalidUser = true;
        }
    }
}