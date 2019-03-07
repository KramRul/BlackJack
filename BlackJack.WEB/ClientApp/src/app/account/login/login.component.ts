import { Component, OnInit } from '@angular/core';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';
import { GetAllPlayersPlayerView } from '../../shared/entities/player.views/get-all-players.player.view';
import { GameService } from '../../shared/services/game.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  modelPlayers: GetAllPlayersPlayerView = new GetAllPlayersPlayerView();
  validationErrors: string;
  model: RegisterAccountView = new RegisterAccountView();

  constructor(private accountService: AccountService, private gameService: GameService, private router: Router) {
    this.gameService.index(this.modelPlayers).subscribe();
  }

  login() {
    this.accountService.login(this.model).subscribe(data => this.router.navigateByUrl("/"), error => this.validationErrors = error );
  }

  ngOnInit() {
  }
}
