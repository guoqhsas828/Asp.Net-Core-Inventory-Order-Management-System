using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class UserProfile : BaseEntityModel
    {
      public UserProfile()
      {
        UserStatus = UserStatus.Trial;
        Created = DateTime.UtcNow;
        LastUpdated = DateTime.UtcNow;
        Continent = Continents.America;
    }

      public int UserProfileId { get => Id;
          set => Id =value;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OldPassword { get; set; }
        public string ProfilePicture { get; set; } = "/upload/blank-person.png";

        public string ApplicationUserId { get; set; }

    #region Newly Added Fields

      public Continents Continent { get; set; }

      public int ExperienceLevel { get; set; }

      public UserStatus UserStatus { get; set; }

      public DateTime Created { get; set; }

      public DateTime LastUpdated { get; set; }

      [NotMapped]
      public int ObjectId { get => Id; set => Id = value;}

      public DateTime LatestLogin { get; set; }

      //TOBEDONE: convert the training process to be team-wise treasury hunting game
      public double AchievedPoints { get; set; }

      public int AchievedLevel { get; set; }

      //[NotMapped] public GeographyPoint Location { get; set; }

      //public bool SupportsBlogFeature()
      //{

      //  return !string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.EndsWith("4456") && PhoneNumber.Contains("82");

      //}

    #endregion
  }
}
