using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_user : IEntity
{

    public string name { get; set; }

    public string surname { get; set; }

    public string email { get; set; }

    public DateOnly date_of_birth { get; set; }

    public int t_county_id { get; set; }

    public string image_base64 { get; set; }

    public string password { get; set; }

    public byte[] password_salt { get; set; }

    public int t_property_id_user_type { get; set; }

    public bool accepted_terms { get; set; }

    public DateTime? accepted_terms_at { get; set; }

    public bool verified_email { get; set; }

    public DateTime? verified_email_at { get; set; }

    public virtual t_county t_county { get; set; }

    public virtual t_property t_property_id_user_typeNavigation { get; set; }

    public virtual ICollection<t_student> t_students { get; set; } = new List<t_student>();
}
