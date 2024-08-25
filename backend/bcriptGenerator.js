import bcrypt from "bcrypt";

const password = "tu_contraseña";
const saltRounds = 10;
const hashedPassword = await bcrypt.hash(password, saltRounds);
console.log(
  "password: " + password + "\n" + "hashedPassword: " + hashedPassword
);
