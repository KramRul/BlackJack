import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, CanActivateChild, Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class NonLoggedGuard implements CanActivate{
  constructor(private accountService: AccountService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let isSignedIn = this.accountService.isSignedIn();
    if (isSignedIn) {
      this.router.navigate(['/account/logout']);
      return false;
    };
    if (!isSignedIn) {
      return true;
    }
    return true;
  }
}
