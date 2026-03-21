import { Component, OnInit } from '@angular/core';
import { HobbyService, Hobby } from './services/hobby.service';

@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App implements OnInit {
  activeView: string = 'myhobbies';
  hobbies: Hobby[] = [];

  constructor(private hobbyService: HobbyService) {}

  ngOnInit() {
    this.hobbyService.getAll().subscribe({
      next: (res) => this.hobbies = res,
      error: (err) => console.error('Failed to load hobbies', err)
    });
  }

  onButtonClicked(view: string) {
    this.activeView = view;
  }

  onHobbyAdded(name: string) {
    const newHobby: Hobby = { name, isFavourite: false };
    this.hobbyService.add(newHobby).subscribe({
      next: (saved) => this.hobbies = [...this.hobbies, saved],
      error: (err) => console.error('Failed to add hobby', err)
    });
  }

  onHobbyDeleted(id: number) {
    this.hobbyService.delete(id).subscribe({
      next: () => this.hobbies = this.hobbies.filter(h => h.id !== id),
      error: (err) => console.error('Failed to delete hobby', err)
    });
  }

  onHobbyUpdated(updated: Hobby) {
    this.hobbyService.update(updated).subscribe({
      next: (saved) => {
        this.hobbies = this.hobbies.map(h => h.id === saved.id ? saved : h);
      },
      error: (err) => console.error('Failed to update hobby', err)
    });
  }

  onHobbyFavToggled(hobby: Hobby) {
    const toggled = { ...hobby, isFavourite: !hobby.isFavourite };
    this.hobbyService.update(toggled).subscribe({
      next: (saved) => {
        this.hobbies = this.hobbies.map(h => h.id === saved.id ? saved : h);
      },
      error: (err) => console.error('Failed to update favourite', err)
    });
  }
}