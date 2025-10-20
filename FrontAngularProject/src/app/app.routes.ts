import { Routes } from '@angular/router';
import { Procesadorcomponent } from './components/procesadorcomponent/procesadorcomponent';
import { Placabasecomponent } from './components/placabasecomponent/placabasecomponent';
import { Memoriaramcomponent } from './components/memoriaramcomponent/memoriaramcomponent';
import { Almacenamientocomponent } from './components/almacenamientocomponent/almacenamientocomponent';
import { Graficacomponent } from './components/graficacomponent/graficacomponent';

export const routes: Routes = [
    { path: '', redirectTo: '/procesador', pathMatch: 'full' },
    {path: 'procesador', component: Procesadorcomponent},
    {path: 'placabase', component: Placabasecomponent},
    {path: 'memoriaram',component: Memoriaramcomponent},
    {path: 'almacenamiento',component: Almacenamientocomponent},
    {path: 'grafica',component: Graficacomponent},
];
