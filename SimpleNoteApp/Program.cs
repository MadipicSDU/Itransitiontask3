var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://*:{port}");
var app = builder.Build();


if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async(context, next) =>
{
    Console.WriteLine($"[{DateTime.UtcNow}] {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");
    await next();
});
app.MapGet("/madizhassymbek_gmail_com", (string? x, string? y) =>
{
    if(!long .TryParse(x, out var a ) || a < 1
    || !long .TryParse(y, out var b) || b < 1)
    {
        return Results.Text("NaN", "text/plain");
    }

    long gcd = Gcd(a,b);
    long lcm = checked(a / gcd * b);
    return Results.Text(lcm.ToString(),"text/plain");
});

app.Run();

long Gcd(long a, long b)
{
    while (b != 0)
    {
        (a, b) = (b, a % b);
    }
    return a;
}