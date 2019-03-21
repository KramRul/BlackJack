import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginAccountView } from '../entities/account.views/login.account.view';
import { RegisterAccountView } from '../entities/account.views/register.account.view';
import { map } from 'rxjs/operators';
import { LoginAccountResponseView } from '../entities/account.views/login-response.account.view';
import { LocalStorageService } from './local-storage.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private Url = `${environment.Base_URL}api/account/`;

  constructor(private http: HttpClient) {
  }

  isSignedIn(): boolean {
    if (new LocalStorageService<string>().getItem("accessToken") != null)
      return true;
    else
      return false;
  }

  login(model: LoginAccountView): Observable<void> {
    return this.http.post<LoginAccountResponseView>(`${this.Url}login`, model).pipe(
      map((response: LoginAccountResponseView) => {
        var lStorage = new LocalStorageService<string>();
        lStorage.setItem("accessToken", response.accessToken);
      }));
  }

  logout(): void {
    var lStorage = new LocalStorageService<string>();
    lStorage.removeItem("accessToken");
  }

  getLoggedPlayerName(): Observable<string> {
    return this.http.post<string>(`${this.Url}getLoggedPlayerName`, null).pipe(
      map((response: string) => {
        return response;
      }));
  }

  register(model: RegisterAccountView): Observable<any> {
    return this.http.post(`${this.Url}register`, model);
  }
}
