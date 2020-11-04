const { Router } = require('express');
const authController = require('../controllers/authController');
const monsterController = require('../controllers/monsterController');

const router = new Router();

router.route('/').get(monsterController.getMonsters)
  .post(monsterController.createMonster);
router.route('/:id').get(authController.protect, monsterController.getMonster)
  .patch(authController.protect, monsterController.modifyMonster)
  .delete(authController.protect, monsterController.deleteMonster);

module.exports = router;