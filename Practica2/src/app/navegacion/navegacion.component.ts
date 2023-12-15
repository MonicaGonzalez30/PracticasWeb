import { Component } from '@angular/core';
import { RouterModule} from '@angular/router';

@Component({
  selector: 'app-navegacion',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './navegacion.component.html',
  styleUrl: './navegacion.component.scss'
})
export class NavegacionComponent {
  //Sirve para manejar el front, pedir info al back y mostrarla en el front
  menus : string[] = ["Inicio","Conocenos","Preguntas frecuentes"]; //Lenguaje typescript
}
