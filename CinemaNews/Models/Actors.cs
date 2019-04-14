using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CinemaNews.Models
{
    [MetadataType(typeof(ActorMetadata))]
    public partial class Actor
    {
        public int Age
        {
            get
            {
                return DateTime.Today.Year - Convert.ToDateTime(DateOfBirth).Year;
            }
        }
    }
    //customize Properties 
    public class ActorMetadata
    {
        [Required(ErrorMessage = "Please, Enter First Name.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, Enter Last Name.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, Choose Gender.")]
        public string Gender { get; set; }

        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please, Enter Date Of Birth.")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [DataType(DataType.Url)]
        [DisplayName("IMDb Profile")]
        public string IMDb { get; set; }

        [DataType(DataType.Url)]
        [DisplayName("Instagram Profile")]
        public string Profile { get; set; }

    }
}