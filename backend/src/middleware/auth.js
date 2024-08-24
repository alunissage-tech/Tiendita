import jwt from "jsonwebtoken";

/**
 * Middleware to verify if the user is authenticated.
 * Checks the JWT token in the Authorization header.
 * @param {Object} req - The request object.
 * @param {Object} res - The response object.
 * @param {Function} next - The next middleware function.
 */
export async function authenticateToken(req, res, next) {
  const token = req.headers["authorization"];
  if (!token) return res.status(401).json({ error: "Unauthorized access" }); // Unauthorized

  try {
    const decoded = jwt.verify(token, process.env.ACCESS_TOKEN_SECRET);
    req.user = decoded;
    next();
  } catch (err) {
    return res.status(403).json({ error: "Invalid or expired token" }); // Forbidden
  }
}
