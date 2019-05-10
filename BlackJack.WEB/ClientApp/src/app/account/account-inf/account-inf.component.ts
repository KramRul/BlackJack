import { Component, OnInit, NgZone } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { AuthService } from 'angularx-social-login';
import { AngularFireAuth } from '@angular/fire/auth';
import { GameService } from 'src/app/shared/services/game.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { GetCurrentUserInfoAccountView } from 'src/app/shared/entities/account.views/get-current-user-info.account.view';
import * as firebase from 'firebase/app';
import { resolve } from 'q';
import { environment } from 'src/environments/environment.prod';
import { UpdateEmailAccountView } from 'src/app/shared/entities/account.views/update.email.account.view';

const actionCodeSettings = {
  // Your redirect URL
  url: `${environment.Base_URL}account/account-inf`, 
  handleCodeInApp: true,
};

@Component({
  selector: 'app-account-inf',
  templateUrl: './account-inf.component.html',
  styleUrls: ['./account-inf.component.css']
})
export class AccountInfComponent implements OnInit {
  public model: GetCurrentUserInfoAccountView = new GetCurrentUserInfoAccountView();

  public infoForm = this.formBuilder.group({
    userName: ['', Validators.required],
    email: ['', [Validators.email]]
  });

  constructor(
    private accountService: AccountService,
    private authService: AuthService,
    private zone: NgZone, 
    public afAuth: AngularFireAuth,
    private gameService: GameService,
    private notifyService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.accountService.getCurrentUserInfo().subscribe(
      data => {
        this.model.email = data.email;
        this.model.userName = data.userName;
        this.model.emailConfirmed = data.emailConfirmed;
      },
      error => this.notifyService.showError(error)
    );

    const url = this.router.url;

    this.confirmSignIn(url);
  }

  async confirmSignIn(url:string) {
    try {
      if (this.afAuth.auth.isSignInWithEmailLink(url)) {
        let email = localStorage.getItem('emailForSignIn');

        if (!email) {
          this.notifyService.showError('Please provide your email for confirmation');
        }

        const result = await this.afAuth.auth.signInWithEmailLink(email, url);
        localStorage.removeItem('emailForSignIn');
      }
    } catch (err) {
      this.notifyService.showError(err.message);
    }
  }

  verifiEmail() {
    return new Promise<any>((resolve, reject) => {
      let currentUser = this.afAuth.auth.currentUser;
      if(currentUser == null) {
        this.afAuth.auth.sendSignInLinkToEmail(this.model.email, actionCodeSettings).then(res=>{
          localStorage.setItem('emailForSignIn', this.model.email);
          this.notifyService.showInfo("You must sign in with link that was send to your email");
        },error => {
          this.notifyService.showError(error);
        }
        );       
        return;
      }
      if(currentUser.email == null || currentUser.email == "") {
        this.notifyService.showError("Current user email doesn't exist");
        return;
      }
      if(currentUser.emailVerified == true && this.model.emailConfirmed == true) {
        this.notifyService.showError("Email already verified");
        return;
      }
      currentUser.sendEmailVerification()
      .then(res => {
        this.accountService.emailConfirmed().subscribe(
          data => {
            this.model.emailConfirmed = true;
            this.notifyService.showSuccess("Email Confirmed");
          },
          error => this.notifyService.showError(error)
        );
        resolve(res);
      }, error => {
        this.notifyService.showError(error);
        reject(error);
      })
    })
  }

  changeEmail() {
    return new Promise<any>((resolve, reject) => {     
      let currentUser = this.afAuth.auth.currentUser;
      let newEmail:UpdateEmailAccountView = new UpdateEmailAccountView();
      newEmail.email = this.model.email;
      if(currentUser == null){
        this.accountService.updateEmail(newEmail).subscribe(
          data => {
            this.model.emailConfirmed = false;
            this.notifyService.showSuccess("Email Changed");
          },
          error => this.notifyService.showError(error)
        );
        return;
      }
      currentUser.updateEmail(this.model.email)
      .then(res => {
        this.accountService.updateEmail(newEmail).subscribe(
          data => {
            this.model.emailConfirmed = false;
            this.notifyService.showSuccess("Email Changed");
          },
          error => this.notifyService.showError(error)
        );
        resolve(res);
      }, error => {
        this.notifyService.showError(error);
        reject(error);
      })
    })
  }
}
