const express = require('express');
const courseRouter = require('./routes/courses');

const app = express();
app.use(express.json());

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to SkillSphere LMS API' });
});

app.use('/courses', courseRouter);

app.listen(4000, () => {
  console.log('Server running on http://localhost:4000');
});