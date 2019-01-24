import { Injectable } from '@angular/core'
import { Action } from '@ngrx/store'
import { Ingredient } from './ingredient.model'

export const LOAD_INGREDIENTS = '[INGREDIENT] Load';
export const ADD_INGREDIENT = '[INGREDIENT] Add';
export const REMOVE_INGREDIENT = '[INGREDIENT] Remove';
export const UPDATE_INGREDIENT = '[INGREDIENT] Update';

export const INGREDIENTS_LOADED = '[INGREDIENT] Loaded';
export const INGREDIENT_ADDED = '[INGREDIENT] Added';
export const INGREDIENT_REMOVED = '[INGREDIENT] Removed';
export const INGREDIENT_UPDATED = '[INGREDIENT] Updated';
export const INGREDIENT_ERROR = '[INGREDIENT] Error';

export class LoadIngredients implements Action {
    readonly type = LOAD_INGREDIENTS;
}

export class AddIngredient implements Action {
    readonly type = ADD_INGREDIENT;
    constructor(public payload: Ingredient) { }
}

export class RemoveIngredient implements Action {
    readonly type = REMOVE_INGREDIENT;
    constructor(public payload: number) { }
}

export class UpdateIngredient implements Action {
    readonly type = UPDATE_INGREDIENT;
    constructor(public payload: Ingredient) { }
}

export class IngredientsLoaded implements Action {
    readonly type = INGREDIENTS_LOADED;
    constructor(public payload: Ingredient[]) { }
}

export class IngredientAdded implements Action {
    readonly type = INGREDIENT_ADDED;
    constructor(public payload: Ingredient) { }
}

export class IngredientRemoved implements Action {
    readonly type = INGREDIENT_REMOVED;
    constructor(public payload: number) { }
}

export class IngredientUpdated implements Action {
    readonly type = INGREDIENT_UPDATED;
    constructor(public payload: Ingredient) { }
}

export class IngredientError implements Action {
    readonly type = INGREDIENT_ERROR;
    constructor(public payload: any) { }
}

export type Actions = AddIngredient | RemoveIngredient | UpdateIngredient | IngredientAdded | IngredientRemoved | IngredientsLoaded | IngredientUpdated