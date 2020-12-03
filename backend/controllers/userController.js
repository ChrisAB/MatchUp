const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const User = require("../models/userModel");
const {generateStartingResources ,generateStartingCastle} = require("../utils/generators");

exports.getUsers = catchAsync(async (req, res, next) => {
  const query = req.query;
  const users = await User.find(query);
  res.status(200).json({ status: 'success', data: { users: users } });
});

exports.getUser = catchAsync(async (req, res, next) => {
  const {id} = req.query;
  const user = await User.findById(id);
  res.status(200).json({ status: 'success', data: { user: user } });
});

exports.createUser = catchAsync(async (req, res, next) => {
  const {username, googleToken} = req.body;
  const resources = await generateStartingResources();
  let user = await User.create({
    username: username,
    googleToken: googleToken,
    resources: resources,
  });
  const castle = await generateStartingCastle(user);
  user = await User.findByIdAndUpdate(user._id, {castle: castle._id});
  res.status(200).json({ status: 'success', data: { user: user } });
});

exports.modifyUser = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const query = req.query;
  const user = await User.findByIdAndUpdate(id, query);
  res.status(200).json({ status: 'success', data: { user: user } });
});

exports.deleteUser = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  await User.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { user: null } });
});