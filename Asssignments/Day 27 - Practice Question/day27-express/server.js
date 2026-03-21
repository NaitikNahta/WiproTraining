const express = require('express');
const bookRouter = require('./routes/books');

const app = express();
app.use(express.json());

app.use((req, res, next) => {
  const timestamp = new Date().toISOString();
  console.log(`[${timestamp}] [${req.method}] ${req.url}`);
  next();
});

app.get('/', (req, res) => {
  res.send('Welcome to Express Server');
});

app.get('/status', (req, res) => {
  res.json({ server: 'running', uptime: 'OK' });
});

app.get('/products', (req, res) => {
  const { name } = req.query;
  if (name) {
    res.json({ query: name });
  } else {
    res.json({ message: 'Please provide a product name' });
  }
});

app.use('/books', bookRouter);

app.use((req, res) => {
  res.status(404).json({ error: 'Route not found' });
});

app.use((err, req, res, next) => {
  console.error(err.stack);
  res.status(500).json({ error: 'Internal Server Error' });
});

app.listen(4000, () => {
  console.log('Server running on http://localhost:4000');
});