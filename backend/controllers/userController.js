const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getUsers = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { users: null } });
});

exports.getUser = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { user: null } });
});

exports.createUser = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { user: null } });
});

exports.modifyUser = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { user: null } });
});

exports.deleteUser = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { user: null } });
});