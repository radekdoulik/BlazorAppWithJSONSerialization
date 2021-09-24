global using BlazorAppWithJSONSerialization;
using Plants;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
const string message = $"{nameof(BlazorAppWithJSONSerialization)} started";

Console.WriteLine(message);

var tree = new Plant("Myrtaceae", "Eucalyptus", "Amygdalina");
Console.WriteLine(tree);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

namespace Plants
{
    public record Plant(string Family, string Genus, string Specie)
    {
        public override sealed string ToString()
        {
            return $"F:{Family} G:{Genus} S:{Specie}";
        }
    }
}
