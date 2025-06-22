using System.ComponentModel.DataAnnotations;

namespace BookLibraryExam.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"\\d{3}-\\d{10}", ErrorMessage = "ISBN must be in format 978-XXXXXXXXXX")]
        public string ISBN { get; set; }

        [Range(1800, 2025, ErrorMessage = "Enter a valid publication year")]
        public int PublicationYear { get; set; }
    }
}

