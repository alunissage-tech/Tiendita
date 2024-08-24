import rateLimit from "express-rate-limit";

/**
 * Middleware to limit the number of requests per IP.
 * Helps to prevent abuse or brute force attacks.
 */
export const generalRateLimiter = rateLimit({
  windowMs: 15 * 60 * 1000, // 15 minutes
  max: 100, // limit each IP to 100 requests per windowMs
  message: "Too many requests from this IP, please try again later",
});
