import { Component,ChangeDetectorRef } from '@angular/core';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';
import { Ramservice } from '../../service/ramservice';

@Component({
  selector: 'app-memoriaramcomponent',
  imports: [],
  templateUrl: './memoriaramcomponent.html',
  styleUrl: './memoriaramcomponent.css'
})
export class Memoriaramcomponent {
  ramList: any[] = [];
  ramSeleccionada: any = null;

  constructor(
    private ramService: Ramservice,
    private eleccionService: Eleccionservice,
    private router: Router,
    private cdr: ChangeDetectorRef){}

ngOnInit(): void {
  console.log('🧩 PlacaBase en Ram:', this.eleccionService.getPlacaBase);
  this.getRams();
}

  getRams() {
    const idPlaca = this.eleccionService.getPlacaBase();
    console.log('📡 Solicitando rams con placa ID:', idPlaca);
    this.ramService.getRamCompatibles(idPlaca).subscribe({
      next: (data: any) => {
        console.log('Rams compatibles:', data);
        this.ramList = data;
        this.cdr.detectChanges();
      },
      error: (error: any) => console.log(error)
    });
  }

  seleccionarRam(ram: any) {
    this.ramSeleccionada = ram;
  }

  continuar() {
    if (this.ramSeleccionada) {
      this.eleccionService.setMemoriaRam(this.ramSeleccionada.id);
      this.router.navigate(['/almacenamiento']);
    }
  }
}
