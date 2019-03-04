import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private url = "/account/";

  constructor(private http: HttpClient) {
  }

  login(model: LoginAccountView) {
    return this.http.post<LoginAccountResponseView>(this.url + "login", model).pipe(
      map((response: LoginAccountResponseView) =>
      {
        console.log(response);
        localStorage.setItem("accessToken", response.accessToken);
      }));
  }

  logout() {
    return this.http.post(this.url + "logout",null).pipe(
      map((response: any) => {
        console.log(response);
        localStorage.removeItem("accessToken");
      }));
  }

  register(model: RegisterAccountView) {
    return this.http.post(this.url + "register", model).pipe();
  }
}
