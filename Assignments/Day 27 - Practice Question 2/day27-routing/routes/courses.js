const express = require('express');
const router = express.Router();

const validateCourseId = (req, res, next) => {
  const { id } = req.params;
  if (!/^\d+$/.test(id)) {
    return res.status(400).json({ error: 'Invalid course ID' });
  }
  next();
};

router.get('/:id', validateCourseId, (req, res) => {
  res.json({
    id: req.params.id,
    name: 'React Mastery',
    duration: '6 weeks'
  });
});

module.exports = router;