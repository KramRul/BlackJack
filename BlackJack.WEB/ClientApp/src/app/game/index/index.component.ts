import { Component, OnInit, AfterViewInit } from '@angular/core';
import { GetAllPlayersPlayerView } from 'src/app/shared/entities/player.views/get-all-players.player.view';
import { GameService } from 'src/app/shared/services/game.service';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit{
  modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();
  validationErrors: string;
  countOfBots: number;
  playerName: string;

  constructor(private gameService: GameService, private accountService: AccountService, private router: Router) {
    this.gameService.index(this.modelPlayers).subscribe();
  }

  start() {
    this.gameService.start(this.countOfBots, this.playerName).subscribe(
      data => {
        console.log(data);
        this.router.navigate(["/game/start"]);      
      }
      , error => this.validationErrors = error
    );
  }

  ngOnInit() {
  }
}
