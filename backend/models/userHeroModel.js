const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const userHeroSchema = new Schema({
  user: { type: ObjectId, ref: 'User' },
  hero: { type: ObjectId, ref: 'Hero' },
  level: { type: Number },
  healthPoints: { type: Number }
});

const UserHero = mongoose.model("UserHero", userHeroSchema);

module.exports = UserHero;
