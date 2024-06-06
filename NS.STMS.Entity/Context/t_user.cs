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

    public bool needs_change_password { get; set; }

    public string preferred_language { get; set; }

    public string preferred_date_format { get; set; }

    public string preferred_number_format { get; set; }

    public virtual t_county t_county { get; set; }

    public virtual t_property t_property_id_user_typeNavigation { get; set; }

    public virtual t_student t_student { get; set; }

    public virtual ICollection<t_user_login_history> t_user_login_histories { get; set; } = new List<t_user_login_history>();
}
