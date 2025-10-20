import { ChangeDetectorRef, Component } from '@angular/core';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';
import { Graficaservice } from '../../service/graficaservice';

@Component({
  selector: 'app-graficacomponent',
  imports: [],
  templateUrl: './graficacomponent.html',
  styleUrl: './graficacomponent.css'
})
export class Graficacomponent {
  graficaList: any[] = [];
  graficaSeleccionada: any = null;

  constructor(
    private graficaService: Graficaservice,
    private eleccionService: Eleccionservice,
    private router: Router,
    private cdr: ChangeDetectorRef){}

ngOnInit(): void {
  console.log('🧩 PlacaBase en Grafica:', this.eleccionService.getPlacaBase);
  this.getGraficas();
}

  getGraficas() {
    const idPlaca = this.eleccionService.getPlacaBase();
    console.log('📡 Solicitando graficas con placa ID:', idPlaca);
    this.graficaService.getGraficasCompatibles(idPlaca).subscribe({
      next: (data: any) => {
        console.log('Graficas compatibles:', data);
        this.graficaList = data;
        this.cdr.detectChanges();
      },
      error: (error: any) => console.log(error)
    });
  }

  seleccionarGrafica(grafica: any) {
    this.graficaSeleccionada = grafica;
  }

  continuar() {
    if (this.graficaSeleccionada) {
      this.eleccionService.setGrafica(this.graficaSeleccionada.id);
      this.router.navigate(['/fuente']);
    }
  }
}
