import { ChangeDetectorRef, Component } from '@angular/core';
import { Placabaseservice } from '../../service/placabaseservice';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-placabasecomponent',
  imports: [],
  templateUrl: './placabasecomponent.html',
  styleUrl: './placabasecomponent.css'
})
export class Placabasecomponent {
    placaList:any[]=[];
    placaSeleccionada:any=null;
    
    ngOnInit(): void {
      this.getPlacas();

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
    this.placaSeleccionada = placa;
  }

  continuar() {
    if (this.placaSeleccionada) {
      this.eleccionService.setPlacaBase(this.placaSeleccionada.id);
      console.log('➡️ Navegando con placa:', this.placaSeleccionada.id);
      this.router.navigate(['/memoriaram']);
    }
  }
}