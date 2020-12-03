const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const itemSchema = new Schema({
  name: { type: String },
  bonuses: [{ bonusType: { type: String }, bonusAmount: { type: Number } }],
  costs: [{ costType: { type: String }, costAmount: { type: Number } }],
  size: [{ x: { type: Number }, y: { type: Number } }],
  enabled: { type: Boolean, default: true }
});

const Item = mongoose.model("Item", itemSchema);

module.exports = Item;
