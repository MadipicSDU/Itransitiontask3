var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/madizhassymbek_gmail_com", (string? x, string? y) =>
{
    if(!long .TryParse(x, out var a)
    || !long .TryParse(y, out var b) || a*b <1)
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