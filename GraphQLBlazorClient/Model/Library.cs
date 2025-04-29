namespace GraphQLBlazorClient.Model;

public class Library(string name, string id)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
}