import * as Yup from "yup";

// Define the schema for user validation
export const userSchema = Yup.object().shape({
  nombreusuario: Yup.string()
    .required("Username is required")
    .max(50, "Username must be at most 50 characters"),
  contrasena: Yup.string().required("Password is required"),
  nombrecompleto: Yup.string()
    .required("Full name is required")
    .max(100, "Full name must be at most 100 characters"),
  email: Yup.string()
    .email("Invalid email format")
    .required("Email is required")
    .max(100, "Email must be at most 100 characters"),
});

/**
 * Middleware to validate the request body against the user schema.
 * @param {Object} req - The request object.
 * @param {Object} res - The response object.
 * @param {Function} next - The next middleware function.
 */
export async function validateUser(req, res, next) {
  try {
    await userSchema.validate(req.body);
    next();
  } catch (error) {
    res.status(400).json({ error: error.errors });
  }
}
