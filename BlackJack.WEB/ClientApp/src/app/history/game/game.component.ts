import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../../shared/services/history.service';
import { Router, ActivatedRoute } from '@angular/router';
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
    var gameId = this.route.snapshot.queryParamMap.get('data');
    this.historyService.game(gameId).subscribe(data => {
      this.model.game = data.game;
      this.model.botsSteps = data.botsSteps;
      this.model.playerSteps = data.playerSteps;
      this.model.playerAndBotSteps = data.playerAndBotSteps;
    });
  }
}
