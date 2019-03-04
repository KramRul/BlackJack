"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var operators_1 = require("rxjs/operators");
var HttpConfigInterceptor = /** @class */ (function () {
    function HttpConfigInterceptor() {
    }
    HttpConfigInterceptor.prototype.intercept = function (request, next) {
        var token = localStorage.getItem('accessToken');
        if (token) {
            request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
        }
        if (!request.headers.has('Content-Type')) {
            request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
        }
        request = request.clone({ headers: request.headers.set('Accept', 'application/json') });
        return next.handle(request).pipe(operators_1.map(function (event) {
            if (event instanceof http_1.HttpResponse) {
                console.log('event--->>>', event);
            }
            return event;
        }));
    };
    return HttpConfigInterceptor;
}());
exports.HttpConfigInterceptor = HttpConfigInterceptor;
//# sourceMappingURL=http-config.interceptor.js.map