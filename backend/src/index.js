import express from "express";
import { authenticateToken } from "./middleware/auth.js";
import authRoutes from "./features/auth/auth.routes.js";
import cashRegiserRoutes from "./features/cash-register/cash-register.routes.js";
import invoicesRoutes from "./features/invoices/invoices.routes.js";
import productsRoutes from "./features/products/products.routes.js";
import usersRoutes from "./features/users/users.routes.js";
import salesRoutes from "./features/sales/sales.routes.js";

const router = express.Router();

router.use("/auth", authRoutes);
router.use(authenticateToken);

router.use("/cash-register", cashRegiserRoutes);
router.use("/invoices", invoicesRoutes);
router.use("/products", productsRoutes);
router.use("/users", usersRoutes);
router.use("/sales", salesRoutes);

export default router;
