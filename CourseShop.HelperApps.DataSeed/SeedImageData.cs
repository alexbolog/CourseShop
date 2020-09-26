using CourseShop.Core.DAL;
using CourseShop.Core.Entities.Enums;
using CourseShop.Core.Entities.FSM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseShop.HelperApps.DataSeed
{
    public class SeedImageData : SeedBase
    {
        public override string SeedMessage => "Seeding Image data";
        public override void Seed(CourseContext context)
        {
            if (context.CourseImages.Any(ci => ci.CourseId == -1))
                return;

            var defaultImagePath = "Resources/missing_image.jpg";
            var imageBytes = System.IO.File.ReadAllBytes(defaultImagePath);
            var base64 = Convert.ToBase64String(imageBytes);

            context.CourseImages.Add(new Core.Entities.CourseImage
            {
                CourseId = -1,
                Base64Image = base64,
                ImageIndex = 0
            });

            context.Database.OpenConnection();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.CourseImages ON");
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.CourseImages OFF");
            context.Database.CloseConnection();
        }
    }
}
