using Eventify.Domain.Entities.Base;
using Eventify.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "The Username field is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The FirstName field is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName field is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public required string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The BirthDate field is required.")]
        public required DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        public required Address UserAddress { get; set; }

        [Required(ErrorMessage = "The PhoneNumber field is required.")]
        [RegularExpression(@"^(\+\d{1,3}[-.\s]?)?(\d{1,4}[-.\s]?){1,14}\d{1,4}$", ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Gener field is required.")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The Role field is required.")]
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }

        public bool IsAdult()
        {
            // Calculate age based on the current date and the user's birthdate
            int age = CalculateAge(BirthDate, DateTime.Now);

            // Check if the user is 18 years or older
            return age >= 18;
        }

        private static int CalculateAge(DateTime birthdate, DateTime referenceDate)
        {
            int age = referenceDate.Year - birthdate.Year;

            // Adjust age if the user's birthday hasn't occurred yet this year
            if (birthdate.Date > referenceDate.Date.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum UserRole
    {
        Admin,
        User,
        Moderator
    }
}
