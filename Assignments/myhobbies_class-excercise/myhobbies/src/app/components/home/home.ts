import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Hobby } from '../../services/hobby.service';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.html',
  styleUrls: ['./home.css']
})
export class Home {
  @Input() activeView: string = '';
  @Input() hobbies: Hobby[] = [];

  @Output() hobbyAdded      = new EventEmitter<string>();
  @Output() hobbyDeleted    = new EventEmitter<number>();
  @Output() hobbyUpdated    = new EventEmitter<Hobby>();
  @Output() hobbyFavToggled = new EventEmitter<Hobby>();

  onHobbyAdded(name: string)       { this.hobbyAdded.emit(name); }
  onHobbyDeleted(id: number)       { this.hobbyDeleted.emit(id); }
  onHobbyUpdated(hobby: Hobby)     { this.hobbyUpdated.emit(hobby); }
  onHobbyFavToggled(hobby: Hobby)  { this.hobbyFavToggled.emit(hobby); }
}