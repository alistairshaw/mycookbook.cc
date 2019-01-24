import { Action, createSelector } from '@ngrx/store'
import { Ingredient } from './ingredient.model'
import * as IngredientActions from './ingredient.actions'
import { IIngredientState, AppState } from '../app.state';

const initialState: IIngredientState = {
    ingredients: undefined,
    selected: undefined,
    savingIngredient: false
};

const updateIngredient = function (ingredients: Ingredient[], updatedIngredient: Ingredient) {
    updatedIngredient.updating = true;
    return ingredients.map(i => {
        return i.id === updatedIngredient.id ? updatedIngredient : i;
    });
}

const selectIngredients = (state: AppState) => state.ingredients;
export const selectIngredientList = createSelector(selectIngredients, (state: IIngredientState) => state.ingredients);
export const selectSavingIngredient = createSelector(selectIngredients, (state: IIngredientState) => state.savingIngredient);

export function reducer(state: IIngredientState = initialState, action: IngredientActions.Actions) {

    switch (action.type) {
        case IngredientActions.ADD_INGREDIENT:
            return { ...state, savingIngredient: true };
        case IngredientActions.REMOVE_INGREDIENT:
            return { ...state, ingredients: [...state.ingredients].map(i => i.id !== action.payload ? i : { ...i, updating: true }) }
        case IngredientActions.UPDATE_INGREDIENT:
            return { ...state, ingredients: updateIngredient([...state.ingredients], action.payload), savingIngredient: true };
        case IngredientActions.INGREDIENT_ADDED:
            return { ...state, ingredients: [...state.ingredients, action.payload], selected: action.payload, savingIngredient: false };
        case IngredientActions.INGREDIENT_REMOVED:
            return { ...state, ingredients: [...state.ingredients].filter(i => i.id !== action.payload) }
        case IngredientActions.INGREDIENT_UPDATED:
            return {
                ...state, ingredients: [...state.ingredients].map(i => {
                    i.updating = false;
                    return i;
                })
            }
        case IngredientActions.INGREDIENTS_LOADED:
            return { ...state, ingredients: action.payload };
        default:
            return state;
    }
}