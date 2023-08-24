using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels.Dto
{
    public class CustomerWithCount
    {
        public List<Customer> Customerlist { get; set; }
        public int Count { get; set; }
    }
}
