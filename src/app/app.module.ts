import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NavComponent } from './components/nav/nav.component';
import { IngredientsComponent } from './components/ingredients/ingredients.component';
import { RecipesComponent } from './components/recipes/recipes.component';
import { HomeComponent } from './components/home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { StoreModule } from '@ngrx/store';
import { reducer as ingredientReducer } from './ingredient/ingredient.reducer';
import { reducer as userReducer } from './user/user.reducer';
import { AuthService } from './services/auth/auth.service';
import { EffectsModule } from '@ngrx/effects';
import { AuthEffects } from './services/auth/auth.effects';
import { LoginComponent } from './components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthGuardService } from './services/auth/auth-guard.service';
import IngredientRepository from './ingredient/ingredient.repository';
import { IngredientEffects } from './ingredient/ingredient.effects';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    IngredientsComponent,
    RecipesComponent,
    HomeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    HttpClientModule,
    EffectsModule.forRoot([AuthEffects, IngredientEffects]),
    StoreModule.forRoot({
      ingredients: ingredientReducer,
      auth: userReducer
    }),
    FontAwesomeModule
  ],
  providers: [AuthService, AuthGuardService, IngredientRepository],
  bootstrap: [AppComponent]
})
export class AppModule { }
