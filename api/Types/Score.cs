namespace IdleGame.Api;

[GraphQLDescription("A representation of the user and their score")]
public class Score
{
    [GraphQLDescription("The user associated with the score.")]
    public string Username { get; set; }

    [GraphQLDescription("The current count for the user.")]
    public int Count { get; set; }

    [GraphQLDescription("The ID for the score.")]
    [ID]
    public string Id { get; }

    public Score(User username, string id) {
        Id = id;
        User = username;
        Multiplier = multiplier;
        Count = 0;
    }   
}