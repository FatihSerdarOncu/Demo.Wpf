using Demo.Server.Svc.DataContracts;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data.Model
{
	[PrimaryKey("CityId")]
	[TableName("City")]
	public class City
	{
		public int CityId { get; set; }
		public string CityName { get; set; }

		public static List<CityDto> GetEntityCollection(List<City> cityList)
		{
			var result = from s in cityList select GetEntity(s);
			return result.ToList();
		}

		internal static CityDto GetEntity(City city)
		{
			if (city == null)
				throw new ArgumentNullException("city", "Mapping cityDto TO city");

			var cityDto = new CityDto();
			cityDto.CityId = city.CityId;
			cityDto.CityName = city.CityName;
			
			return cityDto;
		}
	}
}
