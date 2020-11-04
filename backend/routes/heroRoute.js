const { Router } = require('express');
const authController = require('../controllers/authController');
const heroController = require('../controllers/heroController');

const router = new Router();

router.route('/').get(heroController.getHeroes)
  .post(heroController.createHero);
router.route('/:id').get(authController.protect, heroController.getHero)
  .patch(authController.protect, heroController.modifyHero)
  .delete(authController.protect, heroController.deleteHero);

module.exports = router;