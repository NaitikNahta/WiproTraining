var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Something went wrong. Please try again later.");
    }
});


app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;

    Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");

    await next(); // Pass control to next middleware

    var endTime = DateTime.UtcNow;
    var duration = endTime - startTime;

    Console.WriteLine($"Outgoing Response: {context.Response.StatusCode} | Time Taken: {duration.TotalMilliseconds} ms");
});

app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] =
    "default-src 'self'; script-src 'self'; style-src 'self';";

    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapGet("/", () => "Middleware is working!");
app.MapGet("/error", () =>
{
    throw new Exception("Test exception triggered!");
});
app.Run();
