const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const { elementTypesEnum, monsterTypesEnum } = require('../utils/validators');
const Schema = mongoose.Schema;

const monsterSchema = new Schema({
  name: { type: String, required: [true, "Every hero needs an name"] },
  type: { type: String, enum: monsterTypesEnum },
  elementType: { type: String, enum: elementTypesEnum },
  healthPoints: { type: Number },
  passives: [{ type: { type: String }, amount: { type: Number } }],
  basicAttack: { type: { type: String, enum: elementTypesEnum }, damage: { type: Number }, bonuses: [{ type: String }] },
  specialAttack: { type: { type: String, enum: elementTypesEnum }, damage: { type: Number }, bonuses: [{ type: String }] },
  ultimateAttack: { type: { type: String, enum: elementTypesEnum }, damage: { type: Number }, bonuses: [{ type: String }], matchRequirement: { type: Number } },
  description: { type: String, max: 255 },
  enabled: { type: Boolean, default: true }
});

const Monster = mongoose.model("Monster", monsterSchema);

module.exports = Monster;
