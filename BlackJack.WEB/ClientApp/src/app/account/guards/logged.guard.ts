import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class LoggedGuard implements CanActivate  {
  constructor(private _accountService: AccountService, private _router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var isSignedIn = this._accountService.isSignedIn();
    if (isSignedIn) {
      return true;
    }
    this._router.navigate(['/account/login']);
    return false;
  }
}
