const { Router } = require('express');
const authController = require('../controllers/authController');
const userController = require('../controllers/userController');

const router = new Router();

router.route('/').get(userController.getUsers)
  .post(userController.createUser);
router.route('/:id').get(authController.protect, userController.getUser)
  .patch(authController.protect, userController.modifyUser)
  .delete(authController.protect, userController.deleteUser);

module.exports = router;