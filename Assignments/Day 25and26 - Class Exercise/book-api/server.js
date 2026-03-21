const express = require('express');
const { readBooks, writeBooks, bookEmitter } = require('./services/bookService');

const app = express();
app.use(express.json());

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to Book Management API' });
});

app.get('/books', async (req, res) => {
  try {
    const books = await readBooks();
    res.json(books);
  } catch (error) {
    res.status(500).json({ error: 'Failed to read books' });
  }
});

app.get('/books/:id', async (req, res) => {
  try {
    const books = await readBooks();
    const book = books.find(b => b.id === parseInt(req.params.id));
    if (!book) return res.status(404).json({ error: 'Book not found' });
    res.json(book);
  } catch (error) {
    res.status(500).json({ error: 'Failed to read book' });
  }
});

app.post('/books', async (req, res) => {
  try {
    const { title, author } = req.body;
    if (!title || !author) {
      return res.status(400).json({ error: 'Title and author are required' });
    }
    const books = await readBooks();
    const newBook = {
      id: books.length > 0 ? books[books.length - 1].id + 1 : 1,
      title,
      author
    };
    books.push(newBook);
    await writeBooks(books);
    bookEmitter.emit('Book Added', newBook);
    res.status(201).json(newBook);
  } catch (error) {
    res.status(500).json({ error: 'Failed to add book' });
  }
});

app.put('/books/:id', async (req, res) => {
  try {
    const books = await readBooks();
    const index = books.findIndex(b => b.id === parseInt(req.params.id));
    if (index === -1) return res.status(404).json({ error: 'Book not found' });
    books[index] = { ...books[index], ...req.body };
    await writeBooks(books);
    bookEmitter.emit('Book Updated', req.params.id);
    res.json(books[index]);
  } catch (error) {
    res.status(500).json({ error: 'Failed to update book' });
  }
});

app.delete('/books/:id', async (req, res) => {
  try {
    const books = await readBooks();
    const index = books.findIndex(b => b.id === parseInt(req.params.id));
    if (index === -1) return res.status(404).json({ error: 'Book not found' });
    books.splice(index, 1);
    await writeBooks(books);
    bookEmitter.emit('Book Deleted', req.params.id);
    res.json({ message: `Book with ID ${req.params.id} deleted successfully` });
  } catch (error) {
    res.status(500).json({ error: 'Failed to delete book' });
  }
});

app.listen(3000, () => {
  console.log('Server running on http://localhost:3000');
});