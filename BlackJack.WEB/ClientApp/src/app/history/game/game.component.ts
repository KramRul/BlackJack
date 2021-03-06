import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../../shared/services/history.service';
import { ActivatedRoute } from '@angular/router';
import { DetailsOfGameHistoryView } from '../../shared/entities/history.views/details-of-game.history.view';
import { SuiteType } from '../../shared/enums/suite-type';
import { RankType } from '../../shared/enums/rank-type';
import { GameStateType } from '../../shared/enums/game-state-type';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  public model: DetailsOfGameHistoryView = new DetailsOfGameHistoryView();
  public Suite = SuiteType;
  public Rank = RankType;
  public GameState = GameStateType;

  constructor(
    private historyService: HistoryService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    let gameId = this.route.snapshot.queryParamMap.get('gameId');
    this.historyService.game(gameId).subscribe(data => {
      this.model.game = data.game;
      this.model.game.player = data.game.player;
      this.model.playerAndBotSteps = data.playerAndBotSteps;
    });
  }
}
