import { Component, OnInit } from '@angular/core';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';
import { GetAllPlayerView } from '../../shared/entities/player.views/get-all.player.view';
import { GameService } from '../../shared/services/game.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { FormBuilder, Validators } from '@angular/forms';
import { FacebookLoginProvider, GoogleLoginProvider, LinkedInLoginProvider } from "angularx-social-login";
import { AuthService } from "angularx-social-login";
import { SocialUser } from "angularx-social-login";
import { LoginAccountView } from 'src/app/shared/entities/account.views/login.account.view';
import { debug } from 'util';
import { LoginExtendedAccountView } from 'src/app/shared/entities/account.views/login-extended-account.view';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public players: GetAllPlayerView = new GetAllPlayerView();
  public model: RegisterAccountView = new RegisterAccountView();
  private user: SocialUser;
  private loggedIn: boolean;

  public loginForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(
    private accountService: AccountService,
    private authService: AuthService,
    private gameService: GameService,
    private notifyService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.gameService.index().subscribe(data => {
      this.players.players = data.players;
    });
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
    });
  }

  login(): void {
    this.model.token = "";
    this.accountService.login(this.model).subscribe(
      data => this.router.navigateByUrl("/"),
      error => this.notifyService.showError(error)
    );
  }

  loginWithGoogle() {  
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then((userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();
      model.token = userData.idToken;
      this.accountService.loginWithGoogle(model).subscribe(
        data => this.router.navigateByUrl("/"),
        error => this.notifyService.showError(error));
    });
  }

  loginWithFacebook() {
    this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then((userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();
      model.token = userData.authToken;
      this.accountService.loginWithFacebook(model).subscribe(
        data => this.router.navigateByUrl("/"),
        error => this.notifyService.showError(error));
    });
  }
}
