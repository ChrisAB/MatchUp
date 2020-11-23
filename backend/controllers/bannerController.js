const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getBanners = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { banners: null } });
});

exports.getBanner = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { banner: null } });
});

exports.createBanner = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { banner: null } });
});

exports.modifyBanner = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { banner: null } });
});

exports.deleteBanner = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { banner: null } });
});