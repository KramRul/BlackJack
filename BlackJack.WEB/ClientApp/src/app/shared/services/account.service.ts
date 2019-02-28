import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
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
  public static validationErrors: string;
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
    return this.http.post(this.url + "register", model, httpOptions).pipe(
      //catchError(this.handleError('register', []))
      catchError(this.handleError1)
    );
  }

  private handleError1(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error.error}`);
      AccountService.validationErrors = error.error.error;
    }
    // return an ErrorObservable with a user-facing error message
    return new Observable();
  };

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any) => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}
