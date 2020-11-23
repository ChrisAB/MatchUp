const fs = require('fs');
const Hero = require('../models/heroModel');
const Banner = require('../models/bannerModel');
const Item = require('../models/itemModel');
const Monster = require('../models/monsterModel');

exports.loadHeroes = async (err, data) => {
  if (err) {
    console.log(err);
    return;
  }
  const heroes = JSON.parse(data);
  heroes.forEach(hero => {
    Hero.create(hero);
  });
};

exports.loadBanners = async (err, data) => {
  if (err) {
    console.log(err);
    return;
  }
  const banners = JSON.parse(data);
  banners.forEach(banner => {
    Banner.create(banner);
  });
};

exports.loadItems = async (err, data) => {
  if (err) {
    console.log(err);
    return;
  }
  const items = JSON.parse(data);
  items.forEach(item => {
    Item.create(item);
  });
};

exports.loadMonsters = async (err, data) => {
  if (err) {
    console.log(err);
    return;
  }
  const monsters = JSON.parse(data);
  monsters.forEach(monster => {
    Monster.create(monster);
  });
};

exports.dumpDatabase = async () => {

};

const args = process.argv.slice(2);

console.log(args);
if (args.length > 0) {
  fs.readFile(args[0], this.loadHeroes);
}