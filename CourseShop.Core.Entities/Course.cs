namespace CourseShop.Core.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailPath { get; set; }
        public string WatchUrl { get; set; } // link youtube/vimeo
        public bool IsSelectedForCarousel { get; set; }
        public double LengthHours { get; set; }
        public string Contributors { get; set; }
        
    }
}
