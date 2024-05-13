﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Common.ViewModels
{
    public class UpdateProfileViewModel
    {

        public string LearnerProfileId { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Dob { get; set; }

        public string Gender { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string Stream { get; set; } = null!;

        public string? ProfilePicture { get; set; } = null!;

        //public string CreatedBy { get; set; } = null!;

        //public DateTime CreatedAt { get; set; }

       // public string? ModifiedBy { get; set; }

        //public DateTime? ModifiedAt { get; set; }
    }
}
