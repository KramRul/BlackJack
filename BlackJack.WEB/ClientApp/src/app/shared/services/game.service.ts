import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { GetAllPlayersPlayerView } from '../entities/player.views/get-all-players.player.view';
import { StartGameView } from '../entities/game.views/start.game.view';
import { GetDetailsGameView } from '../entities/game.views/get-details.game.view';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private url = "api/game/";

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
        return response;
      }));
  }

  startGetDetails() {
    return this.http.get<GetDetailsGameView>(this.url + "getDetails").pipe(
      map((response: GetDetailsGameView) => {
        console.log(response);
        return response;
      }));
  }

  placeABet(bet?: number) {
    return this.http.get(this.url + "placeABet" + "?" + 'bet=' + bet).pipe();
  }

  hit() {
    return this.http.get(this.url + "hit").pipe();
  }

  stand() {
    return this.http.get(this.url + "stand").pipe();
  }
}
