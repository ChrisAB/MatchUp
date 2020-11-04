const { Router } = require('express');
const authController = require('../controllers/authController');
const bannerController = require('../controllers/bannerController');

const router = new Router();

router.route('/').get(bannerController.getBanners)
  .post(bannerController.createBanner);
router.route('/:id').get(authController.protect, bannerController.getBanner)
  .patch(authController.protect, bannerController.modifyBanner)
  .delete(authController.protect, bannerController.deleteBanner);

module.exports = router;