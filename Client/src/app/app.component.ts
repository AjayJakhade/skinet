import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { product } from './shared/Models/product';
import { Pagination } from './shared/Models/Pagination';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title="Client";
 products:product[]=[];
  constructor(private http:HttpClient){
    this.http.get<Pagination<product[]>>('https://localhost:5001/products?pageSize=50').subscribe({
      next:response=>this.products=response.data,
      error:error=>console.log(error),
      complete:() =>{
        console.log("requested in progresss");
        console.log("request completed");
      }

    })

  }

}
