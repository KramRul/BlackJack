import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { GetAllPlayerView, PlayerGetAllPlayerViewItem } from '../entities/player.views/get-all.player.view';
import { StartGameView } from '../entities/game.views/start.game.view';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { GetDetailsByPlayerIdAndGameIdGameView } from '../entities/game.views/get-details-by-player-id-and-game-id.game.view';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private Url = `${environment.Base_URL}api/game/`;

  constructor(private http: HttpClient) {
  }

  index(): Observable<GetAllPlayerView> {
    return this.http.get<GetAllPlayerView>(`${this.Url}index`);
  }

  start(countOfBots: number): Observable<StartGameView> {
    return this.http.get<StartGameView>(`${this.Url}start?countOfBots=${countOfBots}`);
  }

  getDetails(gameId?: string): Observable<GetDetailsByPlayerIdAndGameIdGameView> {
    if (gameId == undefined) gameId = "";
    return this.http.get<GetDetailsByPlayerIdAndGameIdGameView>(`${this.Url}getDetails?gameId=${gameId}`);
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
