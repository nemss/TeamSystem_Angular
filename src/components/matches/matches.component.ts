import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { MatchesService } from '../../services/matches.service';
import { MatchModel } from '../../models/match.models';

@Component({
    selector: 'matches',
    templateUrl: 'matches.component.html',
    styleUrls: ['matches.component.css'],
    providers: [MatchesService]
})

export class MatchesComponent implements OnInit, OnDestroy {
    matches: MatchModel[];
    matchesOnPage: MatchModel[];
    private sub: Subscription;
    private matchesPerPage = 5;
    private currentPage = 1;
    pages: number[];
    
    constructor(private matchService: MatchesService) { 
        this.pages = new Array<number>();
        this.sub = new Subscription();
        this.matchesOnPage = new Array<MatchModel>();
    }
    
    ngOnInit() { 
        var loading = $('.loadingDiv');
        loading.css("display","block");
        this.sub = this.matchService.getMatchesPerPage(this.matchesPerPage).subscribe( matches => this.matchesOnPage = matches, err => {}, () => {
            this.calculatePages(this.matchesPerPage);
            loading.css("display","none");
        });

        $(function() {
            document.title = 'TeamSystem - Matches';
        });
    }
    
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    goToPage(page: number) {
        this.currentPage = page;
        this.sub = this.matchService.getMatchesPerPage(this.matchesPerPage, page).subscribe(matches => this.matchesOnPage = matches);
    }

    calculatePages(itemsPerPage: number) {
        this.sub = this.matchService.getAllMatches().subscribe(matches => {
            this.matches = matches;
        }, err => {},
        () => {
            this.pages = Array.from(new Array(Math.ceil(this.matches.length/itemsPerPage)),(val,i) => val = i+1);
        });
    }

    trackByFn(index,item) {
        return item;
    }
}