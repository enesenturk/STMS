using System;
using System.Collections.Generic;

namespace NS.STMS.Entity.Context;

public partial class t_property_type
{
    public int id { get; set; }

    public string name { get; set; }

    public DateTime created_at { get; set; }

    public int created_by { get; set; }

    public DateTime? updated_at { get; set; }

    public int? updated_by { get; set; }

    public bool is_deleted { get; set; }
}
