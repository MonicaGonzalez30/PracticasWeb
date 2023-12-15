import { Component } from '@angular/core';
import { ProductosComponent } from '../paginas/productos/productos.component';
import { InicioComponent } from '../paginas/inicio/inicio.component';
import { ConocenosComponent } from '../paginas/conocenos/conocenos.component';
import { PreguntasComponent } from '../paginas/preguntas/preguntas.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-content',
  standalone: true,
  imports: [InicioComponent, ProductosComponent, ConocenosComponent, PreguntasComponent, RouterModule],
  templateUrl: './content.component.html',
  styleUrl: './content.component.scss'
})
export class ContentComponent {

}
