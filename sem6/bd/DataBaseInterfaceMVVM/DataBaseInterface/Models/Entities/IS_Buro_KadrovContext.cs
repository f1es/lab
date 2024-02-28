using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBaseInterface.Entities
{
    public partial class IS_Buro_KadrovContext : DbContext
    {
        private static IS_Buro_KadrovContext context;
        private IS_Buro_KadrovContext()
        {

        }

        public static IS_Buro_KadrovContext GetInstance()
        {
            if (context == null)
                context = new IS_Buro_KadrovContext();
            return context;
        }

        public IS_Buro_KadrovContext(DbContextOptions<IS_Buro_KadrovContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Encouragement> Encouragements { get; set; } = null!;
        public virtual DbSet<JobVacancy> JobVacancies { get; set; } = null!;
        public virtual DbSet<Offence> Offences { get; set; } = null!;
        public virtual DbSet<Proffesion> Proffesions { get; set; } = null!;
        public virtual DbSet<ProffesionsVacancy> ProffesionsVacancies { get; set; } = null!;
        public virtual DbSet<Qualification> Qualifications { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;
        public virtual DbSet<WorkersDepartment> WorkersDepartments { get; set; } = null!;
        public virtual DbSet<WorkersEncouragement> WorkersEncouragements { get; set; } = null!;
        public virtual DbSet<WorkersOffence> WorkersOffences { get; set; } = null!;
        public virtual DbSet<WorkersState> WorkersStates { get; set; } = null!;
        public virtual DbSet<WorkersTelephone> WorkersTelephones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IS_Buro_Kadrov;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.DirectorId, "UQ__Company__3939BCE048AF50BD")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseDate)
                    .HasColumnType("date")
                    .HasColumnName("Base_Date");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.DirectorId).HasColumnName("Director_ID");

                entity.HasOne(d => d.Director)
                    .WithOne(p => p.Company)
                    .HasForeignKey<Company>(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Company__Directo__47DBAE45");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContractNumber).HasColumnName("Contract_Number");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Department_Name");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Compa__4AB81AF0");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleNames)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Names");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.QualificationId, "UQ__Employee__D0DE2D6E3C574355")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.ContractId).HasColumnName("Contract_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleNames)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Names");

                entity.Property(e => e.QualificationId).HasColumnName("Qualification_ID");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Contra__52593CB8");

                entity.HasOne(d => d.Qualification)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.QualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Qualif__534D60F1");
            });

            modelBuilder.Entity<Encouragement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EncouragementName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Encouragement_Name");
            });

            modelBuilder.Entity<JobVacancy>(entity =>
            {
                entity.ToTable("Job_Vacancy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("date")
                    .HasColumnName("Receipt_Date");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.JobVacancies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job_Vacan__Compa__5AEE82B9");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobVacancies)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Job_Vacan__Emplo__59FA5E80");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.JobVacancies)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("FK_Worker_ID");
            });

            modelBuilder.Entity<Offence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OffenceName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Offence_Name");

                entity.Property(e => e.Punishment)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proffesion>(entity =>
            {
                entity.ToTable("Proffesion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProffesionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Proffesion_Name");

                entity.Property(e => e.Salary).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<ProffesionsVacancy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Proffesions_Vacancy");

                entity.Property(e => e.ProffesionId).HasColumnName("Proffesion_ID");

                entity.Property(e => e.VacancyId).HasColumnName("Vacancy_ID");

                entity.HasOne(d => d.Proffesion)
                    .WithMany()
                    .HasForeignKey(d => d.ProffesionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proffesio__Proff__66603565");

                entity.HasOne(d => d.Vacancy)
                    .WithMany()
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proffesio__Vacan__656C112C");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("Qualification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Education)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkExpirience).HasColumnName("Work_Expirience");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SpecialityName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Speciality_Name");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleNames)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Names");

                entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers__Departm__4E88ABD4");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK__Workers__Special__4D94879B");
            });

            modelBuilder.Entity<WorkersDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Workers_Department");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_D__Depar__628FA481");

                entity.HasOne(d => d.Worker)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_D__Worke__6383C8BA");
            });

            modelBuilder.Entity<WorkersEncouragement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Workers_encouragement");

                entity.Property(e => e.EncouragementId).HasColumnName("Encouragement_ID");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Encouragement)
                    .WithMany()
                    .HasForeignKey(d => d.EncouragementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_e__Encou__5CD6CB2B");

                entity.HasOne(d => d.Worker)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_e__Worke__5DCAEF64");
            });

            modelBuilder.Entity<WorkersOffence>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Workers_offences");

                entity.Property(e => e.OffenceId).HasColumnName("Offence_ID");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Offence)
                    .WithMany()
                    .HasForeignKey(d => d.OffenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_o__Offen__5FB337D6");

                entity.HasOne(d => d.Worker)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_o__Worke__60A75C0F");
            });

            modelBuilder.Entity<WorkersState>(entity =>
            {
                entity.ToTable("Workers_State");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("State_Name");
            });

            modelBuilder.Entity<WorkersTelephone>(entity =>
            {
                entity.ToTable("Workers_telephones");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Telephone_Number");

                entity.Property(e => e.TelephoneType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Telephone_Type");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.WorkersTelephones)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers_t__Worke__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
