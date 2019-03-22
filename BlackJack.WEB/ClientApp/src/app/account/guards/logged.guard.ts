import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class LoggedGuard implements CanActivate  {
  constructor(private accountService: AccountService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var isSignedIn = this.accountService.isSignedIn();
    if (isSignedIn) {
      return true;
    }
    this.router.navigate(['/account/login']);
    return false;
  }
}
