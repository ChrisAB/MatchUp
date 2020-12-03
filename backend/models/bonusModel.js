const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const bonusSchema = new Schema({
  description: { type: String, required: [true, "Every hero needs an name"] }
});

const Bonus = mongoose.model("Bonus", bonusSchema);

module.exports = Bonus;
