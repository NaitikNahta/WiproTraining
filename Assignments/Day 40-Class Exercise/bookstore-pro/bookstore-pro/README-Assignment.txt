BookStore Pro - Angular Assignment

Features completed:
1. DataService implemented for GET call returning Observable.
2. AuthInterceptor implemented to add dummy Authorization header.
3. BooksComponent demonstrates:
   - Manual subscribe + cleanup in ngOnDestroy
   - async pipe usage
4. Built-in pipes used:
   - UpperCasePipe
   - CurrencyPipe
   - DatePipe
   - SlicePipe
5. Custom pipe used:
   - DiscountPipe
6. Parent-child communication:
   - BooksComponent passes each book to BookCardComponent using @Input
7. Component-specific styling added.

Run steps:
- npm install
- ng serve -o
