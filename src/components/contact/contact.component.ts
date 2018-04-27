import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
    selector: 'contact',
    templateUrl: 'contact.component.html',
    styleUrls: ['contact.component.css']
})

export class ContactComponent implements OnInit {
    constructor() { }

    ngOnInit() { 
        $(document).ready(function() {
            document.title = 'TeamSystem - Contact';
        });
    }
}