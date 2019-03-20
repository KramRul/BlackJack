import { Component, OnInit } from '@angular/core';
import { GameService } from '../../shared/services/game.service';
import { Router, ActivatedRoute } from '@angular/router';
import { GetDetailsGameView } from '../../shared/entities/game.views/get-details.game.view';
import { Suite } from '../../shared/enums/suite';
import { Rank } from '../../shared/enums/rank';
import { GameState } from '../../shared/enums/game-state';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {
  public model: GetDetailsGameView = new GetDetailsGameView();
  public bet: number;
  public Suite = Suite;
  public Rank = Rank;
  public GameState = GameState;

  constructor(private gameService: GameService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.gameService.startGetDetails("").subscribe(data => {
      this.model.game = data.game;
      this.model.playerSteps = data.playerSteps;
      this.model.botsSteps = data.botsSteps;
    });
  }

  placeABet(): void {
    this.gameService.placeABet(this.bet).subscribe(() => {
      this.gameService.startGetDetails("").subscribe(data => {
        this.model.game = data.game;
        this.model.playerSteps = data.playerSteps;
        this.model.botsSteps = data.botsSteps;
      });
    });
  }

  hit(): void {
    this.gameService.hit().subscribe(() => {
      this.gameService.startGetDetails(this.model.game.id).subscribe(data => {
        this.model.game = data.game;
        this.model.playerSteps = data.playerSteps;
        this.model.botsSteps = data.botsSteps;
      });
    });
  }

  stand(): void {
    this.gameService.stand().subscribe(() => {
      this.gameService.startGetDetails(this.model.game.id).subscribe(data => {
        this.model.game = data.game;
        this.model.playerSteps = data.playerSteps;
        this.model.botsSteps = data.botsSteps;
      });
    });
  }
}
