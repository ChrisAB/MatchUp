const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");

exports.getDungeons = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { dungeons: null } });
});

exports.getDungeon = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { dungeon: null } });
});

exports.createDungeon = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { dungeon: null } });
});

exports.modifyDungeon = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { dungeon: null } });
});

exports.deleteDungeon = catchAsync(async (req, res, next) => {
  res.status(200).json({ status: 'success', data: { dungeon: null } });
});