import { Component, OnInit } from '@angular/core';
import { LoginAccountView } from 'src/app/shared/entities/account.views/login.account.view';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  player: LoginAccountView = new LoginAccountView();
  constructor() { }

  ngOnInit() {
  }

}
