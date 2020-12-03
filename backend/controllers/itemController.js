const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const Item = require("../models/itemModel");

exports.getItems = catchAsync(async (req, res, next) => {
  const query = req.query;
  const items = await Item.find(query);
  res.status(200).json({ status: 'success', data: { items: items } });
});

exports.getItem = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const item = await Item.findById(id);
  res.status(200).json({ status: 'success', data: { item: item } });
});

exports.createItem = catchAsync(async (req, res, next) => {
  const {name, bonuses, costs, size, enabled} = req.body;
  const item = await Item.create({
    name: name,
    bonuses: bonuses,
    costs: costs,
    size: size,
    enabled: enabled != undefined ? enabled : false
  });
  res.status(200).json({ status: 'success', data: { item: item } });
});

exports.modifyItem = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const query = req.query;
  const item = await Item.findByIdAndUpdate(id, query);
  res.status(200).json({ status: 'success', data: { item: item } });
});

exports.deleteItem = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  await Item.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { item: null } });
});