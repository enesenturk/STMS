using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_user_login_history : IEntity
{

	public int t_user_id { get; set; }

	public bool is_successful { get; set; }

	public virtual t_user t_user { get; set; }
}
