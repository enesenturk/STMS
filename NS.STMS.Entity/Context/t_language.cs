using System;
using System.Collections.Generic;

namespace NS.STMS.Entity.Context;

public partial class t_language
{
    public int id { get; set; }

    public DateTime created_at { get; set; }

    public int created_by { get; set; }

    public DateTime? updated_at { get; set; }

    public int? updated_by { get; set; }

    public bool is_deleted { get; set; }

    public string language_key { get; set; }

    public string tr_TR { get; set; }

    public string en_US { get; set; }
}
