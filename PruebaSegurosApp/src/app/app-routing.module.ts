import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PolizasComponent } from './polizas/polizas.component';
import { PolizaDetailComponent } from './poliza-detail/poliza-detail.component'
import { NuevaPolizaComponent } from './nueva-poliza/nueva-poliza.component'
import { UpdatePolizaComponent } from './update-poliza/update-poliza.component'

const routes: Routes = [
  { path:'', redirectTo:'/polizas', pathMatch: 'full'},
  { path:'polizas', component: PolizasComponent},
  { path:'detail/:id', component: PolizaDetailComponent},
  { path:'nueva', component: NuevaPolizaComponent},
  { path:'actualizar/:id', component: UpdatePolizaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
