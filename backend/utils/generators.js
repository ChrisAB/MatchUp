const Castle = require("../models/castleModel");
const Room = require("../models/roomModel");
const Monster = require("../models/monsterModel");

exports.generateRoom = async (dungeon) => {
  const monsters = await this.generateMonsters(dungeon, 4);
  const reward = this.generateReward(dungeon);
  return {monsters, reward, type: 'normal'};
}

exports.generateMonsters = async (dungeon, numberOfMonsters) => {
  const numberOfMonstersInDatabase = await Monster.count();
  let monsters = [];
  let monster;
  for(let i=0;i<numberOfMonsters; i++) {
    monster = await Monster.findOne().skip(Math.random()*numberOfMonstersInDatabase);
    monsters.push(monster._id);
  }
  return monsters;
}

exports.generateReward = (dungeon) => {
  return ['100 wood', '100 metal', '100 coin'];
}

exports.generateExitRoom = async (dungeon) => {
  const x = Math.random() * (dungeon.size.x - 0) + 0;
  const y = Math.random() * (dungeon.size.y - 0) + 0;
  const monsters = this.generateMonsters(dungeon, 4);
  const reward = this.generateReward(dungeon);
  const room = await Room.create({
    user: dungeon.user,
    dunegon: dungeon._id,
    monsters: monsters,
    reward: reward,
    type: 'exit'
  });
  return {room: room, loot: {type: 'Nothing', amount: 0}, position: {x: x, y: y}};
}

exports.generateRoomsAndLoot = async (dungeon) => {
  const {size} = dungeon;
  let rooms = [];
  let room, loot, generatedRoom;
  rooms.push(await this.generateExitRoom(dungeon));
  const exitX = rooms[0].position.x, exitY = rooms[0].position.y;

  for(let x = 0; x< size.x; x++) {
    for(let y = 0; y < size.y; y++) {
      if(x == exitX && y == exitY) continue;
      generatedRoom = await this.generateRoom(dungeon);
      room = await Room.create({
        user: dungeon.user,
        dungeon: dungeon._id,
        monsters: generatedRoom.monsters,
        reward: generatedRoom.reward,
        type: generatedRoom.type
      });
      rooms.push({room: room._id, loot: loot, position: {x: x, y: y}});
    }
  }
  return rooms;
}

exports.generateStartingResources = async () => {
  return [
    {type:'wood',amount:0},
    {type:'stone',amount:0},
    {type:'food',amount:0},
    {type:'coin',amount:0},
    {type:'metal',amount:0},
  ];
}

exports.generateStartingCastle = async (user) => {
  const castleSize = this.generateSizeForCastleFromGridLevel(1);
  const castle = await Castle.create({
    user: user._id,
    gridLeve: 1,
    heroes: [],
    size: castleSize,
    items: []
  });
  return castle;
}

exports.generateSizeForCastleFromGridLevel = (gridLevel) => {
  const x = Math.floor(gridLevel/2) + 3;
  const y = Math.floor((gridLevel-1)/2) + 3;
  return {x: x, y: y};
}