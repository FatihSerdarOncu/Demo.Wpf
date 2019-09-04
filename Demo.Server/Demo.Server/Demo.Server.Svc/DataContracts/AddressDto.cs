using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Svc.DataContracts
{
	public class AddressDto
	{
		public int AddressId { get; set; }
		public string FullAddress { get; set; }
		public int Town { get; set; }
	}
}
