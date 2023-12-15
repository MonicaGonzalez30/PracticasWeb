import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DTO_Producto } from '../paginas/productos/productos.component';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  public GetProducts():Observable<any>{ 
    // Objeto que regresa cualquie tipo y al ser observable puede verse en cualquier componente
    return this.http.get("https://dummyjson.com/products"); //En lugar de esta url, debe de colocarlse la url del backend
  }

  public PostProduct(nombre: DTO_Producto):Observable<any>{
    return this.http.post("https://dummyjson.com/products/add", JSON.stringify(nombre));
  }
}