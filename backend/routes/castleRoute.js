const { Router } = require('express');
const authController = require('../controllers/authController');
const castleController = require('../controllers/castleController');

const router = new Router();

router.route('/').get(castleController.getCastles)
  .post(castleController.createCastle);
router.route('/:id').get(authController.protect, castleController.getCastle)
  .patch(authController.protect, castleController.modifyCastle)
  .delete(authController.protect, castleController.deleteCastle);

module.exports = router;