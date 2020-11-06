const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const userSchema = new Schema({
  username: { type: String, required: [true, "Every user needs an username"] },
  googleToken: { type: String },
  castle: { type: ObjectId, ref: 'Castle' },
  heroes: [{ type: ObjectId, ref: 'UserHero' }],
  unlockedHeroes: [{ type: ObjectId, ref: 'Hero' }],
  resources: [{ type: { type: String }, amount: { type: Number } }],
  enabled: { type: Boolean, default: true }
});

const User = mongoose.model("User", userSchema);

module.exports = User;
