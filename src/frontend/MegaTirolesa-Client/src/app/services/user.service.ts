import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../models/IUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly _httpClient = inject(HttpClient);
  readonly apiUrl = 'https://localhost:7103/api'

  getUsers(): Observable<{ data: IUser[]; isSuccess: boolean; message: string}>{
    return this._httpClient.get<{ data: IUser[]; isSuccess: boolean; message: string}>(`${this.apiUrl}/users`);
  }
}
