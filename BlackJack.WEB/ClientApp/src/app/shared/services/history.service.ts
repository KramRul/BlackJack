import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { GetHistoryOfGamesHistoryView } from '../entities/history.views/get-history-of-games.history.view';
import { DetailsOfGameHistoryView } from '../entities/history.views/details-of-game.history.view';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private url = "/history/";

  constructor(private http: HttpClient) {
  }

  index() {
    return this.http.get<GetHistoryOfGamesHistoryView>(this.url + "index").pipe(
      map((response: GetHistoryOfGamesHistoryView) => {
        console.log(response);
        return response;
      }));
  }

  game(gameId: string) {
    return this.http.get<DetailsOfGameHistoryView>(this.url + "game" + "?" + 'gameId=' + gameId).pipe(
      map((response: DetailsOfGameHistoryView) => {
        console.log(response);
        return response;
      }));
  }
}
