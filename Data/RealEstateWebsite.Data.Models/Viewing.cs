namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;
    using RealEstateWebsite.Data.Models.Enum;

    using static RealEstateWebsite.Data.Common.DataConstants.View;

    public class Viewing : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(FirstNameMaxLenght)]
        public string FirsName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(EmailAddressMaxLenght)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(PhoneMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public HalfDay HalfDay { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
