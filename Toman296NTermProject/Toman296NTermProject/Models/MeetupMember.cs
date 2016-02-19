using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toman296NTermProject.Models
{
    public class MeetupMember
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Bio { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime Visited { get; set; }
        // Topics list later.
    }
}