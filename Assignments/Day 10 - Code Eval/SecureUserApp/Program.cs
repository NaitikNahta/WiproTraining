using SecureUserApp.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Console.WriteLine("=== Secure User System ===");

    // Register
    AuthService.Register("naitik", "password123");
    Log.Information("User Registered Successfully");

    Console.WriteLine("User Registered Successfully");

    // Login
    bool loginSuccess = AuthService.Authenticate("naitik", "password123");

    if (loginSuccess)
    {
        Log.Information("Login Successful");
        Console.WriteLine("Login Successful");
    }
    else
    {
        Log.Warning("Login Failed");
        Console.WriteLine("Login Failed");
    }

    // Encryption Test
    Console.WriteLine("\n=== Encryption Test ===");

    string sensitiveData = "MySecretInformation";

    string encrypted = EncryptionService.Encrypt(sensitiveData);
    Log.Information("Data Encrypted Successfully");

    Console.WriteLine($"Encrypted: {encrypted}");

    string decrypted = EncryptionService.Decrypt(encrypted);
    Log.Information("Data Decrypted Successfully");

    Console.WriteLine($"Decrypted: {decrypted}");
}
catch (Exception ex)
{
    Log.Error(ex, "An error occurred in the application");
    Console.WriteLine("Something went wrong. Check logs.");
}
finally
{
    Log.CloseAndFlush();
}