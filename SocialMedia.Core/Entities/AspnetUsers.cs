﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace SocialMedia.Infrastructure.Core
{
    public partial class AspnetUsers : BaseEntity
    {
        public AspnetUsers()
        {
            AspnetPersonalizationPerUser = new HashSet<AspnetPersonalizationPerUser>();
            AspnetUsersInRoles = new HashSet<AspnetUsersInRoles>();
        }

        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }

        public virtual AspnetApplications Application { get; set; }
        public virtual AspnetMembership AspnetMembership { get; set; }
        public virtual AspnetProfile AspnetProfile { get; set; }
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
        public virtual ICollection<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
    }
}