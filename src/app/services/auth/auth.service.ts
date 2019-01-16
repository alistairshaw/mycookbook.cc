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

  clearToken(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getHeadersWithAuth(): HttpHeaders {
    const user = localStorage.getItem('user');
    const token = localStorage.getItem('token');
    return new HttpHeaders()
      .set("Authorization", "Basic " + btoa(user + ':' + token))
  }

  logIn(email: string, password: string): Observable<any> {
    const url = `${this.BASE_URL}/sign-in`;
    const body = new HttpParams()
      .set('email', email)
      .set('password', password);
    return this.http.post<User>(url, body.toString(), {
      headers: this.getHeadersWithAuth()
    });
  }

  logOut(): Observable<any> {
    const url = `${this.BASE_URL}/sign-out`;
    return this.http.get(url, {
      headers: this.getHeadersWithAuth()
    });
  }

  signUp(email: string, password: string): Observable<User> {
    const url = `${this.BASE_URL}/register`;
    return this.http.post<User>(url, { email, password },);
  }
}
