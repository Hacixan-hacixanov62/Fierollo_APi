namespace Fierolla_Api.DTOs.Blogs
{
    public class BlogCreateDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Image { get; set; }

    }
}
