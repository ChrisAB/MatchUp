const { Router } = require('express');
const authController = require('../controllers/authController');
const roomController = require('../controllers/roomController');

const router = new Router();

router.route('/').get(roomController.getRooms)
  .post(roomController.createRoom);
router.route('/:id').get(authController.protect, roomController.getRoom)
  .patch(authController.protect, roomController.modifyRoom)
  .delete(authController.protect, roomController.deleteRoom);

module.exports = router;