using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace login.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        [Reqierd]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mob { get; set; }
        public string Department { get; set; }
        public string Companey { get; set; }
    }
}