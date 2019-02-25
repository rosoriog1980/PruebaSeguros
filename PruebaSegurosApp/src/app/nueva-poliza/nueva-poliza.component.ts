import { Component, OnInit } from '@angular/core';
import { Poliza } from '../polizas/poliza'
import { Alert } from 'selenium-webdriver';
import { PolizaService } from '../poliza.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-nueva-poliza',
  templateUrl: './nueva-poliza.component.html',
  styleUrls: ['./nueva-poliza.component.css']
})
export class NuevaPolizaComponent implements OnInit {
  poliza: Poliza;
  coberturaId: number;
  porcentaje: number;
  Riesgo =  [
    {id: 1, Nombre: "Bajo"},
    {id: 2, Nombre: "Medio"},
    {id: 3, Nombre: "Medio-Alto"},
    {id: 4, Nombre: "Alto"}
  ]

  Coberturas = [
    {id: 1, Nombre: "Terremoto"},
    {id: 2, Nombre: "Incendio"},
    {id: 3, Nombre: "Robo"},
    {id: 4, Nombre: "Pérdida Parcial"},
    {id: 5, Nombre: "Pérdida Total"}
  ]
  constructor(
    private polizaService: PolizaService,
    private router: Router
  ) { }

  AddCobertura(){
    if(this.coberturaId && this.porcentaje){
      this.poliza.PolizaCubrimientos.push({
        CubrimientoId: this.coberturaId,
        CubrimientoDescripcion: this.Coberturas.find(c=> c.id == this.coberturaId).Nombre,
        Porcentaje: this.porcentaje
      });
    }
  }

  GuardarPoliza(){
    if (this.poliza.PolizaNombre && this.poliza.PolizaDescripcion && this.poliza.PolizaInicio
      && this.poliza.PolizaPeriodoCobertura && this.poliza.PolizaPrecio && this.poliza.PolizaRiesgo) {
        if (this.poliza.PolizaRiesgo == 4 && this.poliza.PolizaCubrimientos.find(x => x.Porcentaje > 50)) {
          alert("No se puede generar una póliza con cubrimientos superiores al 50% cuando se tiene un riesgo Alto!");
        } else {
          this.polizaService.insertPoliza(this.poliza)
          .subscribe(x => {
            this.router.navigate(['polizas']);
          });
        }
      
    } else {
      alert("Faltan campos por diligenciar");
    }
  }

  atras(){
    this.router.navigate(['polizas']);
  }

  ngOnInit() {
    this.poliza = new Poliza();
    this.poliza.PolizaCubrimientos = [];
  }

}
