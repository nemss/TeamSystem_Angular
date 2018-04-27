import { Component, OnInit, OnDestroy } from '@angular/core';
import { NewsService } from '../../../services/news.service';
import { ArticleModel } from '../../../models/news.models';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import * as $ from 'jquery';

@Component({
    selector: 'create-article',
    templateUrl: 'create.article.component.html',
    styleUrls: ['create.article.component.css'],
    providers: [NewsService]
})

export class CreateArticleComponent implements OnInit, OnDestroy {
    private article: ArticleModel;
    private sub: Subscription;
    
    constructor(private newsService: NewsService, private router: Router) {
        this.article = new ArticleModel();
        this.sub = new Subscription();
    }
    
    ngOnInit() { 
        $(document).ready(function() {
            document.title = 'TeamSystem - Create Article';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    createArticle() {
        this.sub = this.newsService.createArticle(this.article).subscribe(() => { this.router.navigate(['/news']); });
    }
}