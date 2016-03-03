using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toman296NTermProject.Models
{
    public class Group
    {
        public int ID { get; set; } // GroupID used to retrieve MeetupMembers.
        public string CategoryName { get; set; }
        public string CategorySortName { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Members { get; set; }
        public string Name { get; set; }
        public int RelevancyScore { get; set; } // For debugging purposes. 
        public string State { get; set; }
    }
}