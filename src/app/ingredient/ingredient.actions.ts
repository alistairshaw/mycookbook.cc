import { Injectable } from '@angular/core'
import { Action } from '@ngrx/store'
import { Ingredient } from './ingredient.model'

export const ADD_INGREDIENT = '[INGREDIENT] Add'
export const REMOVE_INGREDIENT = '[INGREDIENT] Remove'
export const INGREDIENT_ADDED = '[INGREDIENT] Added'
export const INGREDIENT_REMOVED = '[INGREDIENT] Removed'
export const INGREDIENT_ERROR = '[INGREDIENT] Error'

export class AddIngredient implements Action {
    readonly type = ADD_INGREDIENT
    constructor(public payload: Ingredient) { }
}

export class RemoveIngredient implements Action {
    readonly type = REMOVE_INGREDIENT
    constructor(public payload: number) { }
}

export class IngredientAdded implements Action {
    readonly type = INGREDIENT_ADDED;
    constructor(public payload: Ingredient) { }
}

export class IngredientRemoved implements Action {
    readonly type = INGREDIENT_REMOVED;
    constructor(public payload: any) { }
}

export class IngredientError implements Action {
    readonly type = INGREDIENT_ERROR;
    constructor(public payload: any) { }
}

export type Actions = AddIngredient | RemoveIngredient | IngredientAdded | IngredientRemoved