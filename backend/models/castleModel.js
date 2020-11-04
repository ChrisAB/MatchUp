const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const castleSchema = new Schema({
  user: { type: ObjectId, ref: 'User' },
  level: { type: Number },
  type: { type: String },
  rooms: [{ item: { type: ObjectId, ref: 'Item' }, position: { x: { type: Number }, y: { type: Number } } }]
});

const Castle = mongoose.model("Castle", castleSchema);

module.exports = Castle;
