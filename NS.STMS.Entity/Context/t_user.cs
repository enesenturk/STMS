using System;
using System.Collections.Generic;

namespace NS.STMS.Entity.Context;

public partial class t_user
{
    public int id { get; set; }

    public string name { get; set; }

    public string surname { get; set; }

    public string email { get; set; }

    public DateOnly date_of_birth { get; set; }

    public int t_county_id { get; set; }

    public string image_base64 { get; set; }

    public DateTime created_at { get; set; }

    public int created_by { get; set; }

    public DateTime? updated_at { get; set; }

    public int? updated_by { get; set; }

    public bool is_deleted { get; set; }

    public virtual t_county t_county { get; set; }
}
