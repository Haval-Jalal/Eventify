using Eventify.Models;
using Eventify.Services;
namespace Eventify

{
    internal class Program
    {
        //Kopplat mot databasen genom att ladda ner "dotnet add package Microsoft.EntityFrameworkCore.SqlServer" och "dotnet add package Microsoft.EntityFrameworkCore.Tools"
        //Sedan köra "dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=Eventify;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f"
        //i terminalen för att skapa modeller från databasen




        static void Main(string[] args)
        {
            MenuService.Run();
        }
    }
}
