namespace RealEstateWebsite.Web.ViewModels.Viewings
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Models.Enum;

    using static RealEstateWebsite.Data.Common.DataConstants.View;

    public class PlanViewingFormModel
    {
        [Required]
        [Display(Name = "Write your message to the agent")]
        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        public DayOfWeek Day { get; set; }

        [Display(Name = "Half-Day")]
        public HalfDay HalfDay { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(FirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(LastNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(EmailAddressMaxLenght)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(PhoneMaxLenght)]
        public string Phone { get; set; }

        public IEnumerable<DayOfWeek> Days { get; set; }

        public IEnumerable<HalfDay> HalfDays { get; set; }
    }
}
