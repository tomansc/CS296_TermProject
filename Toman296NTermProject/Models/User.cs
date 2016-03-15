using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toman296NTermProject.Models
{
    public class User : ApplicationUser
    {
        //public int UserId { get; set; }
        public string organization { get; set; }

    }
}