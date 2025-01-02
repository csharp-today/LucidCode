# LucidCode

## **WriteToConsoleAsync** extension method

**Description:** Await for a string and write it to Console using Console.WriteLine() method.

Examples:

```csharp
using LucidCode;
using System.Threading.Tasks;
using Xunit;

namespace Examples.Extensions;

public class WriteToConsoleAsync
{
    [Fact]
    public async Task Example_Of_WriteToConsoleAsync_Extension()
    {
        await GetTextFromRemoteAsync().WriteToConsoleAsync();
    }
    
    private async Task<string> GetTextFromRemoteAsync()
    {
        await Task.Delay(10);
        return "Some text";
    }
}

```
