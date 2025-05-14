using System;
using System.Collections.Generic;
using DAL.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DatabaseFirst;

public partial class MyContext : DbContext
{
    public MyContext()
    {
    }

    public MyContext(DbContextOptions<MyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Cat> Cats { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Dog> Dogs { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Educator> Educators { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<Localization> Localizations { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<SequenceValue> SequenceValues { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<SubComponent> SubComponents { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("Animal");

            entity.Property(e => e.Key).HasDefaultValueSql("(NEXT VALUE FOR [AnimalSequence])");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("Car");

            entity.HasIndex(e => e.EngineId, "IX_Car_EngineId");

            entity.HasIndex(e => e.RegistrationId, "IX_Car_RegistrationId")
                .IsUnique()
                .HasFilter("([RegistrationId] IS NOT NULL)");

            entity.HasOne(d => d.Engine).WithMany(p => p.Cars).HasForeignKey(d => d.EngineId);

            entity.HasOne(d => d.Registration).WithOne(p => p.Car)
                .HasForeignKey<Car>(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Drivers).WithMany(p => p.Cars)
                .UsingEntity<Dictionary<string, object>>(
                    "CarDriver",
                    r => r.HasOne<Driver>().WithMany().HasForeignKey("DriversId"),
                    l => l.HasOne<Car>().WithMany().HasForeignKey("CarId"),
                    j =>
                    {
                        j.HasKey("CarId", "DriversId");
                        j.ToTable("CarDriver");
                        j.HasIndex(new[] { "DriversId" }, "IX_CarDriver_DriversId");
                    });
        });

        modelBuilder.Entity<Cat>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("Cat");

            entity.Property(e => e.Key).HasDefaultValueSql("(NEXT VALUE FOR [AnimalSequence])");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.ToTable("Component");
        });

        modelBuilder.Entity<Dog>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("Dog");

            entity.Property(e => e.Key).HasDefaultValueSql("(NEXT VALUE FOR [AnimalSequence])");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");
        });

        modelBuilder.Entity<Educator>(entity =>
        {
            entity.ToTable("Educator");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Educator).HasForeignKey<Educator>(d => d.Id);
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.ToTable("Engine");
        });

        modelBuilder.Entity<Localization>(entity =>
        {
            entity.HasKey(e => new { e.Latitude, e.Longitude });

            entity.ToTable("Localization");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(e => e.FirstName, "IX_People_FirstName");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "IX_People_FirstName_LastName")
                .IsUnique()
                .HasFilter("([FirstName] IS NOT NULL)");

            entity.Property(e => e.Age).HasDefaultValue(18);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FullName)
                .HasMaxLength(461)
                .HasComputedColumnSql("(concat([FirstName],' ',[LastName]))", true);
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .HasDefaultValue("Unknown");
            entity.Property(e => e.ModifiedAt)
                .HasComputedColumnSql("(getdate())", false)
                .HasColumnType("datetime");
            entity.Property(e => e.Pesel)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("PESEL");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.ToTable("Registration");
        });

        modelBuilder.Entity<SequenceValue>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [CustomId])");
            entity.Property(e => e.Value).HasDefaultValueSql("(NEXT VALUE FOR [MySequence])");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Student).HasForeignKey<Student>(d => d.Id);
        });

        modelBuilder.Entity<SubComponent>(entity =>
        {
            entity.ToTable("SubComponent");

            entity.HasIndex(e => e.ComponentId, "IX_SubComponent_ComponentId");

            entity.HasIndex(e => e.StatusId, "IX_SubComponent_StatusId");

            entity.HasOne(d => d.Component).WithMany(p => p.SubComponents).HasForeignKey(d => d.ComponentId);

            entity.HasOne(d => d.Status).WithMany(p => p.SubComponents).HasForeignKey(d => d.StatusId);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tag");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });
        modelBuilder.HasSequence("AnimalSequence");
        modelBuilder.HasSequence<int>("CustomId");
        modelBuilder.HasSequence<int>("MySequence")
            .StartsAt(150L)
            .IncrementsBy(22)
            .HasMin(100L)
            .HasMax(200L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
