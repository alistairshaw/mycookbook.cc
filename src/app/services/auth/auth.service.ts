import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/user/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private BASE_URL = 'https://localhost:5001/api/auth';

  constructor(private http: HttpClient) { }

  setToken(user: string, token: string): void {
    localStorage.setItem('user', user);
    localStorage.setItem('token', token);
  }

  getToken(): string {
    return localStorage.getItem('token');
  }

  getUser(): string {
    return localStorage.getItem('user');
  }

  logIn(email: string, password: string): Observable<any> {
    const url = `${this.BASE_URL}/sign-in`;
    const body = new HttpParams()
      .set('email', email)
      .set('password', password);
    return this.http.post<User>(url, body.toString(), {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/x-www-form-urlencoded')
    });
  }

  signUp(email: string, password: string): Observable<User> {
    const url = `${this.BASE_URL}/register`;
    return this.http.post<User>(url, { email, password });
  }
}
