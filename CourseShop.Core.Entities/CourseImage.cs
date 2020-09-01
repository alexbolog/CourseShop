using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class CourseImage
    {
        public int CourseId { get; set; }
        public string Base64Image { get; set; }
        public int ImageIndex { get; set; }
    }
}
