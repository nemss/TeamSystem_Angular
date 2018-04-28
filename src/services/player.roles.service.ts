import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { ModelRole } from '../models/roles.model';
import { environment } from '../environments/environment.prod';

@Injectable()
export class PlayerRolesService {
    private apiUrl = environment.apiUrl + '/api/teams/';

    constructor(private http: Http) { }

    getAllRoles() {
        let rolesUrl = this.apiUrl;
        return this.http.get(rolesUrl).map( value => value.json() as ModelRole[]);
     }

     getRole(id: number) {
        let roleUrl = this.apiUrl + id;
        return this.http.get(roleUrl).map( value => value.json() as ModelRole);
     }
}