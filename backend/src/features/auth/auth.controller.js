/**
 * Controller for handling authentication logic.
 * @module controllers/auth
 */

import { generateToken, validateUser } from "./auth.service.js";

/**
 * Handles the login request, validating the user's credentials and returning a JWT token.
 * @param {Object} req - The request object.
 * @param {Object} res - The response object.
 * @returns {Object} JSON object with a JWT token if credentials are valid.
 */
export async function login(req, res) {
  const { username, password } = req.body;
  const user = await validateUser(username, password);
  if (!user) {
    return res.status(401).json({ error: "Invalid credentials" });
  }

  const token = await generateToken(user);
  res.json({ token });
}
