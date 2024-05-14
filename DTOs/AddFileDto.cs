
namespace FileStorage.DTOs
{

    public class AddDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required IFormFile File { get; set; }
        public required string Address { get; set; }
    }

}