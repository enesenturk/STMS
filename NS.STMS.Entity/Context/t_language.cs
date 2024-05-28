using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_language : IEntity
{
	public string language_key { get; set; }

	public string tr_TR { get; set; }

	public string en_US { get; set; }
}
