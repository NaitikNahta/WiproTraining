# Book Management REST API

## Setup
npm install
npm start

## API Endpoints

| Method | Endpoint      | Description        |
|--------|---------------|--------------------|
| GET    | /             | Welcome message    |
| GET    | /books        | Get all books      |
| GET    | /books/:id    | Get book by ID     |
| POST   | /books        | Add a new book     |
| PUT    | /books/:id    | Update a book      |
| DELETE | /books/:id    | Delete a book      |

## POST/PUT Body Example
{
  "title": "Clean Code",
  "author": "Robert Martin"
}