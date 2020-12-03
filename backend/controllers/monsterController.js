const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const Monster = require("../models/monsterModel");

exports.getMonsters = catchAsync(async (req, res, next) => {
  const query = req.query;
  const monsters = await Monster.find(query);
  res.status(200).json({ status: 'success', data: { monsters } });
});

exports.getMonster = catchAsync(async (req, res, next) => {
  const { id } = req.params;
  const monster = await Monster.find(id);
  if (!monster) return next(new AppError("Monster not found", 404));
  res.status(200).json({ status: 'success', data: { monster } });
});

exports.createMonster = catchAsync(async (req, res, next) => {
  const { name, type, elementType, healthPoints, passives, basicAttack, specialAttack, ultimateAttack, description, enabled } = req.body;
  const monster = await Monster.create({
    name,
    type,
    elementType,
    healthPoints,
    passives,
    basicAttack,
    specialAttack,
    ultimateAttack,
    description,
    enabled: enabled != undefined ? enabled : false
  })
  res.status(200).json({ status: 'success', data: { monster } });
});

exports.modifyMonster = catchAsync(async (req, res, next) => {
  const { id } = req.params;
  const query = req.body;
  const monster = await Monster.findByIdAndUpdate(id, query);
  res.status(200).json({ status: 'success', data: { monster } });
});

exports.deleteMonster = catchAsync(async (req, res, next) => {
  const { id } = req.params;
  await Monster.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { monster: null } });
});