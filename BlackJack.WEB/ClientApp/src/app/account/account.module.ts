import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';

@NgModule({
  declarations: [AccountComponent, LoginComponent, RegisterComponent, LogoutComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    HttpClientModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
