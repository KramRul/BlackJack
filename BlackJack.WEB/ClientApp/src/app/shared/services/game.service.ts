import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { GetAllPlayersPlayerView } from '../entities/player.views/get-all-players.player.view';
import { StartGameView } from '../entities/game.views/start.game.view';
import { GetDetailsGameView } from '../entities/game.views/get-details.game.view';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private Url = `${environment.Base_URL}api/game/`;

  constructor(private http: HttpClient) {
  }

  index(model: GetAllPlayersPlayerView) {
    return this.http.get<GetAllPlayersPlayerView>(`${this.Url}index`).pipe(
      map((response: GetAllPlayersPlayerView) => {
        console.log(response);
        model.players = response.players;
      }));
  }

  start(countOfBots: number) {
    return this.http.get<StartGameView>(`${this.Url}start?countOfBots=${countOfBots}`).pipe(
      map((response: StartGameView) => {
        console.log(response);
        return response;
      }));
  }

  startGetDetails(gameId: string) {
    return this.http.get<GetDetailsGameView>(`${this.Url}getDetails?gameId=${gameId}`).pipe(
      map((response: GetDetailsGameView) => {
        console.log(response);
        return response;
      }));
  }

  placeABet(bet?: number) {
    return this.http.get(`${this.Url}placeABet?bet=${bet}`);
  }

  hit() {
    return this.http.get(`hit`);
  }

  stand() {
    return this.http.get(`${this.Url}stand`);
  }
}
