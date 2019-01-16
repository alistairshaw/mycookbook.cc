import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { Store, select } from '@ngrx/store';
import { Ingredient } from './../../ingredient/ingredient.model';
import * as IngredientActions from './../../ingredient/ingredient.actions';
import { AppState, IIngredientState } from './../../app.state';
import { selectIngredientList } from 'src/app/ingredient/ingredient.reducer';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {

  ingredients: Observable<Ingredient[]>;
  newIngredientForm = new FormGroup({
    title: new FormControl(''),
    blurb: new FormControl('')
  });

  constructor(private store: Store<AppState>) { 
    this.ingredients = store.pipe(select(selectIngredientList));
  }

  addIngredient() {
    this.store.dispatch(new IngredientActions.AddIngredient({
      id: null,
      title: this.newIngredientForm.value.title,
      blurb: this.newIngredientForm.value.blurb,
      deleting: false
    }));
    this.newIngredientForm.reset();
  }

  deleteIngredient(ingredientId: number) {
    this.store.dispatch(new IngredientActions.RemoveIngredient(ingredientId));
  }

  ngOnInit() {
    const ingredients = this.store.select(selectIngredientList).subscribe(ingredients => {
      if (ingredients === undefined) this.store.dispatch(new IngredientActions.LoadIngredients());
    });
  }

}
