import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';
import { NgxSelectModule } from 'ngx-select-ex';

@NgModule({
  declarations: [
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent
  ],
  imports: [   
    SharedModule,    
    AccountRoutingModule,
    NgxSelectModule
  ]
})
export class AccountModule { }
