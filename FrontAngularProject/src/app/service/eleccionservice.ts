import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Eleccionservice {
  private IdprocesadorSeleccionado: any = null;
  private IdplacabaseSeleccionada: any = null;

  setProcesador(Idprocesador: any) {
    this.IdprocesadorSeleccionado = Idprocesador;

  }
  getProcesador() {
    return this.IdprocesadorSeleccionado;
  }

  setPlacaBase(Idplacabase: any) {
    this.IdplacabaseSeleccionada = Idplacabase;
  }
  getPlacaBase() {
    return this.IdplacabaseSeleccionada;
  }
}
