import { Action } from '@ngrx/store';


export enum UserActions {
    LOGIN = '[Auth] Login',
    LOGIN_SUCCESS = '[Auth] Login Success',
    LOGIN_FAILURE = '[Auth] Login Failure'
}

export class LogIn implements Action {
    readonly type = UserActions.LOGIN;
    constructor(public payload: any) { }
}

export class LogInSuccess implements Action {
    readonly type = UserActions.LOGIN_SUCCESS;
    constructor(public payload: any) { }
}

export class LogInFailure implements Action {
    readonly type = UserActions.LOGIN_FAILURE;
    constructor(public payload: any) { }
}

export type Actions = LogIn | LogInSuccess | LogInFailure;