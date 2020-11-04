const mongoose = require('mongoose');
const { ObjectId } = require('mongodb');
const Schema = mongoose.Schema;

const bannerSchema = new Schema({
  name: { type: String, required: [true, "Every hero needs an name"] },
  heroes: [{ type: ObjectId, ref: 'Hero' }],
  odds: [{ type: Number }],
  costs: [{ currencyType: { type: String }, currencyAmount: { type: Number } }],
});

const Banner = mongoose.model("Banner", bannerSchema);

module.exports = Banner;
