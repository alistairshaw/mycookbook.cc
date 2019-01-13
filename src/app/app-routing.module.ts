import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { IngredientsComponent } from './components/ingredients/ingredients.component';
import { RecipesComponent } from './components/recipes/recipes.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'ingredients', component: IngredientsComponent },
  { path: 'recipes', component: RecipesComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
