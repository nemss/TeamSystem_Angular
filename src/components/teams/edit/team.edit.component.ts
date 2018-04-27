import { Component, OnInit, OnDestroy } from '@angular/core';
import { TeamsModel } from '../../../models/teams.model';
import { Subscription } from 'rxjs/Subscription';
import { TeamsService } from '../../../services/teams.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'team-edit',
    templateUrl: 'team.edit.component.html',
    styleUrls: ['team.edit.component.css'],
    providers: [TeamsService]
})

export class EditTeamComponent implements OnInit, OnDestroy {
    private teamId: number;
    private team: TeamsModel;
    private sub: Subscription;

    constructor(private teamService: TeamsService, private route: ActivatedRoute, private router: Router) { 
        this.sub = new Subscription();
    }
    
    ngOnInit() { 
        this.sub = this.route.params.subscribe(params => this.teamId = params['id']);
        this.sub = this.teamService.getTeam(this.teamId).subscribe(next => this.team = next);

        $(document).ready(function() {
            document.title = 'TeamSystem - Edit Team';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    editTeam() {
        this.sub = this.teamService.updateTeam(this.teamId, this.team).subscribe(() => { this.router.navigate(['/teams']); });
    }
}