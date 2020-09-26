using CourseShop.Core.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseShop.HelperApps.DataSeed
{
    class Program
    {
        private const string ConnectionString = "Data Source=DESKTOP-C4ARLNG;Initial Catalog=CourseShop;Integrated Security=True";
        private static SeedBase[] Seeders = new SeedBase[]
        {
            new SeedDefaultFSMData(),
            new SeedImageData()
        };

        static void Main(string[] args)
        {
            var ctx = new CourseContext(GetOptions());
            foreach (var seeder in Seeders)
            {
                Console.WriteLine(seeder.SeedMessage);
                seeder.Seed(ctx);
            }
            Console.WriteLine("Done seeding data");
            Console.ReadKey();
        }

        private static DbContextOptions<CourseContext> GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<CourseContext>(), ConnectionString).Options;
        }
    }

    public abstract class SeedBase
    {
        public abstract string SeedMessage { get; }
        public abstract void Seed(CourseContext context);
    }
}
