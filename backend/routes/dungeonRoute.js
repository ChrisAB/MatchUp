const { Router } = require('express');
const authController = require('../controllers/authController');
const dungeonController = require('../controllers/dungeonController');

const router = new Router();

router.route('/').get(dungeonController.getDungeons)
  .post(dungeonController.createDungeon);
router.route('/:id').get(authController.protect, dungeonController.getDungeon)
  .patch(authController.protect, dungeonController.modifyDungeon)
  .delete(authController.protect, dungeonController.deleteDungeon);

module.exports = router;