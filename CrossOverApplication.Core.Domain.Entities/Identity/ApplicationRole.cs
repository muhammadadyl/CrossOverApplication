﻿using System.Collections.Generic;

namespace CrossOverApplication.Core.Domain.Entities.Identity
{
    public class ApplicationRole
    {
        public ApplicationRole()
        {
            Users = new List<ApplicationUserRole>();
        }

        public string Id
        {
            get; set;
        }

        public virtual ICollection<ApplicationUserRole> Users{ get; private set; }

        public string Name { get; set; }
    }
}
