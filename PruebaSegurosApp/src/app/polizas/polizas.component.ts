import { Component, OnInit } from '@angular/core';
import { PolizaService } from '../poliza.service'
import { Router } from '@angular/router'



@Component({
  selector: 'app-polizas',
  templateUrl: './polizas.component.html',
  styleUrls: ['./polizas.component.css']
})
export class PolizasComponent implements OnInit {
  polizas: any[];
  selectedPoliza: any;
  constructor(
    private polizaService: PolizaService,
    private router: Router
  ) { }

  getPolizas(){
    this.polizaService.getPolizas()
    .subscribe(result => this.polizas = result );
  }

  onSelect(poliza: any){
    this.selectedPoliza = poliza;
  }

  goNueva(){
    this.router.navigate(['nueva']);
  }

  ngOnInit() {
    this.getPolizas();
  }

}
