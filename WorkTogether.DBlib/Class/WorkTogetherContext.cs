using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkTogether.DBlib.Class;

public partial class WorkTogetherContext : DbContext
{
    public WorkTogetherContext()
    {
    }

    public WorkTogetherContext(DbContextOptions<WorkTogetherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DoctrineMigrationVersion> DoctrineMigrationVersions { get; set; }

    public virtual DbSet<MessengerMessage> MessengerMessages { get; set; }

    public virtual DbSet<Pack> Packs { get; set; }

    public virtual DbSet<Rack> Racks { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<TypeReservation> TypeReservations { get; set; }

    public virtual DbSet<TypeUnit> TypeUnits { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost;Database=WorkTogether;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable(nameof(Customer));
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<DoctrineMigrationVersion>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK__doctrine__79B5C94C64D069B6");

            entity.ToTable("doctrine_migration_versions");

            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasColumnName("version");
            entity.Property(e => e.ExecutedAt)
                .HasPrecision(6)
                .HasColumnName("executed_at");
            entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");
        });

        modelBuilder.Entity<MessengerMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__messenge__3213E83F90B17D4A");

            entity.ToTable("messenger_messages");

            entity.HasIndex(e => e.DeliveredAt, "IDX_75EA56E016BA31DB");

            entity.HasIndex(e => e.AvailableAt, "IDX_75EA56E0E3BD61CE");

            entity.HasIndex(e => e.QueueName, "IDX_75EA56E0FB7336F0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("available_at");
            entity.Property(e => e.Body)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("created_at");
            entity.Property(e => e.DeliveredAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("delivered_at");
            entity.Property(e => e.Headers)
                .IsUnicode(false)
                .HasColumnName("headers");
            entity.Property(e => e.QueueName)
                .HasMaxLength(190)
                .HasColumnName("queue_name");
        });

        modelBuilder.Entity<Pack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pack__3213E83FEDF12037");

            entity.ToTable("pack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NumberSlot).HasColumnName("number_slot");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Rack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rack__3213E83F437817BA");

            entity.ToTable("rack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumberSlot).HasColumnName("number_slot");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83F5F279DA8");

            entity.ToTable("reservation");

            entity.HasIndex(e => e.PackId, "IDX_42C849551919B217");

            entity.HasIndex(e => e.ClientId, "IDX_42C8495519EB6921");

            entity.HasIndex(e => e.TypeReservationId, "IDX_42C84955EEF1BE73");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.PackId).HasColumnName("pack_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TypeReservationId).HasColumnName("type_reservation_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_42C8495519EB6921");

            entity.HasOne(d => d.Pack).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_42C849551919B217");

            entity.HasOne(d => d.TypeReservation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TypeReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_42C84955EEF1BE73");
        });

        modelBuilder.Entity<TypeReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_res__3213E83F39BE2480");

            entity.ToTable("type_reservation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
        });

        modelBuilder.Entity<TypeUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_uni__3213E83F90298F1B");

            entity.ToTable("type_unit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unit__3213E83F6F91538D");

            entity.ToTable("unit");

            entity.HasIndex(e => e.RackId, "IDX_DCBB0C538E86A33E");

            entity.HasIndex(e => e.ReservationId, "IDX_DCBB0C53B83297E7");

            entity.HasIndex(e => e.TypeUnitId, "IDX_DCBB0C53D09C1FF8");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LocationSlot).HasColumnName("location_slot");
            entity.Property(e => e.RackId).HasColumnName("rack_id");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.TypeUnitId).HasColumnName("type_unit_id");

            entity.HasOne(d => d.Rack).WithMany(p => p.Units)
                .HasForeignKey(d => d.RackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCBB0C538E86A33E");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Units)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_DCBB0C53B83297E7");

            entity.HasOne(d => d.TypeUnit).WithMany(p => p.Units)
                .HasForeignKey(d => d.TypeUnitId)
                .HasConstraintName("FK_DCBB0C53D09C1FF8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(nameof(User));
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FA71D11A0");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UNIQ_8D93D649E7927C74")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Roles)
                .IsUnicode(false)
                .HasComment("(DC2Type:json)")
                .HasColumnName("roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
