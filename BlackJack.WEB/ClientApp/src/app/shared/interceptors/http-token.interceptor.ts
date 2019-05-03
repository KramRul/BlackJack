import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LocalStorageService } from '../services/local-storage.service';


export class HttpTokenInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var lStorage = new LocalStorageService();
    const token: string = lStorage.getItem<string>('accessToken');
    /*request = request.clone({ headers: request.headers.set('Access-Control-Allow-Origin', '*') });
    request = request.clone({ headers: request.headers.set('Access-Control-Allow-Credentials', 'true') });
    request = request.clone({ headers: request.headers.set('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, DELETE') });
    request = request.clone({ headers: request.headers.set('Access-Control-Allow-Headers', 'Content-Type, Accept, X-Requested-With, remember-me') });*/
    if (token) {
      request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
    }
    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          console.log('event--->>>', event);
        }
        return event;
      }));
  }
}
