import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../../shared/services/history.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DetailsOfGameHistoryView } from '../../shared/entities/history.views/details-of-game.history.view';
import { Suite } from '../../shared/enums/suite';
import { Rank } from '../../shared/enums/rank';
import { GameState } from '../../shared/enums/game-state';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit { 
  public model: DetailsOfGameHistoryView = new DetailsOfGameHistoryView();
  public Suite = Suite;
  public Rank = Rank;
  public GameState = GameState;

  constructor(private historyService: HistoryService, private router: Router, private route: ActivatedRoute) { }

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
