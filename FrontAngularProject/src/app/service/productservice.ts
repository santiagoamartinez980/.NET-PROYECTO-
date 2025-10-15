import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Productservice {
API_URL = 'http://localhost:5056';

  getProducts() {
    return this.httpClient.get<any>(this.API_URL+'/api/Componentes/procesadores');
  }

  constructor(private httpClient:HttpClient) { }

}
