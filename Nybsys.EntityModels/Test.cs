using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
    public class Test
    {
        public int PublicId { get; set; }
        protected int ProtectedId { get; set; }
        private int privateId { get; set; }
        internal int internalId { get; set; }

    }
}
