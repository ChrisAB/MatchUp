const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const userSchema = new Schema({
  username: { type: String, required: [true, "Every user needs an username"] },
  googleToken: { type: String },
  castle: { type: ObjectId, ref: 'Castle' }
});

const User = mongoose.model("User", userSchema);

module.exports = User;
