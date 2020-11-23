const { promisify } = require('util');
const qs = require('qs');
const jwt = require('jsonwebtoken');
const axios = require('axios');
const catchAsync = require('../utils/catchAsync');
const AppError = require('../utils/appError');

exports.loginUser = catchAsync(async (req, res, next) => {

  const token = await jwt.sign(
    { userInfo: userInfo.data },
    process.env.JWT_SECRET,
    {
      expiresIn: process.env.JWT_EXPIRES_IN
    }
  );

  const cookieOptions = {
    expires: new Date(
      Date.now() + process.env.JWT_EXPIRES_IN_DAYS * 24 * 60 * 60
    ),
    httpOnly: false
  };

  if (process.env.NODE_ENV === 'production') cookieOptions.secure = true;
  res.cookie('jwt', token, cookieOptions);

  res.status(200).json({
    status: 'success',
    token: token,
    data: { userInfo: userInfo.data },
  });
});

exports.protect = catchAsync(async (req, res, next) => {
  let token;
  if (
    req.headers.authorization &&
    req.headers.authorization.startsWith('Bearer')
  ) {
    token = req.headers.authorization.split(' ')[1];
  }

  if (!token || token == 'undefined') return next(new AppError('Not logged in!', 401));

  const decodedPayload = await promisify(jwt.verify)(
    token,
    process.env.JWT_SECRET
  );

  if (!decodedPayload)
    return next(new AppError('Invalid JWT Token', 401));

  const guildOwner = await GuildOwner.findOne({ discordID: decodedPayload.userInfo.id });

  if (!guildOwner)
    return next(new AppError("This user does not exist", 400));

  req.auth = decodedPayload;
  req.guildOwner = guildOwner;
  next();
});

exports.loginStripe = catchAsync(async (req, res, next) => {
  // TODO: Use state to confirm the user that initiated the signin actually signed in.
  const { code, state } = req.body;

  const stripeAuthResponse = await stripe.oauth.token({ grant_type: 'authorization_code', code });
  const updatedGuildOwner = await GuildOwner.findOneAndUpdate({ discordID: req.auth.userInfo.id }, {
    stripeAccountID: stripeAuthResponse.stripe_user_id,
  });

  res.status(200).json({ status: 'success', data: updatedGuildOwner });
});