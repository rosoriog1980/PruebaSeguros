import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Poliza } from './polizas/poliza'
import { catchError, map, tap } from 'rxjs/operators';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const baseUrl = "http://localhost:49773/api";

@Injectable({
  providedIn: 'root'
})

export class PolizaService {

  constructor(
    private http: HttpClient
  ) { }

  getPolizas (): Observable<any>{
    return this.http.get(`${baseUrl}/poliza`,httpOptions);
  }

  getPoliza(id: number): Observable<any>{
    return this.http.get(`${baseUrl}/poliza/${id}`,httpOptions);
  }

  insertPoliza(poliza : Poliza): Observable<any>{
    const body = poliza;
    return this.http.post(`${baseUrl}/poliza`, body, httpOptions);
  }

  deletePoliza(id: number): Observable<any>{
    return this.http.delete(`${baseUrl}/poliza/${id}`,httpOptions);
  }

}
