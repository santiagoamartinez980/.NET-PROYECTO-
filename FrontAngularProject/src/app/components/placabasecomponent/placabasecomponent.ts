import { Component, ChangeDetectorRef } from '@angular/core';
import { Placabaseservice } from '../../service/placabaseservice';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-placabasecomponent',
  standalone: true,

  templateUrl: './placabasecomponent.html',
  styleUrls: ['./placabasecomponent.css']
})
export class Placabasecomponent {
  placaList: any[] = [];
  placaSeleccionada: any = null;

  constructor(
    private placabaseService: Placabaseservice,
    private eleccionService: Eleccionservice,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    console.log('🧩 Procesador en Placabase:', this.eleccionService.getProcesador());
    this.getPlacas();
  }

  getPlacas() {
    const idProc = this.eleccionService.getProcesador();
    console.log('📡 Solicitando placas con procesador ID:', idProc);

    this.placabaseService.getPlacasCompatibles(idProc).subscribe({
      next: (data) => {
        console.log('✅ Placas recibidas:', data);
        this.placaList = data;
        this.cdr.detectChanges(); // 🔥 Fuerza actualización en modo SSR
      },
      error: (error) => console.error('❌ Error obteniendo placas:', error),
    });
  }

  seleccionarPlaca(placa: any) {
    this.placaSeleccionada = placa;
    console.log('🖱️ Placa seleccionada:', placa);
  }

  continuar() {
    if (this.placaSeleccionada) {
      this.eleccionService.setPlacaBase(this.placaSeleccionada.id);
      console.log('➡️ Navegando con placa:', this.placaSeleccionada.id);
      this.router.navigate(['/almacenamiento']);
    }
  }
}
