﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace SocialMedia.Infrastructure.Core
{
    public partial class AspnetPaths
    {
        public AspnetPaths()
        {
            AspnetPersonalizationPerUser = new HashSet<AspnetPersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        public string Path { get; set; }
        public string LoweredPath { get; set; }

        public virtual AspnetApplications Application { get; set; }
        public virtual AspnetPersonalizationAllUsers AspnetPersonalizationAllUsers { get; set; }
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
    }
}