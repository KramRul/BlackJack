import { Component, OnInit } from '@angular/core';
import { GetAllPlayersPlayerView } from 'src/app/shared/entities/player.views/get-all-players.player.view';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();

  constructor() { }

  ngOnInit() {
  }

}
