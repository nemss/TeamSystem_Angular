import { Component, OnInit, OnDestroy } from '@angular/core';
import { PersonModel } from '../../../models/players.models';
import { Subscription } from 'rxjs/Subscription';
import { PlayersService } from '../../../services/players.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TeamsModel } from '../../../models/teams.model';
import { TeamsService } from '../../../services/teams.service';
import { PlayerRolesService } from '../../../services/player.roles.service';
import { ModelRole } from '../../../models/roles.model';

@Component({
    selector: 'player-edit',
    templateUrl: 'player.edit.component.html',
    styleUrls: ['player.edit.component.css'],
    providers: [PlayersService,PlayerRolesService,TeamsService]
})

export class EditPlayerComponent implements OnInit, OnDestroy {
    private playerId: number;
    private teams: TeamsModel[];
    private roles: ModelRole[];
    private player: PersonModel;
    private sub: Subscription;
    
    constructor(private playerService: PlayersService, private roleService: PlayerRolesService, private teamService: TeamsService, private route: ActivatedRoute, private router: Router) {
        this.sub = new Subscription();
    }
    
    ngOnInit() { 
        this.sub = this.route.params.subscribe(params => this.playerId = params['id']);
        this.sub = this.playerService.getPlayer(this.playerId).subscribe(next => this.player = next);
        this.sub = this.teamService.getAllTeams().subscribe(next => this.teams = next);
        this.sub = this.roleService.getAllRoles().subscribe(next => this.roles = next);

        $(document).ready(function() {
            document.title = 'TeamSystem - Edit Player';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    editPlayer() {
        this.sub = this.playerService.updatePlayer(this.playerId, this.player).subscribe(() => { this.router.navigate(['/players']); });
    }
}