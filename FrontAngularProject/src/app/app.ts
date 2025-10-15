import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Productcomponent } from './components/productcomponent/productcomponent';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Productcomponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('FrontAngularProject');
}
