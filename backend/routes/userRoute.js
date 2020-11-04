const { Router } = require('express');
const userController = 

const router = new Router();

router.route('/').get(protect, userController.getUsers);

module.exports = router;