import { Component, OnInit } from '@angular/core';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validationErrors: string;
  model: RegisterAccountView = new RegisterAccountView();

  constructor(private accountService: AccountService, private router: Router) {

  }

  login() {
    this.accountService.login(this.model).subscribe(data => this.router.navigateByUrl("/"), error => this.validationErrors = error );
  }

  ngOnInit() {
  }

}
