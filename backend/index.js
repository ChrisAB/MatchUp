// eslint-disable-next-line no-unused-vars
const dotenv = require('dotenv').config({ path: './config.env' });
const app = require('./app');
const mongoose = require('mongoose');
const uri = process.env.DB_CONNECTION_STRING.replace('<password>', process.env.DB_PASSWORD).replace('<dbname>', process.env.DB_NAME);

mongoose.connect(uri, {
  useNewUrlParser: true,
  useCreateIndex: true,
  useFindAndModify: false,
  useUnifiedTopology: true
}).then(() => console.log("Successfully connected to database")).catch(err => {
  console.log(err);
});

const port = process.env.PORT;

app.listen(port, () => {
  console.log(`App running on port ${port}...`);
});
