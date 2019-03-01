import { Component, OnInit } from '@angular/core';
import { GetAllPlayersPlayerView } from 'src/app/shared/entities/player.views/get-all-players.player.view';
import { GameService } from 'src/app/shared/services/game.service';
import { Router } from '@angular/router';
import { StartGameResultView } from 'src/app/shared/entities/game.views/start-result.game.view';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();
  modelStartResponse: StartGameResultView = new StartGameResultView();
  countOfBots: number;
  playerName: string;
  player: object;

  constructor(private gameService: GameService, private router: Router) {
    this.gameService.index(this.modelPlayers).subscribe(/*data => this.router.navigateByUrl("/")*/);
  }

  start() {
    var dxb = this.player;
    this.gameService.start(this.modelStartResponse, this.countOfBots, this.playerName).subscribe(data => this.router.navigateByUrl("/game/start"));
  }

  ngOnInit() {
  }

}
