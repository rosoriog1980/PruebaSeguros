import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { PolizaService } from '../poliza.service'
import { Poliza } from '../polizas/poliza'
import { Router } from '@angular/router'

@Component({
  selector: 'app-poliza-detail',
  templateUrl: './poliza-detail.component.html',
  styleUrls: ['./poliza-detail.component.css']
})
export class PolizaDetailComponent implements OnInit {
 poliza: Poliza;
  constructor(
    private route: ActivatedRoute,
    private polizaService: PolizaService,
    private location: Location,
    private router: Router
  ) { }

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

  deletePoliza(id: number){
    this.polizaService.deletePoliza(id)
    .subscribe(resul => {
      this.router.navigate(['polizas']);
    });
  }

  atras(){
    this.router.navigate(['polizas']);
  }
  modificar(){
    this.router.navigate([`actualizar/${this.poliza.PolizaId}`]);
  }

  ngOnInit() {
    this.poliza = new Poliza();
    this.getPoliza();
  }



}
