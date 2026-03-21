import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-menu',
  standalone: false,
  templateUrl: './menu.html',
  styleUrls: ['./menu.css']
})
export class Menu {
  @Output() buttonClicked = new EventEmitter<string>();

  activeButton: string = 'myhobbies';

  onButtonClick(view: string) {
    this.activeButton = view;
    this.buttonClicked.emit(view);
  }
}
