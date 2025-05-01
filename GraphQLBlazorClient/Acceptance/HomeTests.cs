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
        await Page.GetByTestId("get-books-button").ClickAsync();

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
        await Page.GetByTestId("create-book-title").FillAsync(title);
        await Page.GetByTestId("create-book-author").SelectOptionAsync("JRR Tolkien");
        await Page.GetByTestId("create-book-library").SelectOptionAsync("Memorial Library");
        
        // Click the add button on the rendered page
        await Page.GetByTestId("create-book-button").ClickAsync();
        
        // Look for an expected book to appear on the page
        await Expect(Page.GetByText(title)).ToBeVisibleAsync();
    }
}