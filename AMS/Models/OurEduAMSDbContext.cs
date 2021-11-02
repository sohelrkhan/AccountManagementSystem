using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AMS.Models
{
    public partial class OurEduAMSDbContext : DbContext
    {
        public OurEduAMSDbContext()
        {
        }

        public OurEduAMSDbContext(DbContextOptions<OurEduAMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bonus> Bonus { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<ComGenders> ComGenders { get; set; }
        public virtual DbSet<Designations> Designations { get; set; }
        public virtual DbSet<Donation> Donation { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<ExtraIncomes> ExtraIncomes { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<FeesTypes> FeesTypes { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PayScales> PayScales { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<SalaryIncrements> SalaryIncrements { get; set; }
        public virtual DbSet<Scholarships> Scholarships { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<StudentPayments> StudentPayments { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EMAGC1F\\MSSQLSERVER01;Database=OurEduAMSDb;User ID=rana; Password=a; TrustServerCertificate=true;MultipleActiveResultSets=True;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bonus_Staff");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ComGenders>(entity =>
            {
                entity.ToTable("COM_Genders");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Designations>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Details).HasMaxLength(50);

                entity.Property(e => e.DonationFrom).HasMaxLength(50);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Details).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ExtraIncomes>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ExtraIncomes)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtraIncomes_Staff");
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_Class");

                entity.HasOne(d => d.FeesType)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.FeesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_FeesTypeId");
            });

            modelBuilder.Entity<FeesTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PayScales>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.PayScales)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayScales_DesignationFK");
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Salary_StaffFK");
            });

            modelBuilder.Entity<SalaryIncrements>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.SalaryIncrements)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalaryIncrements_Staffs");
            });

            modelBuilder.Entity<Scholarships>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Scholarships)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scholarships_Students");
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cell)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Staffs_ClassId");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staffs_Designation");
            });

            modelBuilder.Entity<StudentPayments>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Fine).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.HasOne(d => d.Fee)
                    .WithMany(p => p.StudentPayments)
                    .HasForeignKey(d => d.FeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentPayments_FeeId");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.StudentPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentPayments_PaymentType");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPayments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentPayments_Student");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdmittedYear).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.PermanentAddress).HasMaxLength(200);

                entity.Property(e => e.PresentAddress).HasMaxLength(200);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_classForegn");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender");
            });
        }
    }
}
