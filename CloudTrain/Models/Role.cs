﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class Role : IdentityRole
    {
        public Role() { }

        public string Description { get; set; }
    }
}