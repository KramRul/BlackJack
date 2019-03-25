"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var operators_1 = require("rxjs/operators");
var local_storage_service_1 = require("../services/local-storage.service");
var HttpTokenInterceptor = /** @class */ (function () {
    function HttpTokenInterceptor() {
    }
    HttpTokenInterceptor.prototype.intercept = function (request, next) {
        var lStorage = new local_storage_service_1.LocalStorageService();
        var token = lStorage.getItem('accessToken', "");
        if (token) {
            request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
        }
        return next.handle(request).pipe(operators_1.map(function (event) {
            if (event instanceof http_1.HttpResponse) {
                console.log('event--->>>', event);
            }
            return event;
        }));
    };
    return HttpTokenInterceptor;
}());
exports.HttpTokenInterceptor = HttpTokenInterceptor;
//# sourceMappingURL=http-token.interceptor.js.map