import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router, CanActivateChild } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AccountGuard implements CanActivate, CanActivateChild {
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

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var pathChenk = route.routeConfig.path;
    console.log(route.routeConfig.path);
    //console.log(route.children[0].routeConfig);
    var check = this._accountService.isSignedIn();
    if (check && pathChenk != 'logout') {
      return false;
    };
    if (check && pathChenk == 'logout') {
      return true;
    }
    return true;
  }
}
