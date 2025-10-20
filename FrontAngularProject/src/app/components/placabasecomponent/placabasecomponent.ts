<<<<<<< HEAD
import { Component, ChangeDetectorRef } from '@angular/core';
=======
import { ChangeDetectorRef, Component } from '@angular/core';
>>>>>>> origin/devNieto
import { Placabaseservice } from '../../service/placabaseservice';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-placabasecomponent',
<<<<<<< HEAD
  standalone: true,

=======
  imports: [],
>>>>>>> origin/devNieto
  templateUrl: './placabasecomponent.html',
  styleUrls: ['./placabasecomponent.css']
})
export class Placabasecomponent {
  placaList: any[] = [];
  placaSeleccionada: any = null;

<<<<<<< HEAD
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
=======
    }
    constructor(
      private placabaseService:Placabaseservice, 
      private eleccionService:Eleccionservice, 
      private router:Router,
      private cdr: ChangeDetectorRef){}
  
    getPlacas(){
      this.placabaseService.getPlacasCompatibles(this.eleccionService.getProcesador()).subscribe({
        next:(data)=>{
          console.log('Placas compatibles:', data);
          this.placaList=data;
          this.cdr.detectChanges();
        },
        error:(error)=>console.log(error)
      })
      
      };
    
    seleccionarPlaca(placa: any) {
>>>>>>> origin/devNieto
    this.placaSeleccionada = placa;
    console.log('🖱️ Placa seleccionada:', placa);
  }

  continuar() {
    if (this.placaSeleccionada) {
      this.eleccionService.setPlacaBase(this.placaSeleccionada.id);
      console.log('➡️ Navegando con placa:', this.placaSeleccionada.id);
<<<<<<< HEAD
      this.router.navigate(['/almacenamiento']);
=======
      this.router.navigate(['/memoriaram']);
>>>>>>> origin/devNieto
    }
  }
}