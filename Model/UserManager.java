package Model;

public class UserManager {
    private User user;

    public UserManager() {
        this.user = new User();
    }

    public UserManager(User user) {
        this.user = user;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public boolean login(String username, String password) {
        return user.getUsername().equals(username) && user.getPassword().equals(password);
    }

    public boolean register(String username, String password, String email) {
        if (user.getUsername().equals(username)) {
            return false;
        }
        user.setUsername(username);
        user.setPassword(password);
        user.setEmail(email);
        return true;
    }

    public boolean changePassword(String oldPassword, String newPassword) {
        if (user.getPassword().equals(oldPassword)) {
            user.setPassword(newPassword);
            return true;
        }
        return false;
    }

    public boolean changeEmail(String email) {
        user.setEmail(email);
        return true;
    }

    public boolean changeRole(String role) {
        user.setRole(role);
        return true;
    }
}
