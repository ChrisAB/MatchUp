const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getMonsters = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { monsters: null } });
});

exports.getMonster = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { monster: null } });
});

exports.createMonster = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { monster: null } });
});

exports.modifyMonster = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { monster: null } });
});

exports.deleteMonster = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { monster: null } });
});