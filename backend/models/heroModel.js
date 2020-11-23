const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const heroSchema = new Schema({
  name: { type: String, required: [true, "Every hero needs an name"] },
  elementType: { type: String },
  healthPoints: { type: Number },
  passives: [{ type: { type: String }, amount: { type: Number } }],
  basicAttack: { type: { type: String }, damage: { type: Number }, bonuses: [{ type: String }] },
  specialAttack: { type: { type: String }, damage: { type: Number }, bonuses: [{ type: String }] },
  ultimateAttack: { type: { type: String }, damage: { type: Number }, bonuses: [{ type: String }], matchRequirement: { type: Number } },
  description: { type: String },
  costs: [{ type: { type: String }, amount: { type: Number } }],
  enabled: { type: Boolean, default: true }
});

const Hero = mongoose.model("Hero", heroSchema);

module.exports = Hero;
