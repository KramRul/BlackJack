import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { map } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private url = "/account/";

  constructor(private http: HttpClient) {
  }

  isSignedIn() {
    if (localStorage.getItem("accessToken") != null)
      return true;
    else
      return false;
  }

  login(model: LoginAccountView) {
    return this.http.post<LoginAccountResponseView>(this.url + "login", model).pipe(
      map((response: LoginAccountResponseView) => {
        console.log(response);
        localStorage.setItem("accessToken", response.accessToken);
      }));
  }

  logout() {
    return this.http.post(this.url + "logout", null).pipe(
      map((response: any) => {
        console.log(response);
        localStorage.removeItem("accessToken");
      }));
  }

  getLoggedPlayerName() {
    return this.http.post<string>(this.url + "getLoggedPlayerName", null).pipe(
      map((response: any) => {
        console.log(response);
        return response;
      }));
  }

  register(model: RegisterAccountView) {
    return this.http.post(this.url + "register", model).pipe();
  }
}
