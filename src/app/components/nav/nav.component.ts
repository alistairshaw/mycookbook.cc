import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { selectIsAuthenticated } from 'src/app/user/user.reducer';
import * as UserActions from './../../user/user.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  appTitle: string = 'My Cookbook';

  isAuthenticated: Observable<boolean>;

  constructor(private store: Store<AppState>, private router: Router) {
    this.isAuthenticated = store.pipe(select(selectIsAuthenticated));
  }

  logOut() {
    this.router.navigate(['']);
    this.store.dispatch(new UserActions.LogOut());
  }

  ngOnInit() {
  }

}
