import { Component, Input } from '@angular/core';
import { Hobby } from '../../services/hobby.service';

@Component({
  selector: 'app-fav-hobbies',
  standalone: false,
  templateUrl: './fav-hobbies.html',
  styleUrls: ['./fav-hobbies.css']
})
export class FavHobbies {
  @Input() hobbies: Hobby[] = [];

  get favHobbies(): Hobby[] {
    return this.hobbies.filter(h => h.isFavourite);
  }
}