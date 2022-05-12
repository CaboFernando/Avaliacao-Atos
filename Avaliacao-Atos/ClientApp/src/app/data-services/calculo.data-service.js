"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CalculoDataService = void 0;
var CalculoDataService = /** @class */ (function () {
    function CalculoDataService(http) {
        this.http = http;
        this.module = '/api/calculo';
    }
    CalculoDataService.prototype.get = function () {
        return this.http.get(this.module);
    };
    return CalculoDataService;
}());
exports.CalculoDataService = CalculoDataService;
//# sourceMappingURL=calculo.data-service.js.map