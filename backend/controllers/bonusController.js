const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const Bonus = require("../models/bonusModel");

exports.getBonuses = catchAsync(async (req, res, next) => {
  const bonuses = await Bonus.find();
  res.status(200).json({ status: 'success', data: { bonuses: bonuses } });
});

exports.getBonus = catchAsync(async (req, res, next) => {
  const { id } = req.params;
  const bonus = await Bonus.findById(id);
  res.status(200).json({ status: 'success', data: { bonus: bonus } });
});

exports.createBonus = catchAsync(async (req, res, next) => {
  const {description} = req.body;
  const bonus = await Bonus.create({ description: description});
  res.status(200).json({ status: 'success', data: { bonus: bonus } });
});

exports.modifyBonus = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const {modifiers} = req.body;
  const bonus = await Bonus.findByIdAndUpdate(id, {$set: modifiers});
  res.status(200).json({ status: 'success', data: { bonus: bonus } });
});

exports.deleteBonus = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  await Bonus.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { bonus: null } });
});