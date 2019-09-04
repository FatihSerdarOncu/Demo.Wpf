using Demo.Server.Svc.DataContracts;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data.Model
{
	[PrimaryKey("TownId")]
	[TableName("Town")]
	public class Town
	{
		public int TownId { get; set; }
		public string TownName { get; set; }
		public int City { get; set; }

		public static List<TownDto> GetEntityCollection(List<Town> townList)
		{
			var result = from s in townList select GetEntity(s);
			return result.ToList();
		}

		internal static TownDto GetEntity(Town town)
		{
			if (town == null)
				throw new ArgumentNullException("Town", "Mapping TownDto TO Town");

			var townDto = new TownDto();
			townDto.TownId = town.TownId;
			townDto.TownName = town.TownName;
			townDto.City = town.City;

			return townDto;
		}
	}
}
