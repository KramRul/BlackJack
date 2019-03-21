import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  public model: RegisterAccountView = new RegisterAccountView();

  public registerForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required],
    passwordConfirm: ['', Validators.required]
  });

  constructor(
    private accountService: AccountService,
    private notifyService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  register(): void {
    this.model.userName = this.registerForm.get('userName').value;
    this.model.password = this.registerForm.get('password').value;
    this.model.passwordConfirm = this.registerForm.get('passwordConfirm').value;
    this.accountService.register(this.model).subscribe(
      data => this.router.navigateByUrl("/"),
      error => this.notifyService.showError(error)
    );
  }
}
