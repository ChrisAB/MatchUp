const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const monsterSchema = new Schema({
  name: { type: String, required: [true, "Every monster needs an name"] },
});

const Monster = mongoose.model("Monster", monsterSchema);

module.exports = Monster;
