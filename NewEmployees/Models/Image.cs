using System.ComponentModel.DataAnnotations;

namespace NewEmployees.Models
{
    public class Image
    {
        public Image() { }
        public Image(IFormFile file)
        {
            //Copies a file into the memory
            MemoryStream stream= new MemoryStream();
            file.CopyTo(stream);
            MyImage = stream.ToArray();
        }
        [Key]
        public int ID { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "תמונה")]
        public byte[] MyImage { get; set; }
    }
}
