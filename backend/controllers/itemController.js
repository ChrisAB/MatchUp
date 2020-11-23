const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getItems = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { items: null } });
});

exports.getItem = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { item: null } });
});

exports.createItem = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { item: null } });
});

exports.modifyItem = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { item: null } });
});

exports.deleteItem = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { item: null } });
});