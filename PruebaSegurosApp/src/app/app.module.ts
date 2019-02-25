import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PolizasComponent } from './polizas/polizas.component';
import { PolizaDetailComponent } from './poliza-detail/poliza-detail.component';
import { NuevaPolizaComponent } from './nueva-poliza/nueva-poliza.component';
import { UpdatePolizaComponent } from './update-poliza/update-poliza.component';

@NgModule({
  declarations: [
    AppComponent,
    PolizasComponent,
    PolizaDetailComponent,
    NuevaPolizaComponent,
    UpdatePolizaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
