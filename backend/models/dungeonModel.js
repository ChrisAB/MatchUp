const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const dungeonSchema = new Schema({
  user: { type: ObjectId, ref: 'User' },
  level: { type: Number },
  type: { type: String },
  size: { x: { type: Number }, y: { type: Number } },
  rooms: [{ room: { type: ObjectId, ref: 'Room' }, loot: { type: { type: String }, amount: { type: Number } }, position: { x: { type: Number }, y: { type: Number } } }],
  active: { type: Boolean, default: true }
});

const Dungeon = mongoose.model("Dungeon", dungeonSchema);

module.exports = Dungeon;
