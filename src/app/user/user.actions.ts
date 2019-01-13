import { Action } from '@ngrx/store';


export enum UserActions {
    LOGIN = '[Auth] Login',
    LOGOUT = '[Auth] Logout',
    LOGIN_SUCCESS = '[Auth] Login Success',
    LOGIN_FAILURE = '[Auth] Login Failure',
    LOGOUT_SUCCESS = '[Auth] Logout Success'
}

export class LogIn implements Action {
    readonly type = UserActions.LOGIN;
    constructor(public payload: any) { }
}

export class LogOut implements Action {
    readonly type = UserActions.LOGOUT;
    constructor() { }
}

export class LogInSuccess implements Action {
    readonly type = UserActions.LOGIN_SUCCESS;
    constructor(public payload: any) { }
}

export class LogInFailure implements Action {
    readonly type = UserActions.LOGIN_FAILURE;
    constructor(public payload: any) { }
}

export class LogOutSuccess implements Action {
    readonly type = UserActions.LOGOUT_SUCCESS;
    constructor(public payload: any) { }
}

export type Actions = LogIn | LogOut | LogInSuccess | LogInFailure | LogOutSuccess;