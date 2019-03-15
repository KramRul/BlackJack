import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AccountComponent } from './account.component';
import { LogoutComponent } from './logout/logout.component';
import { NonLoggedGuard } from './guards/non-logged.guard';

const routes: Routes = [
  {
    path: '', component: AccountComponent, canActivateChild: [NonLoggedGuard], children: [
      { path: '', redirectTo: 'logout', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'logout', component: LogoutComponent }
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [NonLoggedGuard]
})
export class AccountRoutingModule { }
