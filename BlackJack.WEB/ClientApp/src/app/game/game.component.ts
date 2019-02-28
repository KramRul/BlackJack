import { Component, OnInit } from '@angular/core';
import { GetAllPlayersPlayerView } from '../shared/entities/player.views/get-all-players.player.view';
import { GameService } from '../shared/services/game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  constructor() {

  }

  ngOnInit() {
  }

}
