import { Injectable } from '@angular/core'
import { Action } from '@ngrx/store'
import { Ingredient } from './ingredient.model'

export const ADD_INGREDIENT = '[INGREDIENT] Add'
export const REMOVE_INGREDIENT = '[INGREDIENT] Remove'

export class AddIngredient implements Action {
    readonly type = ADD_INGREDIENT

    constructor(public payload: Ingredient) { }
}

export class RemoveIngredient implements Action {
    readonly type = REMOVE_INGREDIENT

    constructor(public payload: number) { }
}

// Section 4
export type Actions = AddIngredient | RemoveIngredient