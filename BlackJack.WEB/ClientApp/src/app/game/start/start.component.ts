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
  gameDetails?: GetDetailsGameView = new GetDetailsGameView();
  bet?: number;
  Suite = Suite;
  Rank = Rank;
  GameState = GameState;

  constructor(private gameService: GameService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.gameService.startGetDetails("").subscribe(data => {
      this.gameDetails.game = data.game;
      this.gameDetails.playerSteps = data.playerSteps;
      this.gameDetails.botsSteps = data.botsSteps;
    });
  }

  placeABet() {
    this.gameService.placeABet(this.bet).subscribe(() => {
      this.gameService.startGetDetails("").subscribe(data => {
        this.gameDetails.game = data.game;
        this.gameDetails.playerSteps = data.playerSteps;
        this.gameDetails.botsSteps = data.botsSteps;
      });
    });
  }

  hit() {
    this.gameService.hit().subscribe(() => {
      this.gameService.startGetDetails(this.gameDetails.game.id).subscribe(data => {
        this.gameDetails.game = data.game;
        this.gameDetails.playerSteps = data.playerSteps;
        this.gameDetails.botsSteps = data.botsSteps;
      });
    });    
  }

  stand() {
    this.gameService.stand().subscribe(() => {
      this.gameService.startGetDetails(this.gameDetails.game.id).subscribe(data => {
        this.gameDetails.game = data.game;
        this.gameDetails.playerSteps = data.playerSteps;
        this.gameDetails.botsSteps = data.botsSteps;
      });
    });   
  }
}
