using System.ComponentModel.DataAnnotations;
//using System.Security.Cryptography;

namespace NewEmployees.Models
{
    public class Employee
    {
        public Employee() { Images  = new List<Image>(); }
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "מספר זהות")]
        public string IDNumber { get; set; } = "";

        [Required, Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = "";

        [Required, Display(Name = "שם משפחה")]
        public string LastName { get; set; } = "";
        [Display(Name = "שם מלא")]
        public string FullName { get { return FirstName + " " + LastName; } }
        [Display(Name = "רחוב")]
        public string Street { get; set; } = "";
        [Display(Name = "עיר")]
        public char Number { get; set; }
        public string Address { get { return City + " " + Street + " " + Number; } } 
        [Display(Name = "כתובת מייל"),EmailAddress(ErrorMessage = "נא לכתוב כתובת מייל נכונה")]
        public string Email { get; set; } = "";
        [Display(Name = "עיר")]
        public string City { get; set; } = "";
        [DataType(DataType.Date), Display(Name = "תאריך לידה")]
        public DateTime Date { get; set; } = DateTime.Now.AddDays(-18);
        [Display(Name = "גיל")]
        public int Age { get { return DateTime.Now.Year - Date.Year; } }

        public List<Image> Images { get; set;} = new List<Image>();

        public IFormFile SetImage
        {
            set
            {
                if (value == null) return;
                Images.Add(new Image(value));
            }
        }

    }
}
