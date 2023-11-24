using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_county : IEntity
{
	public int id { get; set; }

	public int t_city_id { get; set; }

	public string name { get; set; }

	public virtual t_city t_city { get; set; }
}
