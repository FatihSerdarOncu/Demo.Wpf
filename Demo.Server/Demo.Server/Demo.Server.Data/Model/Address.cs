using Demo.Server.Svc.DataContracts;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data.Model
{
	[PrimaryKey("AddressId")]
	[TableName("Address")]
	public class Address
	{
		public int AddressId { get; set; }
		public string FullAddress { get; set; }
		public int Town { get; set; }

		public static List<AddressDto> GetEntityCollection(List<Address> addressList)
		{
			var result = from s in addressList select GetEntity(s);
			return result.ToList();
		}

		internal static AddressDto GetEntity(Address address)
		{
			if (address == null)
				throw new ArgumentNullException("address", "Mapping addressDto TO address");

			var addDto = new AddressDto();
			addDto.AddressId = address.AddressId;
			addDto.FullAddress = address.FullAddress;
			addDto.Town = address.Town;

			return addDto;
		}
	}
}
