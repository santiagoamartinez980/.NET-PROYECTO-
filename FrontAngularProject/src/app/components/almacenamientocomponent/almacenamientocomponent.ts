import { ChangeDetectorRef, Component } from '@angular/core';
import { Almacenamientoservice } from '../../service/almacenamientoservice';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-almacenamientocomponent',
  imports: [],
  templateUrl: './almacenamientocomponent.html',
  styleUrl: './almacenamientocomponent.css'
})
export class Almacenamientocomponent {
  almacenamientoList: any[] = [];
  almacenamientoSeleccionado: any = null;

  constructor(
    private almacenamientoService: Almacenamientoservice,
    private eleccionService: Eleccionservice,
    private router: Router,
    private cdr: ChangeDetectorRef){}

ngOnInit(): void {
  console.log('🧩 Placabase en Almacenamiento:', this.eleccionService.getPlacaBase);
  this.getAlmacenamiento();
}

  getAlmacenamiento() {
    const idPlaca = this.eleccionService.getPlacaBase();
    console.log('📡 Solicitando almacenamiento con placa ID:', idPlaca);
    this.almacenamientoService.getAlmacenamientoCompatible(idPlaca).subscribe({
      next: (data: any) => {
        console.log('Almacenamientos compatibles:', data);
        this.almacenamientoList = data;
        this.cdr.detectChanges();
      },
      error: (error: any) => console.log(error)
    });
  }

  seleccionarAlmacenamiento(almacenamiento: any) {
    this.almacenamientoSeleccionado = almacenamiento;
  }

  continuar() {
    if (this.almacenamientoSeleccionado) {
      this.eleccionService.setAlmacenamiento(this.almacenamientoSeleccionado.id);
      this.router.navigate(['/grafica']);
    }
  }
}
