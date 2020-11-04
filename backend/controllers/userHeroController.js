const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getUserHeroes = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { userHeroes: null } });
});

exports.getUserHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { userHero: null } });
});

exports.createUserHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { userHero: null } });
});

exports.modifyUserHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { userHero: null } });
});

exports.deleteUserHero = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { userHero: null } });
});