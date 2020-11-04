const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const dungeonSchema = new Schema({
  name: { type: String, required: [true, "Every hero needs an name"] },
});

const Dungeon = mongoose.model("Dungeon", dungeonSchema);

module.exports = Dungeon;
