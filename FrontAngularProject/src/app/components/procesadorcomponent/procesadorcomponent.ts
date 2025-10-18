import { Component } from '@angular/core';
import { ProcesadorService } from '../../service/procesadorservice';
import { Eleccionservice } from '../../service/eleccionservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-procesadorcomponent',
  standalone: true,
  templateUrl: './procesadorcomponent.html',
  styleUrl: './procesadorcomponent.css'
})
export class Procesadorcomponent {
    procesadorList:any[]=[];
    procesadorSeleccionado:any=null;
    
    ngOnInit(): void {
      this.getProducts();
    }
    constructor(private  procesadorService:ProcesadorService, private eleccionService:Eleccionservice, private router: Router){}
  
    getProducts(){
      this.procesadorService.getProducts().subscribe({
        next:(data)=>{
          this.procesadorList=data;
        },
        error:(error)=>console.log(error)
      })
      };
    
    seleccionarProcesador(p: any) {
    this.procesadorSeleccionado = p;
  }

  continuar() {
    if (this.procesadorSeleccionado) {
      this.eleccionService.setProcesador(this.procesadorSeleccionado.id);
      this.router.navigate(['/placabase']);
      console.log('Procesador seleccionado:', this.procesadorSeleccionado.id);
      
    }
  }
}
