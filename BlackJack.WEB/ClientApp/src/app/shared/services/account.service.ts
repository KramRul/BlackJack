import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private url = "/account/";

  constructor(private http: HttpClient) {
  }

  login(model: LoginAccountView) {
    return this.http.post<LoginAccountResponseView>(this.url + "login", model, httpOptions).pipe(
      map((response: LoginAccountResponseView) =>
      {
        console.log(response);
        sessionStorage.setItem("accessToken", response.accessToken);
      }),
      catchError(this.handleError('login', [])));
  }

  register(model: RegisterAccountView) {
    return this.http.post(this.url + "register", model, httpOptions);
  }

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any) => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}
