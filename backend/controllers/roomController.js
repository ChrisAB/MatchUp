const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getRooms = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { rooms: null } });
});

exports.getRoom = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { room: null } });
});

exports.createRoom = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { room: null } });
});

exports.modifyRoom = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { room: null } });
});

exports.deleteRoom = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { room: null } });
});