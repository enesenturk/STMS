using Microsoft.EntityFrameworkCore;
using NS.STMS.Settings;

namespace NS.STMS.Entity.Context;

public partial class ns_stmsContext : DbContext
{
	public ns_stmsContext()
	{
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	public ns_stmsContext(DbContextOptions<ns_stmsContext> options)
		: base(options)
	{
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	public virtual DbSet<t_city> t_cities { get; set; }

	public virtual DbSet<t_country> t_countries { get; set; }

	public virtual DbSet<t_county> t_counties { get; set; }

	public virtual DbSet<t_difficulty_level> t_difficulty_levels { get; set; }

	public virtual DbSet<t_grade> t_grades { get; set; }

	public virtual DbSet<t_grade_lecture> t_grade_lectures { get; set; }

	public virtual DbSet<t_lecture> t_lectures { get; set; }

	public virtual DbSet<t_property> t_properties { get; set; }

	public virtual DbSet<t_property_type> t_property_types { get; set; }

	public virtual DbSet<t_student> t_students { get; set; }

	public virtual DbSet<t_user> t_users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql(ConnectionSettings.DbConnectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<t_city>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_city_pkey");

			entity.ToTable("t_city");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.plate_code)
				.IsRequired()
				.HasMaxLength(2);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.t_country).WithMany(p => p.t_cities)
				.HasForeignKey(d => d.t_country_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_city_t_country_id_fkey");
		});

		modelBuilder.Entity<t_country>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_country_pkey");

			entity.ToTable("t_country");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<t_county>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_county_pkey");

			entity.ToTable("t_county");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.t_city).WithMany(p => p.t_counties)
				.HasForeignKey(d => d.t_city_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_county_t_city_id_fkey");
		});

		modelBuilder.Entity<t_difficulty_level>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_difficulty_level_pkey");

			entity.ToTable("t_difficulty_level");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(25);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<t_grade>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_grade_pkey");

			entity.ToTable("t_grade");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(2);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<t_grade_lecture>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_grade_lecture_pkey");

			entity.ToTable("t_grade_lecture");

			entity.HasIndex(e => new { e.t_grade_id, e.t_lecture_id }, "grade_lecture_unique").IsUnique();

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.t_grade).WithMany(p => p.t_grade_lectures)
				.HasForeignKey(d => d.t_grade_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_grade_lecture_t_grade_id_fkey");

			entity.HasOne(d => d.t_lecture).WithMany(p => p.t_grade_lectures)
				.HasForeignKey(d => d.t_lecture_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_grade_lecture_t_lecture_id_fkey");
		});

		modelBuilder.Entity<t_lecture>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_lecture_pkey");

			entity.ToTable("t_lecture");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.language_key)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

			//entity.HasOne(d => d.t_country).WithMany(p => p.t_lectures)
			//	.HasForeignKey(d => d.t_country_id)
			//	.OnDelete(DeleteBehavior.ClientSetNull)
			//	.HasConstraintName("fk_t_lecture_t_country");
		});

		modelBuilder.Entity<t_property>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_property_pkey");

			entity.ToTable("t_property");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(50);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<t_property_type>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_property_type_pkey");

			entity.ToTable("t_property_type");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(50);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<t_student>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_student_pkey");

			entity.ToTable("t_student");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.school_name)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.t_grade).WithMany(p => p.t_students)
				.HasForeignKey(d => d.t_grade_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_student_t_grade_id_fkey");

			entity.HasOne(d => d.t_user).WithMany(p => p.t_students)
				.HasForeignKey(d => d.t_user_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_student_t_user_id_fkey");
		});

		modelBuilder.Entity<t_user>(entity =>
		{
			entity.HasKey(e => e.id).HasName("t_user_pkey");

			entity.ToTable("t_user");

			entity.Property(e => e.created_at).HasColumnType("timestamp without time zone");
			entity.Property(e => e.email)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.image_base64).HasColumnType("character varying");
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.password)
				.IsRequired()
				.HasMaxLength(200);
			entity.Property(e => e.password_salt).IsRequired();
			entity.Property(e => e.surname)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.t_county).WithMany(p => p.t_users)
				.HasForeignKey(d => d.t_county_id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_user_t_county_id_fkey");

			entity.HasOne(d => d.t_property_id_user_typeNavigation).WithMany(p => p.t_users)
				.HasForeignKey(d => d.t_property_id_user_type)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("t_user_t_property_id_fkey");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
