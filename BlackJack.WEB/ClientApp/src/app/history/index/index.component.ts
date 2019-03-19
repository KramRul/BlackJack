import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../../shared/services/history.service';
import { GetHistoryOfGamesHistoryView } from '../../shared/entities/history.views/get-history-of-games.history.view';
import { Router } from '@angular/router';
import { GameState } from '../../shared/enums/game-state';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  public GameState = GameState;
  public model: GetHistoryOfGamesHistoryView = new GetHistoryOfGamesHistoryView();

  constructor(private historyService: HistoryService, private router: Router) { }

  ngOnInit(): void {
    this.historyService.index().subscribe(data => {
      this.model.games = data.games;
    });
  }

  game(gameId: string): void {
    this.router.navigate(["/history/game"], { queryParams: { data: gameId } });
  }
}
