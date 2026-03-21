import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Hobby {
  id?: number;
  name: string;
  isFavourite: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class HobbyService {
  private url = 'http://localhost:3001/hobbies';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Hobby[]> {
    return this.http.get<Hobby[]>(this.url);
  }

  add(hobby: Hobby): Observable<Hobby> {
    return this.http.post<Hobby>(this.url, hobby);
  }

  update(hobby: Hobby): Observable<Hobby> {
    return this.http.put<Hobby>(`${this.url}/${hobby.id}`, hobby);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}