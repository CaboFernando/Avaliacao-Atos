import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";


@Injectable()
export class CalculoDataService {

    module: string = '/api/calculo';

    constructor(private http: HttpClient) { }

    get(ValorMonetario, QuantidadeMeses) {
        return this.http.get(this.module + '?valorMonetario=' + ValorMonetario + '&quantidadeMeses=' + QuantidadeMeses);
    }

}