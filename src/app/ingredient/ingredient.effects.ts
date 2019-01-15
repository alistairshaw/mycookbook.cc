import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Ingredient } from './ingredient.model';
import { Observable, of } from 'rxjs';
import * as IngredientActions from "./ingredient.actions";
import { mergeMap, map, catchError } from 'rxjs/operators';
import IngredientRepository from './ingredient.repository'
import { AddIngredient } from './ingredient.actions';

@Injectable()
export class IngredientEffects {

    constructor(
        private actions: Actions<AddIngredient>,
        private ingredientRepository: IngredientRepository
    ) { }

    @Effect()
    Create: Observable<Action> = this.actions.pipe(
        ofType(IngredientActions.ADD_INGREDIENT),
        mergeMap(action =>
            this.ingredientRepository.create(action.payload).pipe(
                // If successful, dispatch success action with result
                map(data => {
                    return { type: IngredientActions.INGREDIENT_ADDED, payload: data }
                }),
                // If request fails, dispatch failed action
                catchError(() => of({ type: IngredientActions.INGREDIENT_ERROR }))
            )
        )
    );
}