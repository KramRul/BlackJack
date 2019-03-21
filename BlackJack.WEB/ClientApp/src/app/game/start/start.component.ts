import { Component, OnInit } from '@angular/core';
import { GameService } from '../../shared/services/game.service';
import { SuiteType } from '../../shared/enums/suite-type';
import { RankType } from '../../shared/enums/rank-type';
import { GameStateType } from '../../shared/enums/game-state-type';
import { NotificationService } from '../../shared/services/notification.service';
import { GetDetailsByPlayerIdAndGameIdGameView } from 'src/app/shared/entities/game.views/get-details-by-player-id-and-game-id.game.view';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {
  public model: GetDetailsByPlayerIdAndGameIdGameView = new GetDetailsByPlayerIdAndGameIdGameView();
  public bet: number;
  public Suite = SuiteType;
  public Rank = RankType;
  public GameState = GameStateType;

  constructor(
    private gameService: GameService,
    private notifyService: NotificationService) {
  }

  ngOnInit(): void {
    this.gameService.GetDetails().subscribe(data => {
      this.model.game = data.game;
      this.model.playerSteps = data.playerSteps;
      this.model.botsSteps = data.botsSteps;
    });
  }

  placeABet(): void {
    this.gameService.placeABet(this.bet).subscribe(() => {
      this.gameService.GetDetails().subscribe(data => {
        this.model.game = data.game;
        this.model.playerSteps = data.playerSteps;
        this.model.botsSteps = data.botsSteps;
      });
    });
  }

  hit(): void {
    this.gameService.hit().subscribe(() => {
      this.gameService.GetDetails(this.model.game.id).subscribe(data => {
        this.model.game = data.game;
        this.model.playerSteps = data.playerSteps;
        this.model.botsSteps = data.botsSteps;
        this.showNotification();
      });
    });
  }

  stand(): void {
    this.gameService.stand().subscribe(() => {
      this.gameService.GetDetails(this.model.game.id).subscribe(data => {
        this.model.game = data.game;
        this.model.playerSteps = data.playerSteps;
        this.model.botsSteps = data.botsSteps;
        this.showNotification();
      });
    });
  }

  private showNotification(): void {
    if (this.model.game.wonName != '' && this.model.game.wonName != null)
      this.notifyService.showSuccess(`${this.model.game.wonName} WON`);
  }
}
