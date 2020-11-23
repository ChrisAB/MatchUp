const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const roomSchema = new Schema({
  user: { type: ObjectId, ref: 'User' },
  dungeon: { type: ObjectId, ref: 'Dungeon' },
  monsters: [{ type: ObjectId, ref: 'Monster' }],
  reward: [{ type: String }],
  type: { type: String },
});

const Room = mongoose.model("Room", roomSchema);

module.exports = Room;
