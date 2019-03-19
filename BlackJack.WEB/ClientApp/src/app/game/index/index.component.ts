import { Component, OnInit, AfterViewInit } from '@angular/core';
import { GetAllPlayersPlayerView } from 'src/app/shared/entities/player.views/get-all-players.player.view';
import { GameService } from 'src/app/shared/services/game.service';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { LocalStorageService } from 'src/app/shared/services/local-storage.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit{
  //modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();
  public countOfBots: number;
  public playerName: string;

  constructor(private gameService: GameService, private accountService: AccountService, private notifyService: NotificationService, private router: Router) {
    //this.gameService.index(this.modelPlayers).subscribe();
    console.log(new LocalStorageService<string>().getItem("accessToken"));
  }

  start(): void {
    this.gameService.start(this.countOfBots).subscribe(
      data => {
        console.log(data);
        this.router.navigate(["/game/start"]);      
      }
      , error => this.notifyService.showError(error)
    );
  }

  ngOnInit():void {
    this.accountService.getLoggedPlayerName().subscribe(data => {
      console.log(data);
      this.playerName = data;
    }
      , error => this.notifyService.showError(error)
    );
  }
}
