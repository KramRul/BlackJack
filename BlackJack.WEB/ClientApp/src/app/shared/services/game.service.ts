import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';
import { GetAllPlayersPlayerView } from '../entities/player.views/get-all-players.player.view';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class GameService {
  public static validationErrors: string;
  private url = "/game/";

  constructor(private http: HttpClient) {
  }

  index() {
    return this.http.get<GetAllPlayersPlayerView>(this.url + "index").pipe(
      map((response: GetAllPlayersPlayerView) => {
        console.log(response);
      }),
      catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error.error}`);
      //AccountService.validationErrors = error.error.error;
    }
    return new Observable();
  };
}
