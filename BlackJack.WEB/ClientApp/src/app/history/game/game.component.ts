import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../../shared/services/history.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DetailsOfGameHistoryView } from '../../shared/entities/history.views/details-of-game.history.view';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit { 
  gameDetails?: DetailsOfGameHistoryView = new DetailsOfGameHistoryView();
  constructor(private historyService: HistoryService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    var gameId = this.route.snapshot.queryParamMap.get('data');
    this.historyService.game(gameId).subscribe(data => {
      this.gameDetails.game = data.game;
      this.gameDetails.botsSteps = data.botsSteps;
      this.gameDetails.playerSteps = data.playerSteps;
    });
  }
}
