namespace IdleGame.Api;

[GraphQLDescription("A representation of the user and their current idle game count.")]
public class User {

    [GraphQLDescription("The username associated with the user.")]
    public string Name { get; set; }

    [GraphQLDescription("The current count for the user.")]
    public int Count { get; set; }

    [GraphQLDescription("The ID for the user.")]
    [ID]
    public string Id { get; }

    public User(string name, string id) {
        Id = id;
        Name = name;
    }
}
