import { Component, OnInit, OnDestroy} from '@angular/core';
import { NewsService } from './../../services/news.service';
import { NewsModel, ArticleModel } from './../../models/news.models';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';
import * as $ from 'jquery';

@Component({
    selector: 'news',
    templateUrl: 'news.component.html',
    styleUrls: ['news.component.css'],
    providers: [NewsService]
})

export class NewsComponent implements OnInit, OnDestroy {
    holdAllNews: NewsModel[];
    newsOnPage: NewsModel[];
    private sub: Subscription;
    private articlesPerPage = 3;
    private currentPage = 1;
    pages: number[];
    
    constructor(private newsService: NewsService, private router: Router) { 
        this.sub = new Subscription();
        this.holdAllNews = new Array<NewsModel>();
        this.pages = new Array<number>();
    }
    
    ngOnInit() {
        this.sub = this.newsService.getArticlesPerPage(this.articlesPerPage).subscribe( news => this.newsOnPage = news, err => {}, () => {
            this.calculatePages(this.articlesPerPage);
        });

        //Jquery scripts
        $(function() {
            document.title = 'TeamSystem - News';
        });
    }
    
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    goToDetails(id: number) {
        this.router.navigate(['/article', id]);
    }

    goToPage(page: number) {
        this.currentPage = page;
        this.sub = this.newsService.getArticlesPerPage(this.articlesPerPage, page).subscribe(news => this.newsOnPage = news);
    }

    calculatePages(itemsPerPage: number) {
        this.sub = this.newsService.getAllNews().subscribe(news => {
            this.holdAllNews = news;
        }, err => {},
        () => {
            this.pages = Array.from(new Array(Math.ceil(this.holdAllNews.length/itemsPerPage)),(val,i) => val = i+1);
        });
    }

    trackByFn(index,item) {
        return item;
    }
}