import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { FormBuilder, Validators } from '@angular/forms';
import { PasswordValidation } from 'src/app/shared/validations/password.validation';
import * as firebase from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { resolve, reject } from 'q';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  public model: RegisterAccountView = new RegisterAccountView();

  public registerForm = this.formBuilder.group({
    userName: ['', Validators.required],
    email: ['', [Validators.email]],
    password: ['', Validators.required],
    passwordConfirm: ['', Validators.required]
  },
  {
    validator: PasswordValidation.MatchPassword
  });

  constructor(
    private accountService: AccountService,
    private notifyService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  register(): void {
    firebase.auth().createUserWithEmailAndPassword(this.model.email, this.model.password)
     .then(res => {
      this.accountService.register(this.model).subscribe(
        data => this.router.navigateByUrl("/"),
        error => this.notifyService.showError(error)
      );
       resolve(res);
     }, err => reject(err));
    
  }
}
