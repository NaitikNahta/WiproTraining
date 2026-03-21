import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-new-hobby',
  standalone: false,
  templateUrl: './new-hobby.html',
  styleUrls: ['./new-hobby.css']
})
export class NewHobby {
  newHobby: string = '';
  successMsg: string = '';

  @Output() hobbyAdded = new EventEmitter<string>();

  onAdd() {
    const trimmed = this.newHobby.trim();

    if (!trimmed) return;

    this.hobbyAdded.emit(trimmed);

    this.newHobby = '';
    this.successMsg = `"${trimmed}" added to your hobbies!`;

    setTimeout(() => {
      this.successMsg = '';
    }, 2000);
  }
}
