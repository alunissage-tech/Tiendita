import prisma from "../../database/prismaClient";

/**
 * Creates a new user in the database.
 * @param {Object} userData - The data for the new user.
 * @param {string} userData.nombreusuario - The username.
 * @param {Buffer} userData.contrasena - The hashed password.
 * @param {string} userData.nombrecompleto - The full name of the user.
 * @param {string} userData.email - The email of the user.
 * @returns {Promise<Object>} The created user.
 */
export async function createUser(userData) {
  const user = await prisma.usuarios.create({
    data: userData,
  });
  return user;
}
