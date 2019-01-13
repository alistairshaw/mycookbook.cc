import { Action, createSelector } from '@ngrx/store'
import { Ingredient } from './ingredient.model'
import * as IngredientActions from './ingredient.actions'
import { IIngredientState, AppState } from '../app.state';

const initialState: IIngredientState = {
    ingredients: [{
        id: 1,
        title: 'Test One',
        blurb: ''
    }],
    selected: {
        id: 1,
        title: 'Test One',
        blurb: ''
    }
};

const selectIngredients = (state: AppState) => state.ingredients;
export const selectIngredientList = createSelector(selectIngredients, (state: IIngredientState) => state.ingredients);

export function reducer(state: IIngredientState = initialState, action: IngredientActions.Actions) {

    switch (action.type) {
        case IngredientActions.ADD_INGREDIENT:
            return { ...state, ingredients: [...state.ingredients, action.payload], selected: action.payload};
        default:
            return state;
    }
}