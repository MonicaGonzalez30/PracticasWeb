import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
 import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './comun/header/header.component';
import { FooterComponent } from './comun/footer/footer.component';
import { ContentComponent } from './content/content.component';
import { ProductoService } from './servicios/producto.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent, ContentComponent, HttpClientModule], //HttpClientModule es para los servicios
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [ProductoService] //Agregar el listado de provedores es importante porque si no, no fuenciona el servicio
})
export class AppComponent {

}
