import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Ingredient } from "./ingredient.model";
import { from } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';
import { Injectable } from '@angular/core';

@Injectable()
export default class IngredientRepository {

    private BASE_URL = 'https://localhost:5001/api/ingredient';

    constructor(
        private http: HttpClient,
        private authService: AuthService
    ) { }

    create(ingredient: Ingredient) {
        const url = `${this.BASE_URL}/create`;
        const body = new HttpParams()
            .set('title', ingredient.title)
            .set('blurb', ingredient.blurb);
        return this.http.post<Ingredient>(url, body.toString(), {
            headers: new HttpHeaders()
                .set('Content-Type', 'application/x-www-form-urlencoded')
                .set("Authorization", "Basic " + btoa(this.authService.getUser() + ':' + this.authService.getToken()))
        });
    }

}