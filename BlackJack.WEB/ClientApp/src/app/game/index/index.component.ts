import { Component, OnInit } from '@angular/core';
import { GetAllPlayersPlayerView } from 'src/app/shared/entities/player.views/get-all-players.player.view';
import { GameService } from 'src/app/shared/services/game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();

  constructor(private gameService: GameService, private router: Router) {
    this.gameService.index().subscribe(/*data => this.router.navigateByUrl("/")*/);
  }

  ngOnInit() {
  }

}
