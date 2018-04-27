import { Component, OnInit, OnDestroy} from '@angular/core';
import { NewsService } from '../../../services/news.service';
import { ArticleModel } from '../../../models/news.models';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import * as $ from 'jquery';

@Component({
    selector: 'edit-article',
    templateUrl: 'edit.article.component.html',
    styleUrls: ['edit.article.component.css'],
    providers: [NewsService]
})

export class EditArticleComponent implements OnInit, OnDestroy {
    private articleId: number;
    private article: ArticleModel;
    private sub: Subscription;
    
    constructor(private newsService: NewsService, private route: ActivatedRoute, private router: Router) {
        this.sub = new Subscription();
    }
    
    ngOnInit() { 
        this.sub = this.route.params.subscribe(params => this.articleId = params['id']);
        this.sub = this.newsService.getArticle(this.articleId).subscribe(next => this.article = next);

        $(document).ready(function() {
            document.title = 'TeamSystem - Edit Article';
        });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    editArticle() {
        this.sub = this.newsService.updateArticle(this.articleId, this.article).subscribe(() => { this.router.navigate(['/news']); });
    }
}