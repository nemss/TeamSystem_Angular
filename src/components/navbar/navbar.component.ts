import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
    selector: 'navbar',
    templateUrl: 'navbar.component.html',
    styleUrls: ['navbar.component.css']
})

export class NavbarComponent implements OnInit {
    constructor() { 
        
    }

    ngOnInit() {
        //slide nav bar
        $(".dropdown,.dropdownMenu").click(function(){
            $(".dropdownMenu").stop(true, true).slideToggle('fast');
        });
     }
}