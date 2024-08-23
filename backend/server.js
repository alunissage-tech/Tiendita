import express from "express";
import router from "./src/index.js";

const app = express();

app.use(express.json());
app.use("/", router);

app.get("/", (_req, res) => {
  res.send("Welcome to Tiendita API");
});

if (process.env.NODE_ENV !== "production") {
  const PORT = process.env.TIENDITA_API_PORT || 3000;
  app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
  });
}

export default app;
