import { Component, OnInit, AfterViewInit } from '@angular/core';
import { GetAllPlayersPlayerView } from '../shared/entities/player.views/get-all-players.player.view';
import { GameService } from '../shared/services/game.service';
import { Router } from '@angular/router';
import { AccountService } from '../shared/services/account.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent {
  
}
