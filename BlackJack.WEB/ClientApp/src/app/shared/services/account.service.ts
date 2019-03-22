import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { map } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';
import { LocalStorageService } from './local-storage.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RegisterAccountResponseView } from '../entities/account.views/register-response.account.view';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private Url = `${environment.Base_URL}api/account/`;

  constructor(private http: HttpClient, private localStorageService: LocalStorageService<string>) {
  }

  isSignedIn(): boolean {
    if (this.localStorageService.getItem("accessToken") != null)
      return true;
    else
      return false;
  }

  login(model: LoginAccountView): Observable<void> {
    return this.http.post<LoginAccountResponseView>(`${this.Url}login`, model).pipe(
      map((response: LoginAccountResponseView) => {
        this.localStorageService.setItem("accessToken", response.accessToken);
        this.localStorageService.setItem("userName", response.userName);
      }));
  }

  logout(): void {
    this.localStorageService.removeItem("accessToken");
    this.localStorageService.removeItem("userName");
  }

  getLoggedPlayerName(): string {
    return this.localStorageService.getItem("userName");
  }

  register(model: RegisterAccountView): Observable<any> {
    return this.http.post(`${this.Url}register`, model).pipe(
      map((response: RegisterAccountResponseView) => {
        this.localStorageService.setItem("accessToken", response.accessToken);
        this.localStorageService.setItem("userName", response.userName);
      }));
  }
}
