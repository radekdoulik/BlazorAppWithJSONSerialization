global using BlazorAppWithJSONSerialization;
using Plants;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// try constant interpolated string
const string message = $"{nameof(BlazorAppWithJSONSerialization)} started";
Console.WriteLine(message);

// try record with sealed ToString()
var tree = new Plant("Myrtaceae", "Eucalyptus", "Amygdalina");
Console.WriteLine(tree);

// try assignment and declaration in same deconstruction
(double x, double y, double z) point;
point = (1.0, 0, 0);

double x1;
(x1, double y1, var z1) = point;
Console.WriteLine($"3D point: {x1}, {y1}, {z1} == {point}");

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
