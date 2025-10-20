import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Ramservice {
  API_URL = 'http://localhost:5056';

  getRamCompatibles(placaBaseId: number) {
    return this.httpClient.get<any>(`${this.API_URL}/api/Componentes/memorias-compatibles/${placaBaseId}`);
  }

  constructor(private httpClient:HttpClient) { }
}
