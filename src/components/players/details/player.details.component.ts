import { Component, OnInit, OnDestroy } from '@angular/core';
import { PersonModel } from '../../../models/players.models';
import { Subscription } from 'rxjs/Subscription';
import { PlayersService } from '../../../services/players.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'player-details',
    templateUrl: 'player.details.component.html',
    styleUrls: ['player.details.component.css'],
    providers: [PlayersService]
})

export class PlayerDetailsComponent implements OnInit, OnDestroy {
    private playerId: number;
    private player: PersonModel;
    private flagDelete: boolean;
    private sub: Subscription;
    
    constructor(private playerService: PlayersService, private route: ActivatedRoute, private router: Router) {
        this.flagDelete = false;
        this.sub = new Subscription();
     }
    
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => this.playerId = params['id']);
        this.sub = this.playerService.getPlayer(this.playerId).subscribe(next => this.player = next);
        
        $(document).ready(function() {
            document.title = 'TeamSystem - Player Details';
        });
    }
    
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    deletePlayer() {
        this.flagDelete = false;
        this.sub = this.playerService.deletePlayer(this.playerId).subscribe(() => { this.router.navigate(['/players']); });
    }

    editPlayer() {
        this.router.navigate(['/player/edit', this.playerId]);
    }

    flagDChange(){
        if(this.flagDelete) {
            this.flagDelete = false;
        }
        else {
            this.flagDelete = true;
        }
    }
}