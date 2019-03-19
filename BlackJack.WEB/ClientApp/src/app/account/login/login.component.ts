import { Component, OnInit } from '@angular/core';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';
import { GetAllPlayersPlayerView } from '../../shared/entities/player.views/get-all-players.player.view';
import { GameService } from '../../shared/services/game.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();
  public model: RegisterAccountView = new RegisterAccountView();

  constructor(private accountService: AccountService, private gameService: GameService, private notifyService: NotificationService, private router: Router) {
  }

  ngOnInit(): void {
    this.gameService.index(this.modelPlayers).subscribe();
  }

  login(): void {
    this.accountService.login(this.model).subscribe(data => this.router.navigateByUrl("/"), error => this.notifyService.showError(error));
  }
}
