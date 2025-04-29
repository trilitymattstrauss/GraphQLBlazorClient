using Xunit;
using Microsoft.Playwright.Xunit;

namespace GraphQLBlazorClient.Test;

public class HomeTests : PageTest
{
    [Fact]
    public async Task ShouldGetBooks()
    {
        await Page.GotoAsync("http://localhost:5152");
        await Page.GetByTestId("get-books-button").ClickAsync();

        await Expect(Page.GetByText("The Lord of the Rings")).ToBeVisibleAsync();
    }

    [Fact]
    public async Task ShouldCreateBook()
    {
        var rand = new Random();
        var title = "Cool Book " + rand.Next();

        await Page.GotoAsync("http://localhost:5152");
        await Page.GetByTestId("create-book-title").FillAsync(title);
        await Page.GetByTestId("create-book-author").SelectOptionAsync("JRR Tolkien");
        await Page.GetByTestId("create-book-library").SelectOptionAsync("Memorial Library");
        
        await Page.GetByTestId("create-book-button").ClickAsync();

        await Expect(Page.GetByText(title)).ToBeVisibleAsync();
    }
}