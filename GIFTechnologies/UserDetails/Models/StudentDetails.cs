using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDetails.Models
{
    public class StudentDetails
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int ParentId { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string ParentEmail { get; set; }
        public string ParentMobile { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public bool Active { get; set; }

        public List<SchoolClass> SchoolClass { get; set; }

    }
}