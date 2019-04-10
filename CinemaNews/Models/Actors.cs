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
    }
    //customize Properties 
    public class ActorMetadata
    {
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [DataType(DataType.Url)]
        [DisplayName("IMDb Profile")]
        public string IMDb { get; set; }

        [DataType(DataType.Url)]
        [DisplayName("Instagram Profile")]
        public string Profile { get; set; }
    }
}