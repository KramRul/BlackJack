import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class LoggedGuard implements CanActivate  {
  constructor(private _accountService: AccountService, private _router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var check = this._accountService.isSignedIn();
    if (check) {
      return true;
    }
    this._router.navigate(['/account/login']);
    return false;
  }
}
