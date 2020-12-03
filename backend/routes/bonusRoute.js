const { Router } = require('express');
const authController = require('../controllers/authController');
const bonusController = require('../controllers/bonusController');

const router = new Router();

router.route('/').get(bonusController.getBonuses)
  .post(bonusController.createBonus);
router.route('/:id').get(authController.protect, bonusController.getBonus)
  .patch(authController.protect, bonusController.modifyBonus)
  .delete(authController.protect, bonusController.deleteBonus);

module.exports = router;