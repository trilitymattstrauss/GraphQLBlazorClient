using GraphQLBlazorClient.Model;
using GraphQLExample.GraphQL;
using StrawberryShake;
using BookInput = GraphQLExample.GraphQL.BookInput;

namespace GraphQLBlazorClient.Services;

public interface IGraphService
{
    public Task<List<Library>?> GetLibraries();
    public Task<List<Author>?> GetAuthors();
    public Task<List<Book>?> GetBooks(string? title, string? authorId, string? libraryId);
    public Task<Book?> GetBookById(string bookId);
    public Task<string> AddBook(string title, string authorId, string libraryId);
}

public class GraphService : IGraphService
{
    private readonly GraphQLExampleClient? _client;

    public GraphService()
    {
    }

    public GraphService(GraphQLExampleClient client)
    {
        _client = client;
    }

    public async Task<List<Library>?> GetLibraries()
    {
        var librariesResult = await _client?.GetLibraries.ExecuteAsync()!;
        librariesResult.EnsureNoErrors();

        if (librariesResult.Data == null)
        {
            return [];
        }

        var libraries = librariesResult.Data.Libraries;

        return libraries.Select(library => new Library(library.Name, library.Id)).ToList();
    }

    public async Task<List<Author>?> GetAuthors()
    {
        var authorsResult = await _client?.GetAuthors.ExecuteAsync()!;
        authorsResult.EnsureNoErrors();

        if (authorsResult.Data == null)
        {
            return [];
        }

        var authors = authorsResult.Data.Authors;

        return authors.Select(author => new Author(author.Name, author.Id)).ToList();
    }

    public async Task<List<Book>?> GetBooks(string? title, string? authorId, string? libraryId)
    {
        var input = new BooksQueryInput
        {
            Title = !string.IsNullOrEmpty(title) ? title : null,
            AuthorId = !string.IsNullOrEmpty(authorId) ? authorId : null,
            LibraryId = !string.IsNullOrEmpty(libraryId) ? libraryId : null
        };

        var result = await _client?.GetBooks.ExecuteAsync(input)!;

        result.EnsureNoErrors();

        if (result.Data == null)
        {
            return [];
        }

        var books = result.Data.Books;

        return books.Select(book => new Book(book.Title, book?.Author?.Name, book?.Library.Name)).ToList();
    }

    public async Task<Book?> GetBookById(string bookId)
    {
        var input = new BookQueryInput
        {
            Id = bookId
        };

        var result = await _client?.GetBook.ExecuteAsync(input)!;
        result.EnsureNoErrors();

        if (result.Data == null)
        {
            return null;
        }

        var book = result.Data.Book;
        
        return new Book(book?.Title, book?.Author?.Name, book?.Library?.Name);
    }

    public async Task<string> AddBook(string title, string authorId, string libraryId)
    {
        var id = Guid.NewGuid().ToString();
        var input = new BookInput
        {
            Id = id,
            AuthorId = authorId,
            LibraryId = libraryId,
            Title = title
        };

        await _client?.AddBook.ExecuteAsync(input)!;

        return id;
    }
}