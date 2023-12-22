﻿using System;
using System.Collections.Generic;

namespace NS.STMS.Entity.Context;

public partial class t_student
{
    public int id { get; set; }

    public int t_user_id { get; set; }

    public int t_grade_id { get; set; }

    public string school_name { get; set; }

    public DateTime created_at { get; set; }

    public int created_by { get; set; }

    public DateTime? updated_at { get; set; }

    public int? updated_by { get; set; }

    public bool is_deleted { get; set; }

    public virtual t_grade t_grade { get; set; }

    public virtual t_user t_user { get; set; }
}
