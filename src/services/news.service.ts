import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { NewsModel, ArticleModel } from './../models/news.models';

@Injectable()
export class NewsService {
    private apiUrl = '/api/news/';

    constructor(private http: Http) {

     }

     getAllNews() {
        let newsUrl = this.apiUrl;
        return this.http.get(newsUrl).map( value => value.json() as NewsModel[]);
     }

     getArticlesPerPage(articlesPerPage: number, page: number = 1) {
         let articlesPerPageUrl = this.apiUrl + articlesPerPage + '/' + page;
         return this.http.get(articlesPerPageUrl).map( value => value.json() as NewsModel[]);
     }

     getArticle(id: number) {
        let articleUrl = this.apiUrl + id;
        return this.http.get(articleUrl).map( value => value.json() as ArticleModel);
     }

     createArticle(model: ArticleModel) {
        let articleUrl = this.apiUrl;
        return this.http.post(articleUrl, model);
     }

     deleteArticle(id: number) {
        let articleUrl = this.apiUrl + id;
        return this.http.delete(articleUrl);
     }

     updateArticle(id: number, model: ArticleModel) {
        let articleUrl = this.apiUrl + id;
        return this.http.put(articleUrl, model);
     }
}