import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { RegisterUser } from '../../models/user.models';

@Component({
    selector: 'register',
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.css']
})

export class RegisterComponent implements OnInit {
    private user: RegisterUser;
    private flagUserExist = false;
    constructor(private router: Router) { 
        this.user = new RegisterUser();
    }

    ngOnInit() { 
        $(document).ready(function() {
            document.title = 'TeamSystem - Register';
        });
    }

    registerUser() {
        if(sessionStorage.getItem('username') == this.user.username){
            this.flagUserExist = true;
        }
        else {
            this.flagUserExist = false;
            sessionStorage.setItem('username',this.user.username);
            sessionStorage.setItem('password',this.user.password);
            this.router.navigate(['/login'])
        }
    }
}