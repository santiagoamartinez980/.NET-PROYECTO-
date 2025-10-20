import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
// ...existing code...
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class Eleccionservice {
  private IdprocesadorSeleccionado: any = null;
  private IdplacabaseSeleccionada: any = null;
  private IdmemoriaRamSeleccionada: any = null;
  private IdalmacenamientoSeleccionado: any = null;
  private IdgraficaSeleccionada: any = null;

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  // ✅ Guardar procesador seleccionado
  setProcesador(Idprocesador: any) {
    this.IdprocesadorSeleccionado = Idprocesador;
    if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
      localStorage.setItem('procesadorSeleccionado', Idprocesador.toString());
    }
  }
  
// ✅ Obtener procesador (persistente)
  getProcesador() {
    if (this.IdprocesadorSeleccionado === null) {
      if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
        this.IdprocesadorSeleccionado = localStorage.getItem('procesadorSeleccionado');
      } else {
        this.IdprocesadorSeleccionado = null;
      }
    }
    return this.IdprocesadorSeleccionado;
  }

  // ✅ Guardar placa base
  setPlacaBase(Idplacabase: any) {
    this.IdplacabaseSeleccionada = Idplacabase;
    if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
      localStorage.setItem('placaBaseSeleccionada', Idplacabase.toString());
    }
  }

  // ✅ Obtener placa base (persistente)
  getPlacaBase() {
    if (this.IdplacabaseSeleccionada === null) {
      if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
        this.IdplacabaseSeleccionada = localStorage.getItem('placaBaseSeleccionada');
      } else {
        this.IdplacabaseSeleccionada = null;
      }
    }
    return this.IdplacabaseSeleccionada;
  }

  // ✅ Guardar memoria RAM
  setMemoriaRam(IdmemoriaRam: any) {
    this.IdmemoriaRamSeleccionada = IdmemoriaRam;
    if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
      localStorage.setItem('memoriaRamSeleccionada', IdmemoriaRam.toString());
    }
  }

  // ✅ Obtener memoria RAM (persistente)
  getMemoriaRam() {
    if (this.IdmemoriaRamSeleccionada === null) {
      if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
        this.IdmemoriaRamSeleccionada = localStorage.getItem('memoriaRamSeleccionada');
      } else {
        this.IdmemoriaRamSeleccionada = null;
      }
    }
    return this.IdmemoriaRamSeleccionada;
  }

  // ✅ Guardar almacenamiento
  setAlmacenamiento(Idalmacenamiento: any) {
    this.IdalmacenamientoSeleccionado = Idalmacenamiento;
    if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
      localStorage.setItem('almacenamientoSeleccionado', Idalmacenamiento.toString());
    }
  }

  // ✅ Obtener almacenamiento (persistente)
  getAlmacenamiento() {
    if (this.IdalmacenamientoSeleccionado === null) {
      if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
        this.IdalmacenamientoSeleccionado = localStorage.getItem('almacenamientoSeleccionado');
      } else {
        this.IdalmacenamientoSeleccionado = null;
      }
    }
    return this.IdalmacenamientoSeleccionado;
  }

  // ✅ Guardar gráfica
  setGrafica(Idgrafica: any) {
    this.IdgraficaSeleccionada = Idgrafica;
    if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
      localStorage.setItem('graficaSeleccionada', Idgrafica.toString());
    }
  }

  // ✅ Obtener gráfica (persistente)
  getGrafica() {
    if (this.IdgraficaSeleccionada === null) {
      if (isPlatformBrowser(this.platformId) && typeof localStorage !== 'undefined') {
        this.IdgraficaSeleccionada = localStorage.getItem('graficaSeleccionada');
      } else {
        this.IdgraficaSeleccionada = null;
      }
    }
    return this.IdgraficaSeleccionada;
  }



}