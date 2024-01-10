using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Data.Model
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Contact { get; set; }
        public bool IsMember { get; set; }
    }
}
