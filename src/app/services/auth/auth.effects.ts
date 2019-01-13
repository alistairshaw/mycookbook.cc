import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { Router } from '@angular/router';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { map, take, switchMap, catchError, mergeMap } from 'rxjs/operators';
import { tap } from 'rxjs/operators';

import { AuthService } from './auth.service';
import {
    UserActions,
    LogIn, LogInSuccess, LogInFailure,
} from 'src/app/user/user.actions';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class AuthEffects {

    constructor(
        private actions: Actions<LogIn>,
        private authService: AuthService
    ) { }

    @Effect()
    LogIn: Observable<Action> = this.actions.pipe(
        ofType(UserActions.LOGIN),
        mergeMap(action =>
            this.authService.logIn(action.payload.email, action.payload.password).pipe(
                // If successful, dispatch success action with result
                map(data => {
                    this.authService.setToken(data.authToken.user, data.authToken.password)
                    return { type: UserActions.LOGIN_SUCCESS, payload: data.user }
                }),
                // If request fails, dispatch failed action
                catchError(() => of({ type: UserActions.LOGIN_FAILURE }))
            )
        )
    );

    @Effect()
    LogOut: Observable<Action> = this.actions.pipe(
        ofType(UserActions.LOGOUT),
        mergeMap(action =>
            this.authService.logOut().pipe(
                // If successful, dispatch success action with result
                map(data => {
                    this.authService.clearToken();
                    return { type: UserActions.LOGOUT_SUCCESS }
                }),
                // If request fails, dispatch failed action
                catchError(() => of({ type: UserActions.LOGIN_FAILURE }))
            )
        )
    );
}