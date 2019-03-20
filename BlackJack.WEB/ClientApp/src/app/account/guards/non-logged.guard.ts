import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivateChild, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class NonLoggedGuard implements CanActivateChild{
  constructor(private _accountService: AccountService, private _router: Router) {
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var path = route.routeConfig.path;
    console.log(route.routeConfig.path);
    var isSignedIn = this._accountService.isSignedIn();
    if (isSignedIn && path != 'logout') {
      this._router.navigate(['/account/logout']);
      return false;
    };
    if (isSignedIn && path == 'logout') {
      return true;
    }
    return true;
  }
}
