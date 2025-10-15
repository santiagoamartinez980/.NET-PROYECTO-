import { Component, OnInit } from '@angular/core';
import { Productservice } from '../../service/productservice';

@Component({
  selector: 'app-productcomponent',
  imports: [],
  templateUrl: './productcomponent.html',
  styleUrl: './productcomponent.css'
})
export class Productcomponent implements OnInit {
  productList:any[]=[];
  
  ngOnInit(): void {
    this.getProducts();
  }
  constructor(private productService:Productservice){}

  getProducts(){
    this.productService.getProducts().subscribe({
      next:(data)=>{
        this.productList=data;
      },
      error:(error)=>console.log(error)
    })
    };
}
