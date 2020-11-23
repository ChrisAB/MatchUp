const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getCastles = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { castles: null } });
});

exports.getCastle = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { castle: null } });
});

exports.createCastle = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { castle: null } });
});

exports.modifyCastle = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { castle: null } });
});

exports.deleteCastle = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { castle: null } });
});