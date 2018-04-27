import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';
import { MatchesService } from '../../../services/matches.service';
import { MatchModel } from '../../../models/match.models';
import { TeamsService } from '../../../services/teams.service';
import { TeamsModel } from '../../../models/teams.model';

@Component({
    selector: 'match-create',
    templateUrl: 'match.create.component.html',
    styleUrls: ['match.create.component.css'],
    providers: [MatchesService,TeamsService]
})

export class CreateMatchComponent implements OnInit {
    private match: MatchModel;
    private teams: TeamsModel[];
    private sub: Subscription;
    private minDate: string;
    
    constructor(private matchService: MatchesService, private teamService:TeamsService, private router: Router) {
        this.match = new MatchModel();
        this.minDate = new Date(Date.now()).toISOString().substr(0,16);
        this.teams = new Array<TeamsModel>();
        this.sub = new Subscription();
    }
    
    ngOnInit() { 
        this.sub = this.teamService.getAllTeams().subscribe(next => this.teams = next);

        $(document).ready(function() {
            document.title = 'TeamSystem - Create Match';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    createMatch() {
        this.sub = this.matchService.createMatch(this.match).subscribe(() => { this.router.navigate(['/matches']); });
    }
}