import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';
import { GetAllPlayersPlayerView } from '../entities/player.views/get-all-players.player.view';
import { StartGameResultView } from '../entities/game.views/start-result.game.view';
import { StartGameView } from '../entities/game.views/start.game.view';
import { GetDetailsGameView } from '../entities/game.views/get-details.game.view';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private url = "/game/";

  constructor(private http: HttpClient) {
  }

  index(model: GetAllPlayersPlayerView) {
    return this.http.get<GetAllPlayersPlayerView>(this.url + "index").pipe(
      map((response: GetAllPlayersPlayerView) => {
        console.log(response);
        model.players = response.players;
      }));
  }

  start(countOfBots: number, playerName: string) {
    return this.http.get<StartGameView>(this.url + "start" + "?" + 'countOfBots=' + countOfBots + '&playerName=' + playerName).pipe(
      map((response: StartGameView) => {
        console.log(response);
        //model = response;
        return response;
      }));
  }

  startGetDetails(model: GetDetailsGameView, playerId: string) {
    return this.http.get<GetDetailsGameView>(this.url + "GetDetails").pipe(
      map((response: GetDetailsGameView) => {
        console.log(response);
        model.game = response.game;
        model.playerSteps = response.playerSteps;
        model.botsSteps = response.botsSteps;
        return response;
      }));
  }
}
