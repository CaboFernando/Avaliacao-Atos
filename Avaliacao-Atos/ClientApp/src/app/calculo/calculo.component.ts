import { Component, OnInit } from '@angular/core';
import { CalculoDataService } from '../data-services/calculo.data-service';


@Component({
  selector: 'app-calculo',
  templateUrl: './calculo.component.html',
  styleUrls: ['./calculo.component.css']
})
export class CalculoComponent implements OnInit {

    calculo: any = {};
    resultado: any = {};
    showResults: boolean = true;

    constructor(private CalculoDataService: CalculoDataService) { }

    ngOnInit() {
                
    }

    get() {
        this.CalculoDataService.get(this.calculo.ValorMonetario, this.calculo.QuantidadeMeses).subscribe((data : any) => {
            this.resultado.ValorBruto = data.valor_bruto;
            this.resultado.ValorLiquido = data.valor_liquido;
            this.showResults = false;
        }, error => {
            console.log(error);
            alert('erro interno');
        });
    }

    getNovo() {
        this.calculo = {};
        this.resultado = {}
        this.showResults = true;
    }
}
