import { Component, inject, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { IUser } from '../../../models/IUser';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserListComponent implements OnInit {
  readonly _userService = inject(UserService);
  users: IUser[] = [];

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(){
    this._userService
      .getUsers().subscribe({
        next: response => {
          this.users = response.data;
        },

        error: error => {
          console.error('Error to search users', error);
        }
      });
  }
}
