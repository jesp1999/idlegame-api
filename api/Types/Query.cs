namespace IdleGame.Api;

public class Query {
    public User GetUser() {
        return new User("Temp User", "1");
    }
}
