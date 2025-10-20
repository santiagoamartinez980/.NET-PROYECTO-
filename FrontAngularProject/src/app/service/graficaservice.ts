import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Graficaservice {
  API_URL = 'http://localhost:5056';

  getGraficasCompatibles(placaBaseId: number) {
    return this.httpClient.get<any>(`${this.API_URL}/api/Componentes/tarjetas-compatibles/${placaBaseId}`);
  }
  
  constructor(private httpClient:HttpClient) { }
}
