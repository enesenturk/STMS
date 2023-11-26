using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NS.STMS.Settings;

namespace NS.STMS.Entity.Context;

public partial class ns_stmsContext : DbContext
{
	public ns_stmsContext()
	{
	}

	public ns_stmsContext(DbContextOptions<ns_stmsContext> options)
		: base(options)
	{
	}

	public virtual DbSet<t_city> t_cities { get; set; }

	public virtual DbSet<t_country> t_countries { get; set; }

	public virtual DbSet<t_county> t_counties { get; set; }

	public virtual DbSet<t_difficulty_level> t_difficulty_levels { get; set; }

	public virtual DbSet<t_grade> t_grades { get; set; }

	public virtual DbSet<t_grade_lecture> t_grade_lectures { get; set; }

	public virtual DbSet<t_lecture> t_lectures { get; set; }

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
			entity.Property(e => e.name)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
