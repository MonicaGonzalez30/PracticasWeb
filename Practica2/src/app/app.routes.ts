import { Routes } from '@angular/router';
import { ProductosComponent } from "./paginas/productos/productos.component";
import { InicioComponent } from "./paginas/inicio/inicio.component";
import { PreguntasComponent } from "./paginas/preguntas/preguntas.component";
import { ConocenosComponent } from "./paginas/conocenos/conocenos.component";

export const routes: Routes = [
    { path: 'inicio', component: InicioComponent},
    { path: 'productos', component: ProductosComponent},
    { path: 'conocenos', component: ConocenosComponent},
    { path: 'preguntas', component: PreguntasComponent},
    //ruta por defecto
    { path: '', redirectTo: '/inicio', pathMatch: 'full'}
];
