const catchAsync = require("../utils/catchAsync");
const AppError = require("../utils/appError");
const Dungeon = require("../models/dungeonModel");
const {generateRoomsAndLoot} = require("../utils/generators");

exports.getDungeons = catchAsync(async (req, res, next) => {
  const dungeons = await Dungeon.find();
  res.status(200).json({ status: 'success', data: { dungeons: dungeons } });
});

exports.getDungeon = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const dungeon = await Dungeon.findById(id);
  res.status(200).json({ status: 'success', data: { dungeon: dungeon } });
});

exports.createDungeon = catchAsync(async (req, res, next) => {
  const {level, type, size} = req.body;
  let dungeon = await Dungeon.create({
    user: req.user._id,
    level: level,
    type: type,
    size: size,
    enabled: true
  });
  const roomsAndLoot = await generateRoomsAndLoot(dungeon);
  dungeon = await Dungeon.findByIdAndUpdate(id, {rooms: roomsAndLoot});
  res.status(200).json({ status: 'success', data: { dungeon: dungeon } });
});

exports.modifyDungeon = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  const query = req.query;
  const dungeon = await Dungeon.findByIdAndUpdate(id, query);
  res.status(200).json({ status: 'success', data: { dungeon: dungeon } });
});

exports.deleteDungeon = catchAsync(async (req, res, next) => {
  const {id} = req.params;
  await Dungeon.findByIdAndDelete(id);
  res.status(200).json({ status: 'success', data: { dungeon: null } });
});