using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels.Dto
{
	public class TokenApiDto
	{
		public string AccessToken { get; set; }	
		public string RefreshToken { get; set; }
		public Boolean result { get; set; } = false;

	}
    public class AuthUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
      
    }
}
