const express = require('express');
const rateLimit = require('express-rate-limit');
const helmet = require('helmet');
const mongoSanitize = require('express-mongo-sanitize');
const xss = require('xss-clean');
const hpp = require('hpp');
const cors = require('cors');

const AppError = require('./utils/appError');
const globalErrorHandler = require('./controllers/errorController');
const bannerRoute = require('./routes/bannerRoute');
const castleRoute = require('./routes/castleRoute');
const dungeonRoute = require('./routes/dungeonRoute');
const heroRoute = require('./routes/heroRoute');
const itemRoute = require('./routes/itemRoute');
const monsterRoute = require('./routes/monsterRoute');
const roomRoute = require('./routes/roomRoute');
const userHeroRoute = require('./routes/userHeroRoute');
const userRoute = require('./routes/userRoute');

const app = express();

const corsOptions = {
  origin: '*',
  optionsSuccessStatus: 200, // some legacy browsers (IE11, various SmartTVs) choke on 204
};

app.use(cors(corsOptions));

// Set security HTTP headers
app.use(helmet());

app.use('/api/v1/banner', bannerRoute);
app.use('/api/v1/castle', castleRoute);
app.use('/api/v1/dungeon', dungeonRoute);
app.use('/api/v1/hero', heroRoute);
app.use('/api/v1/item', itemRoute);
app.use('/api/v1/monster', monsterRoute);
app.use('/api/v1/room', roomRoute);
app.use('/api/v1/userhero', userHeroRoute);
app.use('/api/v1/user', userRoute);


// Limit request from same user
const limiter = rateLimit({
  max: 1000,
  windowMs: 60 * 60 * 1000,
  message: 'Too many requests from this IP, please try again in an hour!',
});
app.use('/api/', limiter);

app.use(express.json());

// Body parser, reading data from body into rq.body
//app.use(express.json({ limit: '10kb' }));

// Data sanitization against NoSQL query injection
app.use(mongoSanitize());

// Data sanitization against XSS attacks
app.use(xss());

// Prevent parameter pollution
app.use(hpp());

// Serving static files
app.use(express.static(`${__dirname}/public`));

app.use((req, res, next) => {
  console.log(req.url);
  console.log(req.query);
  next();
});

// 404 Error not found handler
app.all('*', (req, res, next) => {
  next(new AppError(`Can't find ${req.originalUrl} on this server!`, 404));
});

// Global Error Handling
app.use(globalErrorHandler);

module.exports = app;