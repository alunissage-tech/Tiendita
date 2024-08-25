import { createUser } from "./users.service.js";

/**
 * Handles the request to create a new user.
 * @param {Object} req - The request object.
 * @param {Object} res - The response object.
 */
export async function createUserController(req, res) {
  try {
    const userData = req.body;
    const newUser = await createUser(userData);
    res.status(201).json(newUser);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
}
