import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { PlayersModel, PersonModel } from '../models/players.models';
import { environment } from '../environments/environment.prod';

@Injectable()
export class PlayersService {
    private apiUrl = environment.apiUrl + '/api/players/';

    constructor(private http: Http) { }

    getAllPlayers() {
        let playersUrl = this.apiUrl;
        return this.http.get(playersUrl).map( value => value.json() as PersonModel[]);
     }

     getPlayersPerPage(playersPerPage: number, page: number = 1) {
         let playesPerPageUrl = this.apiUrl + playersPerPage + '/' + page;
         return this.http.get(playesPerPageUrl).map( value => value.json() as PlayersModel[]);
     }

     getPlayer(id: number) {
        let playerUrl = this.apiUrl + id;
        return this.http.get(playerUrl).map( value => value.json() as PersonModel);
     }

     createPlayer(model: PersonModel) {
        let playerUrl = this.apiUrl;
        return this.http.post(playerUrl, model);
     }

     deletePlayer(id: number) {
        let playerUrl = this.apiUrl + id;
        return this.http.delete(playerUrl);
     }

     updatePlayer(id: number, model: PersonModel) {
        let playerUrl = this.apiUrl + id;
        return this.http.put(playerUrl, model);
     }
}
