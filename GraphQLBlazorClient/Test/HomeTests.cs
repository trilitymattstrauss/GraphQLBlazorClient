using System.Text.RegularExpressions;
using Xunit;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace GraphQLBlazorClient.Test;

public class HomeTests : PageTest
{
    [Fact]
    public async Task ShouldGetBooks()
    {
        await Page.GotoAsync("http://localhost:5152");

        await Expect(Page).ToHaveTitleAsync(new Regex("Home"));
    }
    
}