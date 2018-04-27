import { Component, OnInit, OnDestroy } from '@angular/core';
import { NewsService } from './../../../services/news.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleModel } from './../../../models/news.models';
import { Subscription } from 'rxjs/Subscription';
import * as $ from 'jquery';

@Component({
    selector: 'article-details',
    templateUrl: 'article.details.component.html',
    styleUrls: ['article.details.component.css'],
    providers: [NewsService]
})

export class ArticleDetailsComponent implements OnInit, OnDestroy {
    private articleId: number;
    private article: ArticleModel;
    private flagDelete: boolean;
    private sub: Subscription;
    
    constructor(private newsService: NewsService, private route: ActivatedRoute, private router: Router) {
        this.flagDelete = false;
        this.sub = new Subscription();
     }
    
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => this.articleId = params['id']);
        this.sub = this.newsService.getArticle(this.articleId).subscribe(next => this.article = next);
        
        $(document).ready(function() {
            document.title = 'TeamSystem - Article Details';
        });
    }
    
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    deleteArticle() {
        this.flagDelete = false;
        this.sub = this.newsService.deleteArticle(this.articleId).subscribe(() => { this.router.navigate(['/news']); });
    }

    editArticle() {
        this.router.navigate(['/article/edit', this.articleId]);
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