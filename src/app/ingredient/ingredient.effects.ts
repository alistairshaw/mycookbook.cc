import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Ingredient } from './ingredient.model';
import { Observable, of } from 'rxjs';
import * as IngredientActions from "./ingredient.actions";
import { mergeMap, map, catchError, switchMap } from 'rxjs/operators';
import IngredientRepository from './ingredient.repository'
import { AddIngredient, RemoveIngredient, LoadIngredients } from './ingredient.actions';

@Injectable()
export class IngredientEffects {

    constructor(
        private actions: Actions<AddIngredient|LoadIngredients|RemoveIngredient>,
        private ingredientRepository: IngredientRepository
    ) { }

    @Effect()
    Load: Observable<Action> = this.actions.pipe(
        ofType(IngredientActions.LOAD_INGREDIENTS),
        switchMap(action =>
            this.ingredientRepository.load().pipe(
                map(data => {
                    return { type: IngredientActions.INGREDIENTS_LOADED, payload: data.ingredients };
                }),
                catchError(() => of({ type: IngredientActions.INGREDIENT_ERROR }))
            )
        )
    )

    @Effect()
    Create: Observable<Action> = this.actions.pipe(
        ofType(IngredientActions.ADD_INGREDIENT),
        mergeMap(action =>
            this.ingredientRepository.create(action.payload).pipe(
                map(data => {
                    return { type: IngredientActions.INGREDIENT_ADDED, payload: data };
                }),
                catchError(() => of({ type: IngredientActions.INGREDIENT_ERROR }))
            )
        )
    );

    @Effect()
    Remove: Observable<Action> = this.actions.pipe(
        ofType(IngredientActions.REMOVE_INGREDIENT),
        mergeMap(action => this.ingredientRepository.delete(action.payload).pipe(
            map(data => {
                return { type: IngredientActions.INGREDIENT_REMOVED, payload: action.payload };
            }),
            catchError(() => of({ type: IngredientActions.INGREDIENT_ERROR }))
        ))
    )
}