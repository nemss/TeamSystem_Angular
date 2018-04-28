import { Component, OnInit, OnDestroy } from '@angular/core';
import { TeamsService } from '../../services/teams.service';
import { TeamsModel } from '../../models/teams.model';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';

@Component({
    selector: 'teams',
    templateUrl: 'teams.component.html',
    styleUrls: ['teams.component.css'],
    providers: [TeamsService]
})

export class TeamsComponent implements OnInit, OnDestroy {
    teams: TeamsModel[];
    teamsOnPage: TeamsModel[];
    private sub : Subscription;
    private teamsPerPage = 6;
    private currentPage = 1;
    pages: number[];
    
    constructor(private teamService: TeamsService, private router: Router) { 
        this.sub = new Subscription();
        this.teamsOnPage = new Array<TeamsModel>();
        this.pages = new Array<number>();
    }
    
    ngOnInit() { 
        this.sub = this.teamService.getTeamsPerPage(this.teamsPerPage).subscribe( teams => this.teamsOnPage = teams, err => {}, () => {
            this.calculatePages(this.teamsPerPage);
        });

        //Jquery scripts
        $(function() {
            document.title = 'TeamSystem - Teams';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    goToDetails(id: number) {
        this.router.navigate(['/team', id]);
    }

    goToPage(page: number) {
        this.currentPage = page;
        this.sub = this.teamService.getTeamsPerPage(this.teamsPerPage, page).subscribe(teams => this.teamsOnPage = teams);
    }

    calculatePages(itemsPerPage: number) {
        this.sub = this.teamService.getAllTeams().subscribe(teams => {
            this.teams = teams;
        }, err => {},
        () => {
            this.pages = Array.from(new Array(Math.ceil(this.teams.length/itemsPerPage)),(val,i) => val = i+1);
        });
    }
    trackByFn(index,item) {
        return item;
    }
}