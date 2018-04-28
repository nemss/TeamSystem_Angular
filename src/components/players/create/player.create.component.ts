import { Component, OnInit, OnDestroy } from '@angular/core';
import { PersonModel } from '../../../models/players.models';
import { Subscription } from 'rxjs/Subscription';
import { PlayersService } from '../../../services/players.service';
import { Router } from '@angular/router';
import { PlayerRolesService } from '../../../services/player.roles.service';
import { TeamsService } from '../../../services/teams.service';
import { TeamsModel } from '../../../models/teams.model';
import { ModelRole } from '../../../models/roles.model';

@Component({
    selector: 'player-create',
    templateUrl: 'player.create.component.html',
    styleUrls: ['player.create.component.css'],
    providers: [PlayersService, TeamsService, PlayerRolesService]
})

export class CreatePlayerComponent implements OnInit, OnDestroy {
    player: PersonModel;
    private sub: Subscription;
    private teams: TeamsModel[];
    private roles: ModelRole[];
    private maxDate: string;
    
    constructor(private playerService: PlayersService, private roleService: PlayerRolesService, private teamService: TeamsService, private router: Router) {
        this.player = new PersonModel();
        this.maxDate = new Date(Date.now()).toISOString().substr(0,10);
        this.sub = new Subscription();
    }
    
    ngOnInit() {
        this.sub = this.teamService.getAllTeams().subscribe(next => this.teams = next);
        this.sub = this.roleService.getAllRoles().subscribe(next => this.roles = next);

        $(document).ready(function() {
            document.title = 'TeamSystem - Create Player';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    createPlayer() {
        this.sub = this.playerService.createPlayer(this.player).subscribe(() => { this.router.navigate(['/players']); });
    }
}