import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { product } from '../shared/Models/product';
import { Pagination } from '../shared/Models/Pagination';
import { Brands } from '../shared/Models/Brands';
import { Types } from '../shared/Models/Types';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl='https://localhost:5001/';

  constructor(private http:HttpClient) {

   }
 
  getproducts(brandId?:number,typeId?:number,sort?:string){
    let params=new HttpParams();
    if(brandId) params=params.append('brandId',brandId);
    if(typeId) params=params.append('typeId',typeId);
    if(sort) params=params.append('sort',sort);
    return this.http.get<Pagination<product[]>>(this.baseUrl +'products?pageSize=50',{params});
  }
  gettypes(){
    return this.http.get<Types[]>(this.baseUrl+'products/Types');
  }
  getbrands(){
    return this.http.get<Brands[]>(this.baseUrl+'products/brands');
  }
}
