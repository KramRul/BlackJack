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
    var pathChenk = route.routeConfig.path;
    console.log(route.routeConfig.path);
    //console.log(route.children[0].routeConfig);
    var check = this._accountService.isSignedIn();
    if (check && pathChenk != 'logout') {
      this._router.navigate(['/account/logout']);
      return false;
    };
    if (check && pathChenk == 'logout') {
      return true;
    }
    return true;
  }
}
