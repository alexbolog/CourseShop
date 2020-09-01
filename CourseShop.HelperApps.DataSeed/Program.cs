using CourseShop.Core.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CourseShop.HelperApps.DataSeed
{
    class Program
    {
        private const string ConnectionString = "Data Source=DESKTOP-C4ARLNG;Initial Catalog=CourseShop;Integrated Security=True";
        static void Main(string[] args)
        {
            SeedCourseImages().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine("Done seeding data");
            Console.ReadKey();
        }

        private static async Task SeedCourseImages()
        {
            var ctx = new CourseContext(GetOptions());

            if (await ctx.CourseImages.AnyAsync(ci => ci.CourseId == -1))
                return;

            var defaultImagePath = "Resources/missing_image.jpg";
            var imageBytes = System.IO.File.ReadAllBytes(defaultImagePath);
            var base64 = Convert.ToBase64String(imageBytes);

            ctx.CourseImages.Add(new Core.Entities.CourseImage
            {
                CourseId = -1,
                Base64Image = base64,
                ImageIndex = 0
            });
            await ctx.SaveChangesAsync();
        }

        private static DbContextOptions<CourseContext> GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<CourseContext>(), ConnectionString).Options;
        }
    }
}
