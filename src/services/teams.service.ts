import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { TeamsModel } from '../models/teams.model';

@Injectable()
export class TeamsService {
    private apiUrl = '/api/teams/';

    constructor(private http: Http) { }

    getAllTeams() {
        let teamsUrl = this.apiUrl;
        return this.http.get(teamsUrl).map( value => value.json() as TeamsModel[]);
     }

     getTeamsPerPage(teamsPerPage: number, page: number = 1) {
         let teamsPerPageUrl = this.apiUrl + teamsPerPage + '/' + page;
         return this.http.get(teamsPerPageUrl).map( value => value.json() as TeamsModel[]);
     }

     getTeam(id: number) {
        let teamUrl = this.apiUrl + id;
        return this.http.get(teamUrl).map( value => value.json() as TeamsModel);
     }

     createTeam(model: TeamsModel) {
        let teamUrl = this.apiUrl;
        return this.http.post(teamUrl, model);
     }

     deleteTeam(id: number) {
        let teamUrl = this.apiUrl + id;
        return this.http.delete(teamUrl);
     }

     updateTeam(id: number, model: TeamsModel) {
        let teamUrl = this.apiUrl + id;
        return this.http.put(teamUrl, model);
     }
}