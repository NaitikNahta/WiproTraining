import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Book } from '../../models/book';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit, OnDestroy {
  books$!: Observable<Book[]>;
  manualBooks: Book[] = [];
  private booksSubscription?: Subscription;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.books$ = this.dataService.getBooks();

    this.booksSubscription = this.dataService.getBooks().subscribe({
      next: (response: Book[]) => {
        this.manualBooks = response;
      },
      error: (error) => {
        console.error('Error fetching books:', error);
      }
    });
  }

  ngOnDestroy(): void {
    if (this.booksSubscription) {
      this.booksSubscription.unsubscribe();
      console.log('Manual subscription unsubscribed successfully.');
    }
  }
}
