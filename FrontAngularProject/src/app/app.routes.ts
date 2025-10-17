import { Routes } from '@angular/router';
import { Procesadorcomponent } from './components/procesadorcomponent/procesadorcomponent';
import { Placabasecomponent } from './components/placabasecomponent/placabasecomponent';

export const routes: Routes = [
    { path: '', redirectTo: '/procesador', pathMatch: 'full' },
    {path: 'procesador', component: Procesadorcomponent},
    {path: 'placabase', component: Placabasecomponent},
];
