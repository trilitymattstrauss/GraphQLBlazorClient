namespace GraphQLBlazorClient.Model;

public class Book(string? title, string? authorName, string? libraryName)
{
    public string? Title { get; set; } = title;
    public string? AuthorName { get; set; } = authorName;
    public string? LibraryName { get; set; } = libraryName;
}