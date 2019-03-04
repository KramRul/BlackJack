import { Component, OnInit } from '@angular/core';
import { GameService } from '../../shared/services/game.service';
import { Router, ActivatedRoute } from '@angular/router';
import { GetDetailsGameView } from '../../shared/entities/game.views/get-details.game.view';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {
  gameDetails?: GetDetailsGameView = new GetDetailsGameView();
  constructor(private gameService: GameService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    var playerId = this.route.snapshot.queryParamMap.get('data');
    console.log(playerId);
    this.gameService.startGetDetails(this.gameDetails, playerId).subscribe();
  }

}
