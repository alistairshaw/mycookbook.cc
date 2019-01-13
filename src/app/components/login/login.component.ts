import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/user/user.model';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/app.state';
import { LogIn } from 'src/app/user/user.actions';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });

  constructor(
    private store: Store<AppState>
  ) {}

  ngOnInit() {
  }

  onSubmit(): void {
    this.store.dispatch(new LogIn(this.loginForm.value));
  }

}
