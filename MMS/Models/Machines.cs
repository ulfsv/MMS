using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Models
{
    public class Machines
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public bool Status { get; set; }
    }
}
