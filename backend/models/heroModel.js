const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const heroSchema = new Schema({
  name: { type: String, required: [true, "Every hero needs an name"] },
});

const Hero = mongoose.model("Hero", heroSchema);

module.exports = Hero;
