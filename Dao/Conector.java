package Dao;

public class Conector {
    private String url;
    private String user;
    private String password;

    public Conector() {
        this.url = "jdbc:mysql://localhost:3306/DB";
        this.user = "root";
        this.password = "root";
    }
}
