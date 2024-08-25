import express from "express";
import router from "./src/index.js";
import { generalRateLimiter } from "./src/middleware/rateLimiter.js";

/**
 * Initializes the Express application and sets up middleware and routes.
 * @module server
 */

const app = express();

app.use(express.json());
app.use(generalRateLimiter);
app.use("/", router);

/**
 * GET /
 * @desc Sends a welcome message for the root route.
 * @access Public
 */
app.get("/", (_req, res) => {
  res.send("Welcome to Tiendita API");
});

/**
 * Starts the server on the specified port in non-production environments.
 */
if (process.env.NODE_ENV !== "production") {
  const PORT = process.env.TIENDITA_API_PORT || 3000;
  app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
  });
}

export default app;
