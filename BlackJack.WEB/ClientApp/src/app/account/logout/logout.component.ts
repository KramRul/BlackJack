import { Component } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';
import { AuthService } from 'angularx-social-login';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {
  constructor(
    private accountService: AccountService,
    private authService: AuthService,
    private notifyService: NotificationService,
    private router: Router) {
  }

  logout(): void {
    this.authService.signOut(true).catch(error => {
      console.error(error);
      this.notifyService.showError(error);
    });

    try {
      this.accountService.logout();    
    }
    catch (e) {
      console.error(e); 
      this.notifyService.showError("Error with logout method");
    }
    this.router.navigateByUrl("/");
  }
}
