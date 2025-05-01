using Xunit;
using Microsoft.Playwright.Xunit;

namespace GraphQLBlazorClient.Acceptance;

public class HomeTests : PageTest
{
    [Fact]
    public async Task ShouldGetBooks()
    {
        // Navigate to the running website
        await Page.GotoAsync("http://localhost:5152");
        
        // Click the book query button on the rendered page
        await Page.GetByText("Get Books").ClickAsync();

        // Look for an expected book to appear on the page
        await Expect(Page.GetByText("The Lord of the Rings")).ToBeVisibleAsync();
    }

    [Fact]
    public async Task ShouldCreateBook()
    {
        var rand = new Random();
        var title = "Cool Book " + rand.Next();

        // Navigate to the running website
        await Page.GotoAsync("http://localhost:5152");
        
        // Fill in the form for adding the book
        await Page.Locator("input[name=\"AddBookInput.Title\"]").FillAsync(title);
        await Page.Locator("select[name=\"AddBookInput.AuthorId\"]").SelectOptionAsync("JRR Tolkien");
        await Page.Locator("select[name=\"AddBookInput.LibraryId\"]").SelectOptionAsync("Memorial Library");

        // Click the add button on the rendered page
        await Page.GetByText("Add Book").ClickAsync();
        
        // Look for an expected book to appear on the page
        await Expect(Page.GetByText(title)).ToBeVisibleAsync();
    }
}