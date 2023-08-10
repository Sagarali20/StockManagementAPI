using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels
{
    public class StocFilter
	{
		public int PageNo { get; set; }
		public int PageSize { get; set; }
		public string SearchText { get; set; }
		public DateTime? FirstDate { get; set; }
		public DateTime? Lastdate { get; set; }
	}
}
