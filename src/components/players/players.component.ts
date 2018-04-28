import { Component, OnInit, OnDestroy } from '@angular/core';
import { PlayersService } from '../../services/players.service';
import { PlayersModel, PersonModel } from '../../models/players.models';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';

@Component({
    selector: 'players',
    templateUrl: 'players.component.html',
    styleUrls: ['players.component.css'],
    providers: [PlayersService]
})

export class PlayersComponent implements OnInit, OnDestroy {
    holdAllPlayers: PersonModel[];
    playersOnPage: PlayersModel[];
    private sub: Subscription;
    private playersPerPage = 10;
    private currentPage = 1;
    pages: number[];
    
    constructor(private playerService: PlayersService, private router: Router) { 
        this.sub = new Subscription();
        this.holdAllPlayers = new Array<PersonModel>();
        this.pages = new Array<number>();
    }
    
    ngOnInit() {
        this.sub = this.playerService.getPlayersPerPage(this.playersPerPage).subscribe( players => this.playersOnPage = players, err => {}, () => {
            this.calculatePages(this.playersPerPage);
        });

        //Jquery scripts
        $(function() {
            document.title = 'TeamSystem - Players';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    goToDetails(id: number) {
        this.router.navigate(['/player', id]);
    }

    goToPage(page: number) {
        this.currentPage = page;
        this.sub = this.playerService.getPlayersPerPage(this.playersPerPage, page).subscribe(players => this.playersOnPage = players);
    }

    calculatePages(itemsPerPage: number) {
        this.sub = this.playerService.getAllPlayers().subscribe(players => {
            this.holdAllPlayers = players;
        }, err => {},
        () => {
            this.pages = Array.from(new Array(Math.ceil(this.holdAllPlayers.length/itemsPerPage)),(val,i) => val = i+1);
        });
    }

    trackByFn(index,item){
        return item;
    }
}