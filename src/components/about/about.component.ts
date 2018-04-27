import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
    selector: 'about',
    templateUrl: 'about.component.html',
    styleUrls: ['about.component.css']
})

export class AboutComponent implements OnInit {
    constructor() { }

    ngOnInit() { 
        $(document).ready(function() {
            document.title = 'TeamSystem - About';
        });
    }
}