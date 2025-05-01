using System.ComponentModel.DataAnnotations;

namespace GraphQLBlazorClient.Model;

public class BookInput
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? AuthorId { get; set; }
    [Required]
    public string? LibraryId { get; set; }
}