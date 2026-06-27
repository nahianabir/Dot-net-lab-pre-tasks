using System.ComponentModel.DataAnnotations;
namespace lab3.Models


{
    public class Student
    {
        //student id
        [Required(ErrorMessage = "Student ID is required")]
        [StringLength(10, ErrorMessage = "ID cannot exceed 10 characters")]
        public string StudentId { get; set; }


        //name
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; }


        //email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        //age
        [Required(ErrorMessage = "Age is required")]
        [Range(16, 40, ErrorMessage = "Age must be between 16 and 40")]
        public int Age { get; set; }

        //gpa
        [Required(ErrorMessage = "GPA is required")]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public double GPA { get; set; }


    }
}
