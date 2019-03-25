import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild, Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';

@Injectable({
  providedIn: 'root'
})
export class NonLoggedGuard implements CanActivateChild{
  constructor(private accountService: AccountService, private router: Router) {
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let path = route.routeConfig.path;
    console.log(route.routeConfig.path);
    let isSignedIn = this.accountService.isSignedIn();
    console.log(isSignedIn);
    if (isSignedIn && path != 'logout') {
      this.router.navigate(['/account/logout']);
      return false;
    };
    if (isSignedIn && path == 'logout') {
      return true;
    }
    if (!isSignedIn && path == 'logout') {
      this.router.navigate(['/account/login']);
      return true;
    }
    return true;
  }
}
