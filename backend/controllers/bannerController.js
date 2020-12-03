const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const Banner = require("../models/bannerModel");

exports.getBanners = catchAsync(async (req, res, next) => {
  const query = req.query;
  const banners = await Banner.find(query);
  res.status(200).json({ status: 'success', data: { banners: banners } });
});

exports.getBanner = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const banner = await Banner.findOne(id);
  res.status(200).json({ status: 'success', data: { banner: banner } });
});

exports.createBanner = catchAsync(async (req, res, next) => {
  const {name, heroes, odds, costs, enabled} = req.body;
  const banner = await Banner.create({
    name: name,
    heroes: heroes,
    odds: odds,
    costs: costs,
    enabled: enabled != undefined ? enabled : false,
  });
  res.status(200).json({ status: 'success', data: { banner: banner } });
});

exports.modifyBanner = catchAsync(async (req, res, next) => {
  const query = req.body;
  const {id} = req.params;
  const banner = await Banner.findByIdAndUpdate(id, query);
  res.status(200).json({ status: 'success', data: { banner: banner } });
});

exports.deleteBanner = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  await Banner.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { banner: null } });
});