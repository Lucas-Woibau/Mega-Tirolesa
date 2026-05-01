import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserListComponent } from "./components/users/user-list/user.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, UserListComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('MegaTirolesa-Client');
}
