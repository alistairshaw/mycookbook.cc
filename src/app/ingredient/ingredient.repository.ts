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

    load() {
        const url = `${this.BASE_URL}`;
        return this.http.get<any>(url, {
            headers: this.authService.getHeadersWithAuth()
        });
    }

    create(ingredient: Ingredient) {
        const url = `${this.BASE_URL}/create`;
        const body = new HttpParams()
            .set('title', ingredient.title)
            .set('blurb', ingredient.blurb);
        return this.http.post<Ingredient>(url, body.toString(), {
            headers: this.authService.getHeadersWithAuth()
                .set('Content-Type', 'application/x-www-form-urlencoded')
        });
    }

    delete(ingredientId: number): any {
        const url = `${this.BASE_URL}/` + ingredientId;
        return this.http.delete<any>(url, {
            headers: this.authService.getHeadersWithAuth()
        });
    }
}