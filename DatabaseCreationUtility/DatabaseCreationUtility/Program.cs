using Domain.Data;
using Microsoft.EntityFrameworkCore;
public partial class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var context = new DemoContext();
            Console.WriteLine(args[0]);
            string serverName = args[0] ?? "";
            string databaseName = args[1] ?? "UtilityDatabase";
            string userName = args[2] ?? "username";
            string password = args[3] ?? "password";

            string connectionString = @"Data Source={Server};Initial Catalog={DatabaseName};Persist Security Info=True;User ID={userName};Password={password};Trust Server Certificate=True;Command Timeout=300".
                Replace("{DatabaseName}", databaseName).
                Replace("{Server}", serverName).
                Replace("{userName}", userName).
                Replace("{password}", password);

            Console.WriteLine(connectionString);
            context.Database.SetConnectionString(connectionString);
            context.Database.EnsureCreatedAsync().Wait();
            Console.WriteLine("Database Successfully Created");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
