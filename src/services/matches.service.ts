import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { MatchModel } from '../models/match.models';
import { environment } from '../environments/environment.prod';

@Injectable()
export class MatchesService {
    private apiUrl = environment.apiUrl + '/api/matches/';

    constructor(private http: Http) { }

    getAllMatches() {
        let matchesUrl = this.apiUrl;
        return this.http.get(matchesUrl).map( value => value.json() as MatchModel[]);
     }

     getMatchesPerPage(matchesPerPage: number, page: number = 1) {
         let matchesPerPageUrl = this.apiUrl + matchesPerPage + '/' + page;
         return this.http.get(matchesPerPageUrl).map( value => value.json() as MatchModel[]);
     }

     getMatch(id: number) {
        let matchesUrl = this.apiUrl + id;
        return this.http.get(matchesUrl).map( value => value.json() as MatchModel);
     }

     createMatch(model: MatchModel) {
        let matchesUrl = this.apiUrl;
        return this.http.post(matchesUrl, model);
     }

     deleteMatch(id: number) {
        let matchesUrl = this.apiUrl + id;
        return this.http.delete(matchesUrl);
     }

     updateMatch(id: number, model: MatchModel) {
        let matchesUrl = this.apiUrl + id;
        return this.http.put(matchesUrl, model);
     }
}
