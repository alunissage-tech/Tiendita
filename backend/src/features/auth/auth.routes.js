/**
 * Routes for authentication operations.
 * @module routes/auth
 */

import express from "express";
import { login } from "./auth.controller.js";

const router = express.Router();

/**
 * @route POST /auth/login
 * @desc Authenticates a user and returns a JWT token.
 * @access Public
 */
router.post("/login", login);

export default router;
