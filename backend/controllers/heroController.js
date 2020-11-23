const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const Hero = require("../models/heroModel");

exports.getHeroes = catchAsync(async (req, res, next) => {
  const query = req.query;
  const heroes = await Hero.find({ query });
  res.status(200).json({ status: 'success', data: { heroes } });
});

exports.getHero = catchAsync(async (req, res, next) => {
  const { id } = req.params;
  const hero = await Hero.findById(id);
  if (!hero) return next(new AppError("No such hero", 404));
  res.status(200).json({ status: 'success', data: { hero } });
});

exports.createHero = catchAsync(async (req, res, next) => {
  const { name, elementType, healthPoints, passives, basicAttack, specialAttack, ultimateAttack, description, costs } = req.body;
  const hero = await Hero.create({
    name,
    elementType,
    healthPoints,
    passives,
    basicAttack,
    specialAttack,
    ultimateAttack,
    description,
    costs
  });
  if (!hero) return next(new AppError("Could not create Hero", 400));
  res.status(200).json({ status: 'success', data: { hero } });
});

exports.modifyHero = catchAsync(async (req, res, next) => {
  const query = req.body;
  const { id } = req.params;
  const hero = await Hero.findByIdAndUpdate(id, query);
  res.status(200).json({ status: 'success', data: { hero } });
});

exports.deleteHero = catchAsync(async (req, res, next) => {
  const { id } = req.params;
  const hero = await Hero.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { hero: null } });
});