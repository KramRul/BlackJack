import { Component, OnInit, NgZone } from '@angular/core';
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
import * as firebase from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { resolve } from 'q';
import { stringify } from 'querystring';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public players: GetAllPlayerView = new GetAllPlayerView();
  public model: LoginAccountView = new LoginAccountView();

  public loginForm = this.formBuilder.group({
    userName: ['', Validators.required],
    email: ['', [Validators.email]],
    password: ['', Validators.required]
  });

  constructor(
    private accountService: AccountService,
    private authService: AuthService,
    private zone: NgZone, 
    public afAuth: AngularFireAuth,
    private gameService: GameService,
    private notifyService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.gameService.index().subscribe(data => {
      this.players.players = data.players;
    });
  }

  login(): void {
    this.model.token = "";
    if(this.model.email != null && this.model.email != "") {
      this.loginWithEmailAndPassword();
    }  
    this.accountService.login(this.model).subscribe(
      data => this.router.navigateByUrl("/"),
      error => this.notifyService.showError(error)
    );
  }

  loginWithGoogle() {  
    let provider = new firebase.auth.GoogleAuthProvider();
    provider.addScope('profile');
    provider.addScope('email');
    this.afAuth.auth
    .signInWithPopup(provider)
    .then(async (userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();         
      model.token = await userData.user.getIdToken();
      this.accountService.loginWithGoogle(model).subscribe(
        data => this.zone.run(() => { this.router.navigateByUrl("/");}),
        error => this.notifyService.showError(error));
        resolve(userData);
    }, error => this.notifyService.showError(error))
    /*this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then((userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();
      model.token = userData.idToken;
      this.accountService.loginWithGoogle(model).subscribe(
        data => this.router.navigateByUrl("/"),
        error => this.notifyService.showError(error));
    });*/
  }

  loginWithFacebook() {
    let provider = new firebase.auth.FacebookAuthProvider();
    provider.addScope('email');
    this.afAuth.auth
    .signInWithPopup(provider)
    .then(async (userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();     
      model.token = await userData.user.getIdTokenResult().then(t=>t.token);
      this.accountService.loginWithFacebook(model).subscribe(
        data => this.zone.run(() => { this.router.navigateByUrl("/");}),
        error => this.notifyService.showError(error));
        resolve(userData);
    }, error => this.notifyService.showError(error))
    /*this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then((userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();
      model.token = userData.authToken;
      this.accountService.loginWithFacebook(model).subscribe(
        data => this.router.navigateByUrl("/"),
        error => this.notifyService.showError(error));
    });*/
  }

  loginWithGitHub() {
    let provider = new firebase.auth.GithubAuthProvider();
    provider.addScope('read:user');
    provider.addScope('user:email');
    this.afAuth.auth
    .signInWithPopup(provider)
    .then(async (userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();          
      model.token = await userData.user.getIdTokenResult().then(t=>t.token);
      model.name = userData.additionalUserInfo.username;
      this.accountService.loginWithGitHub(model).subscribe(
        data => this.zone.run(() => { this.router.navigateByUrl("/");}),
        error => this.notifyService.showError(error));
        resolve(userData);
    }, error => this.notifyService.showError(error))
    /*this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then((userData) => {
      let model: LoginExtendedAccountView = new LoginExtendedAccountView();
      model.token = userData.authToken;
      this.accountService.loginWithFacebook(model).subscribe(
        data => this.router.navigateByUrl("/"),
        error => this.notifyService.showError(error));
    });*/
  }

  loginWithEmailAndPassword() {
    return new Promise<any>((resolve, reject) => {
      firebase.auth().signInWithEmailAndPassword(this.model.email, this.model.password)
      .then(res => {
        this.notifyService.showSuccess("Successfully login with Email and Password");
        resolve(res);
      }, error => {
        this.notifyService.showError(error);
        reject(error);
      })
    })
  }
}
