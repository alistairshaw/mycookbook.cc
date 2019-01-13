import { Ingredient } from './ingredient/ingredient.model';
import { User } from './user/user.model';

export interface IAuthState {
    isAuthenticated: boolean,
    user: User
}

export interface IIngredientState {
    ingredients: Ingredient[],
    selected: Ingredient
}

export interface AppState {
    readonly ingredients: IIngredientState;
    readonly auth: IAuthState;
}