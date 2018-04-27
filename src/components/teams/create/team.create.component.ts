import { Component, OnInit } from '@angular/core';
import { TeamsService } from '../../../services/teams.service';
import { TeamsModel } from '../../../models/teams.model';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';

@Component({
    selector: 'team-create',
    templateUrl: 'team.create.component.html',
    styleUrls: ['team.create.component.css'],
    providers: [TeamsService]
})

export class CreateTeamComponent implements OnInit {
    private team: TeamsModel;
    private sub: Subscription;
    
    constructor(private teamService: TeamsService, private router: Router) {
        this.team = new TeamsModel();
        this.sub = new Subscription();
    }
    
    ngOnInit() { 
        $(document).ready(function() {
            document.title = 'TeamSystem - Create Team';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    createTeam() {
        this.sub = this.teamService.createTeam(this.team).subscribe(() => { this.router.navigate(['/teams']); });
    }
}