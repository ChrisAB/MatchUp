const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getHeroes = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { heroes: null } });
});

exports.getHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { hero: null } });
});

exports.createHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { hero: null } });
});

exports.modifyHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { hero: null } });
});

exports.deleteHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { hero: null } });
});