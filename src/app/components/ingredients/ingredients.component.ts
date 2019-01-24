import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { Store, select } from '@ngrx/store';
import { Ingredient } from './../../ingredient/ingredient.model';
import * as IngredientActions from './../../ingredient/ingredient.actions';
import { AppState, IIngredientState } from './../../app.state';
import { selectIngredientList, selectSavingIngredient } from 'src/app/ingredient/ingredient.reducer';
import { FormGroup, FormControl } from '@angular/forms';
import { faSpinner, faTimes, faCheck } from '@fortawesome/pro-solid-svg-icons';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {

  // font awesome icons
  faSpinner = faSpinner;
  faTimes = faTimes;
  faCheck = faCheck;

  ingredients: Observable<Ingredient[]>;
  savingIngredient: Observable<boolean>;
  newIngredientForm = new FormGroup({
    title: new FormControl(''),
    blurb: new FormControl('')
  });
  editingIngredient: number;
  currentList: Ingredient[] = [];

  constructor(private store: Store<AppState>) { 
    this.ingredients = store.pipe(select(selectIngredientList));
    this.savingIngredient = store.pipe(select(selectSavingIngredient))
  }

  addIngredient() {
    this.store.dispatch(new IngredientActions.AddIngredient({
      id: null,
      title: this.newIngredientForm.value.title,
      blurb: this.newIngredientForm.value.blurb
    }));
    this.newIngredientForm.reset();
  }

  deleteIngredient(ingredientId: number) {
    this.store.dispatch(new IngredientActions.RemoveIngredient(ingredientId));
  }

  editingItem(ingredientId: number) {
    //console.log(ingredientId);
    this.editingIngredient = ingredientId;
    //this.currentlyEditing = ingredientId;
  }

  updateField(ingredientId: number, fieldName: string, newValue: string) {
    this.editingIngredient = undefined;
    const filtered = this.currentList.filter(i => i.id === ingredientId);
    if (filtered.length === 0) return;
    const ingredient = filtered[0];
    ingredient[fieldName] = newValue;
    this.store.dispatch(new IngredientActions.UpdateIngredient(ingredient));
  }

  ngOnInit() {
    this.store.select(selectIngredientList).subscribe(ingredients => {
      if (ingredients === undefined) this.store.dispatch(new IngredientActions.LoadIngredients());
      this.currentList = ingredients;
    });
  }

}
