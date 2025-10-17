import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Placabaseservice {
  API_URL = 'http://localhost:5056';

  getPlacasCompatibles(procesadorId: number) {
    return this.httpClient.get<any>(`${this.API_URL}/api/Componentes/placas-compatibles/${procesadorId}`);
  }

  constructor(private httpClient:HttpClient) { }
}
