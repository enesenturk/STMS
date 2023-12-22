using System;
using System.Collections.Generic;

namespace NS.STMS.Entity.Context;

public partial class t_property
{
    public int id { get; set; }

    public string name { get; set; }

    public int t_property_type_id { get; set; }

    public DateTime created_at { get; set; }

    public int created_by { get; set; }

    public DateTime? updated_at { get; set; }

    public int? updated_by { get; set; }

    public bool is_deleted { get; set; }

    public virtual ICollection<t_user> t_users { get; set; } = new List<t_user>();
}
