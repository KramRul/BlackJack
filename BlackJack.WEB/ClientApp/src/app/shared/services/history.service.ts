import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { GetHistoryOfGamesHistoryView } from '../entities/history.views/get-history-of-games.history.view';
import { DetailsOfGameHistoryView } from '../entities/history.views/details-of-game.history.view';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private Url = `${environment.Base_URL}api/history/`;

  constructor(private http: HttpClient) {
  }

  index(): Observable<GetHistoryOfGamesHistoryView> {
    return this.http.get<GetHistoryOfGamesHistoryView>(`${this.Url}index`);
  }

  game(gameId: string): Observable<DetailsOfGameHistoryView> {
    return this.http.get<DetailsOfGameHistoryView>(`${this.Url}game?gameId=${gameId}`);
  }
}
