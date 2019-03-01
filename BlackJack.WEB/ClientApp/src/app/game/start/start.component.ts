import { Component, OnInit } from '@angular/core';
import { GameService } from '../../shared/services/game.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

  constructor(private gameService: GameService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    var res = this.route.snapshot.queryParamMap.get('data');
    console.log(res);
  }

}
