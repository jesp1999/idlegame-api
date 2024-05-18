namespace IdleGame.Api;

[GraphQLDescription("A representation of the user and their current idle game count.")]
public class User {

    [GraphQLDescription("The username associated with the user.")]
    public string Username { get; set; }
    
    [GraphQLDescription("The email associated with the user.")]
    public string Email { get; set; }

    [GraphQLDescription("The password associated with the user.")]
    public string Password { set; }
    
    [GraphQLDescription("The ID for the user.")]
    [ID]
    public string Id { get; }

    public User(string name, string password, string id) {
        Id = id;
        Password = password;
        Name = name;
    }
}
