const fs = require('fs').promises;
const path = require('path');
const { EventEmitter } = require('events');

const bookEmitter = new EventEmitter();

bookEmitter.on('Book Added', (book) => {
  console.log(`[EVENT] Book Added: "${book.title}" by ${book.author}`);
});

bookEmitter.on('Book Updated', (id) => {
  console.log(`[EVENT] Book Updated: ID ${id}`);
});

bookEmitter.on('Book Deleted', (id) => {
  console.log(`[EVENT] Book Deleted: ID ${id}`);
});

const filePath = path.join(__dirname, '../data/books.json');

const readBooks = async () => {
  const data = await fs.readFile(filePath, 'utf-8');
  return JSON.parse(data);
};

const writeBooks = async (books) => {
  await fs.writeFile(filePath, JSON.stringify(books, null, 2));
};

module.exports = { readBooks, writeBooks, bookEmitter };