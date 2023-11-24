using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_city : IEntity
{

	public int t_country_id { get; set; }

	public string name { get; set; }

	public string plate_code { get; set; }

	public virtual ICollection<t_county> t_counties { get; set; } = new List<t_county>();

	public virtual t_country t_country { get; set; }
}
