import { Component } from '@angular/core';
import { ProductoService } from '../../servicios/producto.service';

@Component({
  selector: 'app-productos',
  standalone: true,
  imports: [],
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.scss'
})
export class ProductosComponent {
  public lista: DTO_Producto[] = [];
  constructor(private pService: ProductoService){
    pService.GetProducts().subscribe(result => {
      // console.log(result);
      this.lista = result.products;

      pService.PostProduct(this.lista[0]).subscribe(result => {
        console.log(result);
      });
    });
  }
}

export interface DTO_Producto{ //Creacion del DTO en el front
  id:number,
  title:string,
  description:string,
  price:number,
  discountPercentage:number,
  rating:number,
  stock:number,
  brand:string,
  category:string,
  thumbnail:string,
  images:string[]
}
