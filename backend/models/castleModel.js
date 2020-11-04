const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const castleSchema = new Schema({
  user: { type: ObjectId, ref: 'User' },
  gridLevel: { type: Number },
  heroes: [{ type: ObjectId, ref: 'UserHero' }],
  size: [{ x: { type: Number }, y: { type: Number } }],
  items: [{ itemType: { type: ObjectId, ref: 'Item' }, position: { x: { type: Number }, y: { type: Number } } }],
});

const Castle = mongoose.model("Castle", castleSchema);

module.exports = Castle;
