import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AccountComponent } from './account.component';
import { LogoutComponent } from './logout/logout.component';
import { NonLoggedGuard } from './guards/non-logged.guard';
import { LoggedGuard } from './guards/logged.guard';
import { AccountInfComponent } from './account-inf/account-inf.component';

const routes: Routes = [
  { path: '', redirectTo: 'logout', pathMatch: 'full' },
  {
    path: '', component: AccountComponent, children: [      
      { path: 'login', component: LoginComponent, canActivate: [NonLoggedGuard] },
      { path: 'account-inf', component: AccountInfComponent, canActivate: [LoggedGuard] },
      { path: 'register', component: RegisterComponent, canActivate: [NonLoggedGuard] },
      { path: 'logout', component: LogoutComponent, canActivate: [LoggedGuard] }
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [NonLoggedGuard]
})
export class AccountRoutingModule { }
