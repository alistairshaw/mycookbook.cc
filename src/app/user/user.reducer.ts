import { UserActions, Actions } from './user.actions';
import { State, createSelector } from '@ngrx/store';
import { AuthService } from '../services/auth/auth.service';
import { IAuthState, AppState } from '../app.state';

const initialState: IAuthState = {
    isAuthenticated: false,
    user: null
}

const selectAuth = (state: AppState) => state.auth;
export const selectIsAuthenticated = createSelector(selectAuth, (state: IAuthState) => state.isAuthenticated);

export function reducer(state: IAuthState = initialState, action: Actions) {
    switch (action.type) {
        case UserActions.LOGIN_SUCCESS:
            console.log("LOGIN SUCCESS");
            return { ...state, isAuthenticated: true, user: action.payload};
        case UserActions.LOGIN_FAILURE:
            console.log("LOGIN FAIL");
            return { ...state, isAuthenticated: false, user: null };
        default:
            return state;
    }
}