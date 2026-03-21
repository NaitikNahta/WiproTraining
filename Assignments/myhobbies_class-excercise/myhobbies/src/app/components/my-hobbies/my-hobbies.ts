import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Hobby } from '../../services/hobby.service';

@Component({
  selector: 'app-my-hobbies',
  standalone: false,
  templateUrl: './my-hobbies.html',
  styleUrls: ['./my-hobbies.css']
})
export class MyHobbies {
  @Input() hobbies: Hobby[] = [];

  @Output() hobbyDeleted    = new EventEmitter<number>();
  @Output() hobbyUpdated    = new EventEmitter<Hobby>();
  @Output() hobbyFavToggled = new EventEmitter<Hobby>();

  editingId: number = -1;
  editingValue: string = '';

  onEdit(hobby: Hobby) {
    this.editingId = hobby.id!;
    this.editingValue = hobby.name;
  }

  onSave(hobby: Hobby) {
    const trimmed = this.editingValue.trim();
    if (!trimmed) return;
    this.hobbyUpdated.emit({ ...hobby, name: trimmed });
    this.editingId = -1;
    this.editingValue = '';
  }

  onCancel() {
    this.editingId = -1;
    this.editingValue = '';
  }

  onDelete(id: number)          { this.hobbyDeleted.emit(id); }
  onToggleFav(hobby: Hobby)     { this.hobbyFavToggled.emit(hobby); }
}