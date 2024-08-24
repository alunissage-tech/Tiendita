import express from "express";
import { createUserController } from "./users.controller";
import { validateUser } from "./users.validation";

const router = express.Router();

/**
 * POST /users
 * Creates a new user.
 */
router.post("/", validateUser, createUserController);

export default router;
