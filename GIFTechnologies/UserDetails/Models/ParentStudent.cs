using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDetails.Models
{
    public class ParentStudent
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int StudentId { get; set; }
    }
}