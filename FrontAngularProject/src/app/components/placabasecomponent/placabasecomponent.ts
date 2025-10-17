import { Component } from '@angular/core';
import { Placabaseservice } from '../../service/placabaseservice';
import { Eleccionservice } from '../../service/eleccionservice';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-placabasecomponent',
  imports: [CommonModule],
  templateUrl: './placabasecomponent.html',
  styleUrl: './placabasecomponent.css'
})
export class Placabasecomponent {
    placaList:any[]=[];
    placaSeleccionada:any=null;
    
    ngOnInit(): void {
      this.getPlacas();

    }
    constructor(private placabaseService:Placabaseservice, private eleccionService:Eleccionservice){}
  
    getPlacas(){
      this.placabaseService.getPlacasCompatibles(this.eleccionService.getProcesador()).subscribe({
        next:(data)=>{
          console.log('Placas compatibles:', data);
          this.placaList=data;
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
    }
  }
}
