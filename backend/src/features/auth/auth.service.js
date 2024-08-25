/**
 * Service for handling authentication-related operations such as token generation and validation.
 * @module services/auth
 */

import jwt from "jsonwebtoken";
import bcrypt from "bcrypt";
import prisma from "../../database/prismaClient.js";

/**
 * Generates a JWT token for the authenticated user.
 * @param {Object} user - The user object containing user information.
 * @returns {string} JWT token valid for 1 day.
 */
export async function generateToken(user) {
  return jwt.sign({ id: user.idusuario }, process.env.JWT_SECRET, {
    expiresIn: "1h",
  });
}

/**
 * Verifies the authenticity of a JWT token.
 * @param {string} token - The JWT token to verify.
 * @returns {Object} Decoded token if valid.
 * @throws {Error} If the token is invalid or expired.
 */
export async function verifyToken(token) {
  return jwt.verify(token, process.env.JWT_SECRET);
}

/**
 * Validates the user's credentials (username and password).
 * @param {string} username - The username provided by the user.
 * @param {string} password - The password provided by the user.
 * @returns {Object|null} The user object if credentials are valid, otherwise null.
 */
export async function validateUser(username, password) {
  const user = await prisma.usuarios.findUnique({
    where: { nombreusuario: username },
  });

  if (
    user &&
    typeof password === "string" &&
    typeof user.contrasena === "object"
  ) {
    const hashedPassword = Buffer.from(user.contrasena).toString("utf-8");
    const match = await bcrypt.compare(password, hashedPassword);
    if (match) {
      return user;
    }
  }
  return null;
}
