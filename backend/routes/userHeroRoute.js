const { Router } = require('express');
const authController = require('../controllers/authController');
const userHeroController = require('../controllers/userHeroController');

const router = new Router();

router.route('/').get(userHeroController.getUserHeroes)
  .post(userHeroController.createUserHero);
router.route('/:id').get(authController.protect, userHeroController.getUserHero)
  .patch(authController.protect, userHeroController.modifyUserHero)
  .delete(authController.protect, userHeroController.deleteUserHero);

module.exports = router;