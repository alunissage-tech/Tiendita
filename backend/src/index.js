/**
 * Main router for the application. Handles routing for all endpoints.
 * @module routes/index
 */

import express from "express";
import cashRegiserRoutes from "./features/cash-register/cash-register.routes.js";
import invoicesRoutes from "./features/invoices/invoices.routes.js";
import productsRoutes from "./features/products/products.routes.js";
import usersRoutes from "./features/users/users.routes.js";
import salesRoutes from "./features/sales/sales.routes.js";
import authRoutes from "./features/auth/auth.routes.js";
import { authenticateToken } from "./middleware/auth.js";

const router = express.Router();

/**
 * @route POST /auth/login
 * @desc Logs in a user and returns a JWT token.
 * @access Public
 */
router.use("/auth", authRoutes);

/**
 * Middleware to authenticate all protected routes.
 * Verifies JWT tokens before allowing access.
 */
router.use(authenticateToken);

router.use("/cash-register", cashRegiserRoutes);
router.use("/invoices", invoicesRoutes);
router.use("/products", productsRoutes);
router.use("/users", usersRoutes);
router.use("/sales", salesRoutes);

export default router;
