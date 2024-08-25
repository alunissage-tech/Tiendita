import express from "express";
import { createUserController } from "./users.controller.js";
import { validateUser } from "./users.validation.js";

const router = express.Router();

/**
 * POST /users
 * Creates a new user.
 */
router.post("/", validateUser, createUserController);

export default router;
