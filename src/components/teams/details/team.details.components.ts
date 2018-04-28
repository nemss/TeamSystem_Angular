import { Component, OnInit, OnDestroy } from '@angular/core';
import { TeamsService } from '../../../services/teams.service';
import { TeamsModel } from '../../../models/teams.model';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { PlayersModel, PersonModel } from '../../../models/players.models';
import { PlayersService } from '../../../services/players.service';
import { MatchModel } from '../../../models/match.models';
import { MatchesService } from '../../../services/matches.service';

@Component({
    selector: 'team-details',
    templateUrl: 'team.details.component.html',
    styleUrls: ['team.details.component.css'],
    providers: [TeamsService, PlayersService, MatchesService]
})

export class TeamDetailsComponent implements OnInit, OnDestroy {
    private teamId: number;
    team: TeamsModel;
    private allPlayers: PersonModel[];
    private playersInTeam: PersonModel[];
    private staffInTeam: PersonModel[];
    private allMatches: MatchModel[];
    private homeMatches: MatchModel[];
    private guestMatches: MatchModel[];
    private flagDelete: boolean;
    private sub: Subscription;
    
    constructor(private teamService: TeamsService, private playerService: PlayersService, private matchService: MatchesService, private route: ActivatedRoute, private router: Router) {
        this.flagDelete = false;
        this.allPlayers = new Array<PersonModel>();
        this.allMatches = new Array<MatchModel>();
        this.playersInTeam = new Array<PersonModel>();
        this.staffInTeam = new Array<PersonModel>();
        this.homeMatches = new Array<MatchModel>();
        this.guestMatches = new Array<MatchModel>();

        this.sub = new Subscription();
     }
    
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => this.teamId = params['id']);
        this.sub = this.teamService.getTeam(this.teamId).subscribe(next => this.team = next);
        this.sub = this.playerService.getAllPlayers().subscribe(next => this.allPlayers = next, err => {}, () => {
            this.getPlayersInTeam(this.allPlayers);
        });
        this.sub = this.matchService.getAllMatches().subscribe(next => this.allMatches = next, err => {}, () => {
            this.separateMatches(this.allMatches);
        });

        $(document).ready(function() {
            document.title = 'TeamSystem - Team Details';
        });
    }
    
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    deleteTeam() {
        this.flagDelete = false;
        this.sub = this.teamService.deleteTeam(this.teamId).subscribe(() => { this.router.navigate(['/teams']); });
    }

    editTeam() {
        this.router.navigate(['/team/edit', this.teamId]);
    }

    flagDChange(){
        if(this.flagDelete) {
            this.flagDelete = false;
        }
        else {
            this.flagDelete = true;
        }
    }

    getPlayersInTeam(allP: PersonModel[]) {
        allP.forEach((value) => {
            if(value.teamId == this.teamId && value.modelRoleName == 'Player') {
                this.playersInTeam.push(value);
            }
            if(value.teamId == this.teamId && value.modelRoleName != 'Player') {
                this.staffInTeam.push(value);
            }
        });
        this.playersInTeam.sort();
        this.staffInTeam.sort();
    }

    separateMatches(allM: MatchModel[]) {
        allM.forEach((value) => {
            if(value.homeTeamId == this.teamId) {
                this.homeMatches.push(value);
            }
            else if(value.guestTeamId == this.teamId) {
                this.guestMatches.push(value);
            }
        });
        this.playersInTeam.sort();
        this.staffInTeam.sort();
    }

    goToPlayerDetails(id: number) {
        this.router.navigate(['/player', id]);
    }

    goToMatchDetails(id: number) {
        this.router.navigate(['/match', id]);
    }
}