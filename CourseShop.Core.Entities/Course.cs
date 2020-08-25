namespace CourseShop.Core.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        //public string ThumbnailPath { get; set; }
        public string WatchUrl { get; set; } // link youtube/vimeo
        //public bool IsSelectedForCarousel { get; set; }
        //public double LengthHours { get; set; }
        //public string Contributors { get; set; }
        public bool IsAvailable { get; set; }
        
    }
}
