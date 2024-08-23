import express from "express";
import router from "./src/index.js";

const app = express();
const PORT = process.env.TIENDITA_API_PORT || 3000;

app.use(express.json());
app.use("/", router);

app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
