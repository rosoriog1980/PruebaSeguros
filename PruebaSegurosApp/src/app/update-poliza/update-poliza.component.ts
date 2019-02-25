import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { PolizaService } from '../poliza.service';
import { Poliza } from '../polizas/poliza';

@Component({
  selector: 'app-update-poliza',
  templateUrl: './update-poliza.component.html',
  styleUrls: ['./update-poliza.component.css']
})
export class UpdatePolizaComponent implements OnInit {
  poliza: Poliza;
  coberturaId: number;
  porcentaje: number;
  constructor(
    private route: ActivatedRoute,
    private polizaService: PolizaService,
    private location: Location,
    private router: Router
  ) { }

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
  getPoliza(){
    const id = +this.route.snapshot.paramMap.get('id');
    this.polizaService.getPoliza(id)
    .subscribe(p => {
      this.poliza.PolizaId = p.polizaId;
      this.poliza.PolizaNombre = p.polizaNombre;
      this.poliza.PolizaDescripcion = p.polizaDescripcion;
      this.poliza.PolizaCubrimientos = p.polizaCubrimientos;
      this.poliza.PolizaInicio = p.polizaInicio;
      this.poliza.PolizaPeriodoCobertura = p.polizaPeriodoCobertura;
      this.poliza.PolizaPrecio = p.polizaPrecio;
      this.poliza.PolizaRiesgo = p.polizaRiesgo;
      this.poliza.PolizaRiesgoNombre = p.polizaRiesgoNombre;
    });
  }
  ngOnInit() {
    this.poliza = new Poliza();
    this.getPoliza();
  }

  borrarCobertura(cobertura: any){
    this.polizaService.cubrimientoProcess(cobertura, 0)
    .subscribe(x=> {
      this.poliza.PolizaCubrimientos.splice(this.poliza.PolizaCubrimientos.indexOf(cobertura),1);
    });
  }

  GuardarPoliza(){
    if (this.poliza.PolizaRiesgo == 4 && this.poliza.PolizaCubrimientos.find(x => x.porcentaje > 50)) {
      alert("No se puede generar una póliza con cubrimientos superiores al 50% cuando se tiene un riesgo Alto!");
    } else {
      this.polizaService.updatePoliza(this.poliza)
      .subscribe(x=> {
        this.router.navigate(['polizas']);
      });
    }
  }

  atras(){
    this.router.navigate(['polizas']);
  }
  AddCobertura(){
    if(this.coberturaId && this.porcentaje){
      this.polizaService.cubrimientoProcess({PolizaId: this.poliza.PolizaId, CubrimientoId: this.coberturaId,
        Porcentaje: this.porcentaje}, 1)
      .subscribe(x=>{
        this.poliza.PolizaCubrimientos.push({
          cubrimientoId: this.coberturaId,
          cubrimientoDescripcion: this.Coberturas.find(c=> c.id == this.coberturaId).Nombre,
          porcentaje: this.porcentaje
        });
      });
    }
  }

}
