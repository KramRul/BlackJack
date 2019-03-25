import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetAllPlayerView } from '../entities/player.views/get-all.player.view';
import { StartGameView } from '../entities/game.views/start.game.view';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { GetDetailsByPlayerIdAndGameIdGameView } from '../entities/game.views/get-details-by-player-id-and-game-id.game.view';
import { HitGameView } from '../entities/game.views/hit.game.view';
import { PlaceABetGameView } from '../entities/game.views/place-a-bet.game.view';
import { StandGameView } from '../entities/game.views/stand.game.view';

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

  placeABet(bet?: number): Observable<PlaceABetGameView> {
    return this.http.get<PlaceABetGameView>(`${this.Url}placeABet?bet=${bet}`);
  }

  hit(): Observable<HitGameView> {
    return this.http.get<HitGameView>(`${this.Url}hit`);
  }

  stand(): Observable<StandGameView> {
    return this.http.get<StandGameView>(`${this.Url}stand`);
  }
}
