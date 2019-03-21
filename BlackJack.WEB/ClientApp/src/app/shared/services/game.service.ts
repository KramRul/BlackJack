import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { GetAllPlayersPlayerView, PlayerGetAllPlayersPlayerViewItem } from '../entities/player.views/get-all-players.player.view';
import { StartGameView } from '../entities/game.views/start.game.view';
import { GetDetailsGameView } from '../entities/game.views/get-details.game.view';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private Url = `${environment.Base_URL}api/game/`;

  constructor(private http: HttpClient) {
  }

  index(): Observable<Array<PlayerGetAllPlayersPlayerViewItem>> {
    return this.http.get<GetAllPlayersPlayerView>(`${this.Url}index`).pipe(
      map((response: GetAllPlayersPlayerView) => {
        console.log(response);
        return response.players;
      }));
  }

  start(countOfBots: number): Observable<StartGameView> {
    return this.http.get<StartGameView>(`${this.Url}start?countOfBots=${countOfBots}`).pipe(
      map((response: StartGameView) => {
        console.log(response);
        return response;
      }));
  }

  GetDetails(gameId?: string): Observable<GetDetailsGameView> {
    return this.http.get<GetDetailsGameView>(`${this.Url}getDetails?gameId=${gameId}`).pipe(
      map((response: GetDetailsGameView) => {
        console.log(response);
        return response;
      }));
  }

  placeABet(bet?: number): Observable<any> {
    return this.http.get(`${this.Url}placeABet?bet=${bet}`);
  }

  hit(): Observable<any> {
    return this.http.get(`${this.Url}hit`);
  }

  stand(): Observable<any> {
    return this.http.get(`${this.Url}stand`);
  }
}
