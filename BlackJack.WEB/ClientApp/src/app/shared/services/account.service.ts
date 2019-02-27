import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SharedModule } from '../../shared/shared.module';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AccountService {

  private url = "/api/account";

  constructor(private http: HttpClient) {
  }

  login(model: LoginAccountView) {
    return this.http.post(this.url, model, httpOptions);
  }

  register(model: RegisterAccountView) {
    return this.http.post(this.url, model, httpOptions);
  }
}
