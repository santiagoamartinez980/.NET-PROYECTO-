import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Almacenamientoservice {
    API_URL = 'http://localhost:5056';

  getProducts() {
    return this.httpClient.get<any>(this.API_URL+'/api/Componentes/placas-compatibles/{procesadorId}');
  }

  constructor(private httpClient:HttpClient) { }
}
