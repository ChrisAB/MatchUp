const { Router } = require('express');
const authController = require('../controllers/authController');
const itemController = require('../controllers/itemController');

const router = new Router();

router.route('/').get(itemController.getItems)
  .post(itemController.createItem);
router.route('/:id').get(authController.protect, itemController.getItem)
  .patch(authController.protect, itemController.modifyItem)
  .delete(authController.protect, itemController.deleteItem);

module.exports = router;