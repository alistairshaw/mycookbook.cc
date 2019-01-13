import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { Observable } from 'rxjs';
import { User } from 'src/app/user/user.model';
import { selectIsAuthenticated } from 'src/app/user/user.reducer';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  isAuthenticated: Observable<boolean>;

  constructor(private store: Store<AppState>) { 
    this.isAuthenticated = store.pipe(select(selectIsAuthenticated));
  }

  ngOnInit() {
  }

}
