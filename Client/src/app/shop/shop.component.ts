import { Component } from '@angular/core';
import { ShopService } from './shop.service';
import { Injectable, OnInit } from '@angular/core';
import { product } from '../shared/Models/product';
import { Brands } from '../shared/Models/Brands';
import { Types } from '../shared/Models/Types';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit  {
  products:product[]=[];
  brands:Brands[]=[];
  types:Types[]=[];
  brandIdselected=0;
  typeIdselected=0;
  sortselected='name';
  sortoptions=[
    {
      name:'Alphabetical',value:'name'
    },
   
    {
      name:'Price : Low to High',value:'priceasc'
    },
    {
      name:'Price : High to Low',value:'pricedesc'
    },
  ]
constructor(private services:ShopService){

}
  ngOnInit(): void {
   this.getproducts();
   this.getbrands();
   this.gettypes();
  }
  getproducts(){
    this.services.getproducts(this.brandIdselected,this.typeIdselected,this.sortselected).subscribe({
      next:response=>this.products=response.data,
      error:error=>console.log(error)
      
    })
  }
  gettypes(){
    this.services.gettypes().subscribe({
      next:response=>this.types=[{id:0,name:"All"},...response],
      error:error=>console.log(error)
      
    })
  }
  getbrands(){
    this.services.getbrands().subscribe({
      next:response=>this.brands=[{id:0,name:"All"},...response],
      error:error=>console.log(error)
      
    })
  }
  onbrandselected(brandId:number){
 this.brandIdselected=brandId;
 this.getproducts();
  }
  ontypeselected(typeId:number){
    this.typeIdselected=typeId;
    this.getproducts();
  }
  onsortselected(event:any){
   this.sortselected=event.target.value;
   this.getproducts();
  }

}
